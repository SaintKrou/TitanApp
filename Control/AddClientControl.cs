using System;
using System.Linq;
using System.Windows.Forms;
using TitanApp.Data;
using TitanApp.Models;

namespace TitanApp.Controls
{
    public partial class AddClientControl : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly Client? _clientToEdit;

        public AddClientControl(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;

            using var db = new AppDbContext();
            int nextId = (db.Clients.Any() ? db.Clients.Max(c => c.Id) + 1 : 1);
            txtId.Text = nextId.ToString();
            txtId.ReadOnly = true;

            // Установим фокус после загрузки контрола
            this.Load += (_, __) => txtLastName.Focus();
        }

        public AddClientControl(MainForm mainForm, Client clientToEdit)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _clientToEdit = clientToEdit;

            txtId.Text = clientToEdit.Id.ToString();
            txtId.ReadOnly = true;
            txtLastName.Text = clientToEdit.LastName;
            txtFirstName.Text = clientToEdit.FirstName;
            txtMiddleName.Text = clientToEdit.MiddleName;
            txtTelegram.Text = clientToEdit.Telegram;
            txtComment.Text = clientToEdit.Comment;
            chkUnlimited.Checked = clientToEdit.Unlimited;
            numSessions.Value = clientToEdit.PurchasedSessions;
            dtpEnd.Value = clientToEdit.SubscriptionEnd;

            // Установим фокус после загрузки контрола
            this.Load += (_, __) => txtLastName.Focus();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using var db = new AppDbContext();

            if (_clientToEdit != null)
            {
                var client = db.Clients.Find(_clientToEdit.Id);
                if (client == null)
                {
                    MessageBox.Show("Клиент не найден в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string changes = "";

                void TrackChange(string fieldName, object oldVal, object newVal)
                {
                    if (!Equals(oldVal, newVal))
                    {
                        changes += $"{fieldName}: \"{oldVal}\" → \"{newVal}\"; ";
                    }
                }

                TrackChange("Фамилия", client.LastName, txtLastName.Text.Trim());
                TrackChange("Имя", client.FirstName, txtFirstName.Text.Trim());
                TrackChange("Отчество", client.MiddleName, txtMiddleName.Text.Trim());
                TrackChange("Telegram", client.Telegram, txtTelegram.Text.Trim());
                TrackChange("Комментарий", client.Comment, txtComment.Text.Trim());
                TrackChange("Безлимит", client.Unlimited, chkUnlimited.Checked);
                TrackChange("Сеансы", client.PurchasedSessions, (int)numSessions.Value);
                TrackChange("Окончание", client.SubscriptionEnd.ToShortDateString(), dtpEnd.Value.ToShortDateString());

                client.LastName = txtLastName.Text.Trim();
                client.FirstName = txtFirstName.Text.Trim();
                client.MiddleName = txtMiddleName.Text.Trim();
                client.Telegram = txtTelegram.Text.Trim();
                client.Comment = txtComment.Text.Trim();
                client.Unlimited = chkUnlimited.Checked;
                client.PurchasedSessions = (int)numSessions.Value;
                client.SubscriptionEnd = dtpEnd.Value;

                db.SaveChanges();

                _mainForm.AddLog($"Редактирован клиент: ID {client.Id}, {client.LastName}. Изменения: {changes}");
                _mainForm.UpdateNotification($"Клиент {client.LastName} (ID {client.Id}) обновлён");

                MessageBox.Show("Клиент обновлён.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var newClient = new Client
                {
                    LastName = txtLastName.Text.Trim(),
                    FirstName = txtFirstName.Text.Trim(),
                    MiddleName = txtMiddleName.Text.Trim(),
                    Telegram = txtTelegram.Text.Trim(),
                    Comment = txtComment.Text.Trim(),
                    Unlimited = chkUnlimited.Checked,
                    PurchasedSessions = (int)numSessions.Value,
                    SubscriptionEnd = dtpEnd.Value
                };

                db.Clients.Add(newClient);
                db.SaveChanges();

                txtId.Text = newClient.Id.ToString();

                _mainForm.AddLog($"Добавлен клиент: ID {newClient.Id}, {newClient.LastName}");
                _mainForm.UpdateNotification($"Клиент {newClient.LastName} (ID {newClient.Id}) добавлен");

                MessageBox.Show("Клиент добавлен.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
