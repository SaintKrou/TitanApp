using System;
using System.Windows.Forms;
using TitanApp.Data;
using TitanApp.Models;

namespace TitanApp.Controls
{
    public partial class ApplySubscriptionControl : UserControl
    {
        private readonly MainForm _mainForm;
        private readonly Client _client;

        public ApplySubscriptionControl(MainForm mainForm, Client client)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _client = client;
            InitForm();
        }

        private void InitForm()
        {
            lblClientName.Text = $"{_client.LastName} {_client.FirstName} {_client.MiddleName}";
            txtCurrentSessions.Text = _client.PurchasedSessions.ToString();
            dtpNewEndDate.Value = _client.SubscriptionEnd == default ? DateTime.Today : _client.SubscriptionEnd;
            chkUnlimited.Checked = _client.Unlimited;
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            using var db = new AppDbContext();
            var client = db.Clients.Find(_client.Id);

            if (client != null)
            {
                client.PurchasedSessions += (int)numAddSessions.Value;
                client.SubscriptionEnd = dtpNewEndDate.Value.Date;
                client.Unlimited = chkUnlimited.Checked;
                db.SaveChanges();
            }

            MessageBox.Show("Абонемент применён.", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _mainForm.OpenTab("Клиенты", new ClientListControl(_mainForm));
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _mainForm.OpenTab("Клиенты", new ClientListControl(_mainForm));
        }
    }
}
