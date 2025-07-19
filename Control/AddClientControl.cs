using System;
using System.IO;
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
        private readonly string _logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity.log.txt");

        public AddClientControl(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;

            using var db = new AppDbContext();
            int nextId = (db.Clients.Any() ? db.Clients.Max(c => c.Id) + 1 : 1);
            txtId.Text = nextId.ToString();
            txtId.ReadOnly = true;

            btnAddVisit.Enabled = false;
            btnRemoveVisit.Enabled = false;
            dtpVisit.Enabled = false;

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
            txtPhone.Text = clientToEdit.Phone;
            txtTelegram.Text = clientToEdit.Telegram;
            txtComment.Text = clientToEdit.Comment;
            chkUnlimited.Checked = clientToEdit.Unlimited;
            numSessions.Value = clientToEdit.PurchasedSessions;
            dtpEnd.Value = clientToEdit.SubscriptionEnd;

            btnAddVisit.Enabled = true;
            btnRemoveVisit.Enabled = true;
            dtpVisit.Enabled = true;

            LoadAttendanceDates();

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
                        changes += $"{fieldName}: \"{oldVal}\" → \"{newVal}\"; ";
                }

                TrackChange("Фамилия", client.LastName, txtLastName.Text.Trim());
                TrackChange("Имя", client.FirstName, txtFirstName.Text.Trim());
                TrackChange("Отчество", client.MiddleName, txtMiddleName.Text.Trim());
                TrackChange("Телефон", client.Phone, txtPhone.Text.Trim());
                TrackChange("Telegram", client.Telegram, txtTelegram.Text.Trim());
                TrackChange("Комментарий", client.Comment, txtComment.Text.Trim());
                TrackChange("Безлимит", client.Unlimited, chkUnlimited.Checked);
                TrackChange("Сеансы", client.PurchasedSessions, (int)numSessions.Value);
                TrackChange("Окончание", client.SubscriptionEnd.ToShortDateString(), dtpEnd.Value.ToShortDateString());

                client.LastName = txtLastName.Text.Trim();
                client.FirstName = txtFirstName.Text.Trim();
                client.MiddleName = txtMiddleName.Text.Trim();
                client.Phone = txtPhone.Text.Trim();
                client.Telegram = txtTelegram.Text.Trim();
                client.Comment = txtComment.Text.Trim();
                client.Unlimited = chkUnlimited.Checked;
                client.PurchasedSessions = (int)numSessions.Value;
                client.SubscriptionEnd = dtpEnd.Value;

                db.SaveChanges();

                string log = $"{DateTime.Now:dd.MM.yy HH:mm} | Редактирование | ID={client.Id} | {changes}";
                File.AppendAllText(_logFile, log + Environment.NewLine);
                _mainForm.UpdateNotification($"Клиент {client.LastName} (ID={client.Id}) обновлён");

                MessageBox.Show("Клиент обновлён.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var newClient = new Client
                {
                    LastName = txtLastName.Text.Trim(),
                    FirstName = txtFirstName.Text.Trim(),
                    MiddleName = txtMiddleName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Telegram = txtTelegram.Text.Trim(),
                    Comment = txtComment.Text.Trim(),
                    Unlimited = chkUnlimited.Checked,
                    PurchasedSessions = (int)numSessions.Value,
                    SubscriptionEnd = dtpEnd.Value
                };

                db.Clients.Add(newClient);
                db.SaveChanges();

                txtId.Text = newClient.Id.ToString();

                string log = $"{DateTime.Now:dd.MM.yy HH:mm} | Добавление | ID={newClient.Id} | ФИО: {newClient.LastName}";
                File.AppendAllText(_logFile, log + Environment.NewLine);
                _mainForm.UpdateNotification($"Клиент {newClient.LastName} (ID={newClient.Id}) добавлен");

                MessageBox.Show("Клиент добавлен.", "Готово", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void LoadAttendanceDates()
        {
            lstVisits.Items.Clear();
            if (_clientToEdit == null) return;
            if (!File.Exists(_logFile)) return;

            try
            {
                var lines = File.ReadAllLines(_logFile);
                var visits = lines
                    .Where(line => line.Contains("Посещение") && line.Contains($"ID={_clientToEdit.Id}"))
                    .Select(line =>
                    {
                        string datePart = line.Split('|')[0].Trim();
                        return DateTime.TryParseExact(datePart, "dd.MM.yy HH:mm", null,
                            System.Globalization.DateTimeStyles.None, out var dt)
                            ? dt.Date.ToString("dd.MM.yyyy")
                            : null;
                    })
                    .Where(s => s != null)
                    .Distinct()
                    .OrderBy(s => s);

                foreach (var visit in visits)
                    lstVisits.Items.Add(visit);
            }
            catch
            {
                MessageBox.Show("Ошибка при загрузке посещений.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddVisit_Click(object sender, EventArgs e)
        {
            if (_clientToEdit == null) return;

            var selectedDate = dtpVisit.Value.Date;
            string formatted = selectedDate.ToString("dd.MM.yy") + " 00:00";

            var lines = File.Exists(_logFile) ? File.ReadAllLines(_logFile) : Array.Empty<string>();
            if (lines.Any(l => l.StartsWith(formatted) && l.Contains($"ID={_clientToEdit.Id}") && l.Contains("Посещение")))
            {
                var result = MessageBox.Show("Посещение уже отмечено на эту дату. Добавить повторно?",
                    "Повтор посещения", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;
            }

            string log = $"{formatted} | Посещение (ручное) | ID={_clientToEdit.Id} | Добавлено вручную";
            File.AppendAllText(_logFile, log + Environment.NewLine);
            _mainForm.UpdateNotification($"Добавлено ручное посещение клиента ID={_clientToEdit.Id}");

            LoadAttendanceDates();
        }

        private void btnRemoveVisit_Click(object sender, EventArgs e)
        {
            if (_clientToEdit == null) return;
            if (lstVisits.SelectedItem == null) return;

            var selectedDate = lstVisits.SelectedItem.ToString();
            var shortDate = DateTime.ParseExact(selectedDate, "dd.MM.yyyy", null).ToString("dd.MM.yy");

            var lines = File.ReadAllLines(_logFile);
            var updated = lines
                .Where(l => !(l.StartsWith(shortDate) && l.Contains($"ID={_clientToEdit.Id}") && l.Contains("Посещение")))
                .ToArray();
            File.WriteAllLines(_logFile, updated);

            _mainForm.UpdateNotification($"Удалено посещение клиента ID={_clientToEdit.Id} на {selectedDate}");

            LoadAttendanceDates();
        }
    }
}
