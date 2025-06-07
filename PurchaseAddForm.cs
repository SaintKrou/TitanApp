using System;
using System.Windows.Forms;
using TitanApp.Models;

namespace TitanApp
{
    public partial class PurchaseAddForm : Form
    {
        public Purchase Purchase { get; private set; }

        public PurchaseAddForm(Purchase? purchase = null)
        {
            InitializeComponent();

            if (purchase != null)
            {
                Purchase = purchase;
                txtName.Text = purchase.Name;
                numSessionsCount.Value = purchase.SessionsCount;
                chkUnlimited.Checked = purchase.Unlimited;
                numDurationMonths.Value = purchase.DurationMonths;
                numCost.Value = purchase.Cost;
            }
            else
            {
                Purchase = new Purchase();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Purchase.Name = txtName.Text;
            Purchase.SessionsCount = (int)numSessionsCount.Value;
            Purchase.Unlimited = chkUnlimited.Checked;
            Purchase.DurationMonths = (int)numDurationMonths.Value;
            Purchase.Cost = numCost.Value;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
