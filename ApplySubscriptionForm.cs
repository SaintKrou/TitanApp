using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using TitanApp.Data;
using TitanApp.Models;
using TitanApp.Utils;

namespace TitanApp
{
    public partial class ApplySubscriptionForm : Form
    {
        private readonly Client _client;
        private readonly AppDbContext _db;
        private Purchase? _selectedPurchase;
        private readonly string _logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity.log.txt");


        public PaymentMethod SelectedPaymentMethod { get; private set; }

        public ApplySubscriptionForm(Client client)
        {
            InitializeComponent();
            _client = client;
            _db = new AppDbContext();
        }

        private void ApplySubscriptionForm_Load(object sender, EventArgs e)
        {
            lblClientName.Text = $"{_client.LastName} {_client.FirstName} {_client.MiddleName}".Trim();

            dgvSubscriptions.DataSource = _db.Purchases
                .Select(p => new
                {
                    p.Id,
                    Название = p.Name,
                    Занятий = p.SessionsCount,
                    Безлимит = p.Unlimited,
                    Месяцев = p.DurationMonths,
                    Цена = p.Cost
                })
                .ToList();

            dgvSubscriptions.Columns["Id"].Visible = false;
            dgvSubscriptions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Очистка и инициализация ComboBox оплаты без дублирования
            if (cbPaymentMethod.Items.Count == 0)
            {
                cbPaymentMethod.Items.Add("Наличная");
                cbPaymentMethod.Items.Add("Безналичная");
            }
            cbPaymentMethod.SelectedIndex = -1;
        }


        private void dgvSubscriptions_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSubscriptions.CurrentRow == null) return;

            int id = (int)dgvSubscriptions.CurrentRow.Cells["Id"].Value;
            _selectedPurchase = _db.Purchases.FirstOrDefault(p => p.Id == id);
            if (_selectedPurchase != null)
            {
                lblDuration.Text = $"{_selectedPurchase.DurationMonths} мес.";
                lblSessions.Text = _selectedPurchase.Unlimited ? "Безлимит" : _selectedPurchase.SessionsCount.ToString();
                lblCost.Text = $"{_selectedPurchase.Cost:C}";
                var newEndDate = _client.SubscriptionEnd > DateTime.Today
                    ? _client.SubscriptionEnd.AddMonths(_selectedPurchase.DurationMonths)
                    : DateTime.Today.AddMonths(_selectedPurchase.DurationMonths);
                lblEndDate.Text = newEndDate.ToShortDateString();
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (_selectedPurchase == null)
            {
                MessageBox.Show("Пожалуйста, выберите абонемент.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbPaymentMethod.SelectedIndex == -1)
            {
                MessageBox.Show("Пожалуйста, выберите способ оплаты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SelectedPaymentMethod = cbPaymentMethod.SelectedIndex == 0
                ? PaymentMethod.Cash
                : PaymentMethod.NonCash;

            // Применение абонемента
            _client.Unlimited = _selectedPurchase.Unlimited;

            if (_selectedPurchase.Unlimited)
            {
                _client.PurchasedSessions = 0;
            }
            else
            {
                _client.PurchasedSessions += _selectedPurchase.SessionsCount;
            }

            _client.SubscriptionEnd = _client.SubscriptionEnd > DateTime.Today
                ? _client.SubscriptionEnd.AddMonths(_selectedPurchase.DurationMonths)
                : DateTime.Today.AddMonths(_selectedPurchase.DurationMonths);

            _db.Clients.Update(_client);
            _db.SaveChanges();
            //Logger.LogEvent($"Абонемент применён | ID={_client.Id} | {_client.LastName} {_client.FirstName} {_client.MiddleName} | Абонемент: \"{_selectedPurchase.Name}\" | Оплата: {cbPaymentMethod.SelectedItem} | Цена: {_selectedPurchase.Cost} руб.");
            LogAction($"{DateTime.Now:dd.MM.yy HH:mm} | Покупка | ID={_client.Id} | {_client.LastName} | Абонемент: \"{_selectedPurchase.Name}\" | Оплата: {cbPaymentMethod.SelectedItem} | Цена: {_selectedPurchase.Cost} руб.");
            MessageBox.Show("Абонемент успешно применён.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void LogAction(string message)
        {
            File.AppendAllText(_logFile, $"{message}{Environment.NewLine}");
        }
    }
}
