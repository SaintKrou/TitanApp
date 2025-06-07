using System;
using System.Linq;
using System.Windows.Forms;
using TitanApp.Data;
using TitanApp.Models;

namespace TitanApp
{
    public partial class PurchaseForm : Form
    {
        private readonly AppDbContext _db;

        public PurchaseForm()
        {
            InitializeComponent();
            _db = new AppDbContext();
            LoadPurchases();
        }

        private void LoadPurchases()
        {
            var list = _db.Purchases.Select(p => new
            {
                p.Id,
                p.Name,
                p.SessionsCount,
                p.Unlimited,
                p.DurationMonths,
                p.Cost
            }).ToList();

            gridPurchases.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var addForm = new PurchaseAddForm();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                _db.Purchases.Add(addForm.Purchase);
                _db.SaveChanges();
                LoadPurchases();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridPurchases.CurrentRow == null)
            {
                MessageBox.Show("Выберите абонемент для редактирования.");
                return;
            }

            int id = (int)gridPurchases.CurrentRow.Cells["Id"].Value;
            var purchase = _db.Purchases.Find(id);
            if (purchase != null)
            {
                using var editForm = new PurchaseAddForm(purchase);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    _db.Purchases.Update(editForm.Purchase);
                    _db.SaveChanges();
                    LoadPurchases();
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridPurchases.CurrentRow == null)
            {
                MessageBox.Show("Выберите абонемент для удаления.");
                return;
            }

            int id = (int)gridPurchases.CurrentRow.Cells["Id"].Value;
            var purchase = _db.Purchases.Find(id);
            if (purchase != null)
            {
                var confirm = MessageBox.Show($"Удалить абонемент '{purchase.Name}'?", "Подтвердите удаление", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    _db.Purchases.Remove(purchase);
                    _db.SaveChanges();
                    LoadPurchases();
                }
            }
        }
    }
}
