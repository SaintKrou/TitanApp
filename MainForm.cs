using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TitanApp.Data;
using TitanApp.Models;

namespace TitanApp
{
    public partial class MainForm : Form
    {
        private readonly AppDbContext _db;
        private readonly string _logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity.log.txt");

        public MainForm()
        {
            InitializeComponent();
            _db = new AppDbContext();
            LoadClients();
        }

        private void LoadClients()
        {
            var clients = _db.Clients
                .Select(c => new
                {
                    ФИО = c.LastName + " " + c.FirstName.Substring(0, 1) + "." +
                          (string.IsNullOrEmpty(c.MiddleName) ? "" : c.MiddleName.Substring(0, 1) + "."),
                    КоличествоПосещений = c.PurchasedSessions,
                    ОкончаниеАбонемента = c.SubscriptionEnd.ToShortDateString(),
                    Безлимитный = c.Unlimited
                })
                .ToList();

            dgvClients.DataSource = clients;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            using var form = new AddClientForm();
            if (form.ShowDialog() == DialogResult.OK && form.Client != null)
            {
                var client = form.Client;
                //LogAction($"{DateTime.Now:dd.MM.yy HH:mm} | Создан | ID={client.Id} | {client.LastName} {client.FirstName} | Занятий={client.PurchasedSessions} | Безлимит={client.Unlimited}");
                LoadClients();
            }
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Выберите клиента для редактирования.", "Редактирование", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgvClients.CurrentRow.Index;
            var clients = _db.Clients.ToList();
            if (index < 0 || index >= clients.Count)
            {
                MessageBox.Show("Ошибка выбора клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var client = clients[index];
            var original = _db.Clients.AsNoTracking().FirstOrDefault(c => c.Id == client.Id);

            using var form = new AddClientForm(client.Id);
            if (form.ShowDialog() == DialogResult.OK && form.Client != null)
            {
                var updated = _db.Clients.Find(client.Id);
                string changes = "";
                if (original.PurchasedSessions != updated.PurchasedSessions)
                    changes += $"Занятия: {original.PurchasedSessions}->{updated.PurchasedSessions}; ";
                if (original.Unlimited != updated.Unlimited)
                    changes += $"Безлимит: {original.Unlimited}->{updated.Unlimited}; ";

                //LogAction($"{DateTime.Now:dd.MM.yy HH:mm} | Изменён | ID={client.Id} | {changes}");
                LoadClients();
            }
        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Выберите клиента для удаления.", "Удаление", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgvClients.CurrentRow.Index;
            var clients = _db.Clients.ToList();
            if (index < 0 || index >= clients.Count)
            {
                MessageBox.Show("Ошибка выбора клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var client = clients[index];
            var result = MessageBox.Show("Вы уверены, что хотите удалить клиента?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _db.Clients.Remove(client);
                _db.SaveChanges();
                LogAction($"{DateTime.Now:dd.MM.yy HH:mm} | Удалён | ID={client.Id} | {client.LastName} {client.FirstName}");
                LoadClients();
            }
        }

        private void btnMarkAttendance_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Выберите клиента для отметки посещения.", "Посещение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgvClients.CurrentRow.Index;
            var clients = _db.Clients.ToList();
            if (index < 0 || index >= clients.Count)
            {
                MessageBox.Show("Ошибка выбора клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var client = clients[index];
            int before = client.PurchasedSessions;

            if (before > 0)
            {
                client.PurchasedSessions -= 1;
                _db.SaveChanges();
                LogAction($"{DateTime.Now:dd.MM.yy HH:mm} | Посещение | ID={client.Id} | Занятия: {before}->{client.PurchasedSessions}");
                LoadClients();
            }
            else
            {
                MessageBox.Show("У клиента нет оставшихся занятий.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnManagePurchases_Click(object sender, EventArgs e)
        {
            using var form = new PurchaseForm();
            form.ShowDialog();
            LoadClients();
        }

        private void btnViewLogs_Click(object sender, EventArgs e)
        {
            using var form = new LogForm(_logFile);
            form.ShowDialog();
        }

        private void btnApplySubscription_Click(object sender, EventArgs e)
        {
            if (dgvClients.CurrentRow == null)
            {
                MessageBox.Show("Выберите клиента для применения абонемента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = dgvClients.CurrentRow.Index;
            var clients = _db.Clients.ToList();
            if (index < 0 || index >= clients.Count)
            {
                MessageBox.Show("Ошибка выбора клиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var client = clients[index];

            using var form = new ApplySubscriptionForm(client);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LogAction($"{DateTime.Now:dd.MM.yy HH:mm} | Применён абонемент | ID={client.Id}");
                LoadClients();
            }
        }

        private void LogAction(string message)
        {
            File.AppendAllText(_logFile, $"{message}{Environment.NewLine}");
        }
    }
}
