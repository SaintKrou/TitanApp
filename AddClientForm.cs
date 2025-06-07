using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TitanApp.Models;

namespace TitanApp
{
    public partial class AddClientForm : Form
    {
        private readonly int? _clientId;
        public Client Client { get; private set; }

        private readonly string _logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity.log.txt");

        public AddClientForm(int? clientId = null)
        {
            InitializeComponent();
            this.ActiveControl = txtLastName;
            _clientId = clientId;

            if (_clientId.HasValue)
            {
                LoadClient(_clientId.Value);
                LoadClientLogs(_clientId.Value);
            }
            else
            {
                UpdateTitleAndId(null);
            }
        }

        private void LoadClient(int clientId)
        {
            using var db = new Data.AppDbContext();
            Client = db.Clients.FirstOrDefault(c => c.Id == clientId);
            if (Client == null) return;

            txtId.Text = Client.Id.ToString();
            UpdateTitleAndId(Client.Id);

            txtFirstName.Text = Client.FirstName;
            txtLastName.Text = Client.LastName;
            txtMiddleName.Text = Client.MiddleName;
            txtTelegram.Text = Client.Telegram;
            txtComment.Text = Client.Comment;
            numSessions.Value = Client.PurchasedSessions;
            chkUnlimited.Checked = Client.Unlimited;
        }

        private void UpdateTitleAndId(int? clientId)
        {
            if (clientId.HasValue)
            {
                this.Text = $"Клиент ID={clientId}";
                txtId.Text = clientId.ToString();
            }
            else
            {
                this.Text = "Новый клиент";
                txtId.Text = string.Empty;
            }
        }

        private void LoadClientLogs(int clientId)
        {
            if (!File.Exists(_logFile)) return;

            var lines = File.ReadAllLines(_logFile)
                .Where(line => line.Contains($"ID={clientId} "))
                .Reverse()
                .ToArray();

            lstClientLogs.Items.Clear();
            lstClientLogs.Items.AddRange(lines);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using var db = new Data.AppDbContext();

            if (_clientId.HasValue)
            {
                var client = db.Clients.Find(_clientId);
                if (client != null)
                {
                    var changes = "";

                    if (client.LastName != txtLastName.Text)
                        changes += $"Фамилия: {client.LastName} → {txtLastName.Text}; ";
                    if (client.FirstName != txtFirstName.Text)
                        changes += $"Имя: {client.FirstName} → {txtFirstName.Text}; ";
                    if (client.MiddleName != txtMiddleName.Text)
                        changes += $"Отчество: {client.MiddleName} → {txtMiddleName.Text}; ";
                    if (client.PurchasedSessions != (int)numSessions.Value)
                        changes += $"Занятия: {client.PurchasedSessions} → {(int)numSessions.Value}; ";
                    if (client.Unlimited != chkUnlimited.Checked)
                        changes += $"Безлимит: {client.Unlimited} → {chkUnlimited.Checked}; ";

                    client.FirstName = txtFirstName.Text;
                    client.LastName = txtLastName.Text;
                    client.MiddleName = txtMiddleName.Text;
                    client.Telegram = txtTelegram.Text;
                    client.Comment = txtComment.Text;
                    client.PurchasedSessions = (int)numSessions.Value;
                    client.Unlimited = chkUnlimited.Checked;

                    db.SaveChanges();
                    Client = client;

                    if (!string.IsNullOrWhiteSpace(changes))
                        LogAction($"{DateTime.Now:dd.MM.yy HH:mm} | Изменён | ID={client.Id} | {changes}");
                    else
                        LogAction($"{DateTime.Now:dd.MM.yy HH:mm} | Изменён | ID={client.Id} | Без изменений");
                }
            }
            else
            {
                var newClient = new Client
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    MiddleName = txtMiddleName.Text,
                    Telegram = txtTelegram.Text,
                    Comment = txtComment.Text,
                    PurchasedSessions = (int)numSessions.Value,
                    Unlimited = chkUnlimited.Checked
                };

                db.Clients.Add(newClient);
                db.SaveChanges();

                Client = newClient;

                LogAction($"{DateTime.Now:dd.MM.yy HH:mm} | Создан | ID={newClient.Id} | {newClient.LastName} {newClient.FirstName} | Занятия={newClient.PurchasedSessions} | Безлимит={newClient.Unlimited}");
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void LogAction(string message)
        {
            File.AppendAllText(_logFile, $"{message}{Environment.NewLine}");
        }
    }
}
