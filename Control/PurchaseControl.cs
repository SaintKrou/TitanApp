using System;
using System.Linq;
using System.Windows.Forms;
using TitanApp.Data;
using TitanApp.Models;

namespace TitanApp.Controls
{
    public partial class PurchaseControl : UserControl
    {
        private readonly MainForm _mainForm;

        public PurchaseControl(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            LoadPurchases();
        }

        private void LoadPurchases()
        {
            using var db = new AppDbContext();
            var purchases = db.Purchases.ToList();

            dataGridView1.DataSource = purchases.Select(p => new
            {
                Название = p.Name,
                Посещений = p.Unlimited ? "Безлимит" : p.SessionsCount.ToString(),
                Длительность = $"{p.DurationMonths} мес.",
                Цена = p.Cost.ToString("C")
            }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Добавление покупки пока не реализовано.");
            // TODO: заменить на вызов формы AddPurchaseControl
            // _mainForm.OpenTab("Добавить покупку", new AddPurchaseControl(_mainForm));
        }
    }
}
