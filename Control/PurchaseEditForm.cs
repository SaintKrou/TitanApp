using System;
using System.Windows.Forms;
using TitanApp.Models;
using TitanApp.Data;

namespace TitanApp.Controls
{
    public partial class PurchaseEditForm : Form
    {
        public Purchase Purchase { get; private set; }
        private bool _isNewPurchase;

        public PurchaseEditForm(Purchase? purchase = null)
        {
            InitializeComponent();

            if (purchase != null)
            {
                Purchase = new Purchase
                {
                    Id = purchase.Id,
                    Name = purchase.Name,
                    SessionsCount = purchase.SessionsCount,
                    Unlimited = purchase.Unlimited,
                    DurationMonths = purchase.DurationMonths,
                    Cost = purchase.Cost
                };
                _isNewPurchase = false;
            }
            else
            {
                Purchase = new Purchase();
                _isNewPurchase = true;
            }

            InitUI();
        }

        private void InitUI()
        {
            txtName.Text = Purchase.Name;

            nudSessions.Minimum = 0;
            nudSessions.Maximum = 10000;
            nudSessions.Value = Purchase.SessionsCount;

            chkUnlimited.Checked = Purchase.Unlimited;
            nudSessions.Enabled = !chkUnlimited.Checked;

            nudMonths.Minimum = 1;
            nudMonths.Maximum = 60;
            nudMonths.Value = Purchase.DurationMonths < nudMonths.Minimum ? nudMonths.Minimum : Purchase.DurationMonths;

            nudCost.Minimum = 0;
            nudCost.Maximum = 1000000;
            nudCost.Value = Purchase.Cost;

            chkUnlimited.CheckedChanged += (s, e) =>
            {
                nudSessions.Enabled = !chkUnlimited.Checked;
            };
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Введите название абонемента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Purchase.Name = txtName.Text.Trim();
            Purchase.SessionsCount = (int)nudSessions.Value;
            Purchase.Unlimited = chkUnlimited.Checked;
            Purchase.DurationMonths = (int)nudMonths.Value;
            Purchase.Cost = nudCost.Value;

            // Сохраняем в БД
            using (var context = new AppDbContext())
            {
                if (_isNewPurchase)
                {
                    context.Purchases.Add(Purchase);
                }
                else
                {
                    context.Purchases.Update(Purchase);
                }
                context.SaveChanges();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
