using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TitanApp.Data;
using TitanApp.Models;

namespace TitanApp.Controls
{
    public partial class ClientListControl : UserControl
    {
        private readonly AppDbContext _db;
        private readonly MainForm _mainForm;
        private readonly string _logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity.log.txt");

        public ClientListControl(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _db = new AppDbContext();
            LoadClients();
        }

        private void LoadClients()
        {
            var clients = _db.Clients
                .Select(c => new
                {
                    Id = c.Id,
                    ФИО = c.LastName + " " +
                          (!string.IsNullOrEmpty(c.FirstName) ? c.FirstName.Substring(0, 1) + "." : "") +
                          (!string.IsNullOrEmpty(c.MiddleName) ? c.MiddleName.Substring(0, 1) + "." : ""),
                    КоличествоПосещений = c.PurchasedSessions,
                    ОкончаниеАбонемента = c.SubscriptionEnd.ToShortDateString(),
                    Безлимитный = c.Unlimited
                })
                .ToList();

            dgvClients.DataSource = clients;
            if (dgvClients.Columns.Contains("Id"))
                dgvClients.Columns["Id"].Visible = false;
        }

        private int? GetSelectedClientId()
        {
            if (dgvClients.CurrentRow?.Cells["Id"].Value is int id)
                return id;

            return null;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            _mainForm.OpenTab("Добавить клиента", new AddClientControl(_mainForm));
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedClientId();
            if (id == null)
            {
                MessageBox.Show("Выберите клиента для редактирования.", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var client = _db.Clients.Find(id.Value);
            if (client == null)
            {
                MessageBox.Show("Клиент не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _mainForm.OpenTab("Редактировать клиента", new AddClientControl(_mainForm, client));

        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedClientId();
            if (id == null)
            {
                MessageBox.Show("Выберите клиента для удаления.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var client = _db.Clients.Find(id.Value);
            if (client == null)
            {
                MessageBox.Show("Клиент не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show("Вы уверены, что хотите удалить клиента?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _db.Clients.Remove(client);
                _db.SaveChanges();
                LogAction($"{DateTime.Now:dd.MM.yy HH:mm} | Удалён клиент | ID={client.Id} | {client.LastName} {client.FirstName}");
                LoadClients();
            }
        }

        private void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedClientId();
            if (id == null)
            {
                MessageBox.Show("Выберите клиента для отметки посещения.", "Посещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var client = _db.Clients.Find(id.Value);
            if (client == null)
            {
                MessageBox.Show("Клиент не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (client.PurchasedSessions > 0)
            {
                int before = client.PurchasedSessions;
                client.PurchasedSessions -= 1;
                _db.SaveChanges();
                LogAction($"{DateTime.Now:dd.MM.yy HH:mm} | Посещение | ID={client.Id} | Занятия: {before} -> {client.PurchasedSessions}");
                LoadClients();
            }
            else
            {
                MessageBox.Show("У клиента нет оставшихся занятий.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnApplySubscription_Click(object sender, EventArgs e)
        {
            int? id = GetSelectedClientId();
            if (id == null)
            {
                MessageBox.Show("Выберите клиента для применения абонемента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var client = _db.Clients.Find(id.Value);
            if (client == null)
            {
                MessageBox.Show("Клиент не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _mainForm.OpenTab("Применить абонемент", new ApplySubscriptionControl(_mainForm, client));
        }

        private void btnManagePurchases_Click(object sender, EventArgs e)
        {
            _mainForm.OpenTab("Абонементы", new PurchaseControl(_mainForm));
        }

        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            _mainForm.OpenTab("Лог активности", new LogControl(_logFile));
        }

        private void LogAction(string message)
        {
            try
            {
                File.AppendAllText(_logFile, message + Environment.NewLine);
            }
            catch
            {
                // Можно проигнорировать или показать сообщение, если важно
            }
        }
    }
}
