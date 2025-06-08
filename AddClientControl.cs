using System;
using System.Windows.Forms;
using TitanApp.Data;
using TitanApp.Models;

namespace TitanApp.Controls
{
    public partial class AddClientControl : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly Client? _clientToEdit;

        // Конструктор для добавления нового клиента
        public AddClientControl(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        // Конструктор для редактирования существующего клиента
        public AddClientControl(MainForm mainForm, Client clientToEdit)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _clientToEdit = clientToEdit;

            // Заполнение полей формы данными клиента
            txtLastName.Text = clientToEdit.LastName;
            txtFirstName.Text = clientToEdit.FirstName;
            txtMiddleName.Text = clientToEdit.MiddleName;
            txtTelegram.Text = clientToEdit.Telegram;
            txtComment.Text = clientToEdit.Comment;
            chkUnlimited.Checked = clientToEdit.Unlimited;
            numSessions.Value = clientToEdit.PurchasedSessions;
            dtpEnd.Value = clientToEdit.SubscriptionEnd;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using var db = new AppDbContext();

            if (_clientToEdit != null)
            {
                // Редактирование существующего клиента
                var client = db.Clients.Find(_clientToEdit.Id);
                if (client == null)
                {
                    MessageBox.Show("Клиент не найден в базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                client.LastName = txtLastName.Text.Trim();
                client.FirstName = txtFirstName.Text.Trim();
                client.MiddleName = txtMiddleName.Text.Trim();
                client.Telegram = txtTelegram.Text.Trim();
                client.Comment = txtComment.Text.Trim();
                client.Unlimited = chkUnlimited.Checked;
                client.PurchasedSessions = (int)numSessions.Value;
                client.SubscriptionEnd = dtpEnd.Value;

                db.SaveChanges();

                MessageBox.Show("Клиент обновлён.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Добавление нового клиента
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

                MessageBox.Show("Клиент добавлен.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
