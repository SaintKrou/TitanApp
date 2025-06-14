using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using TitanApp.Data;
using TitanApp.Models;
using Microsoft.EntityFrameworkCore;


namespace TitanApp.Controls
{
    public partial class PurchaseControl : UserControl
    {
        private readonly MainForm _mainForm;

        public PurchaseControl(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;

            // Выделяем всю строку по клику – пользователю понятнее
            dgvPurchases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPurchases.MultiSelect = false;

            LoadData();
            dgvPurchases.ClearSelection();
        }

        // ====================
        // Загрузка/перезагрузка данных
        // ====================
        private void LoadData()
        {
            using var db = new AppDbContext();

            dgvPurchases.DataSource = db.Purchases
                .AsNoTracking()
                .Select(p => new
                {
                    p.Id,
                    Название = p.Name,
                    Занятий = p.Unlimited ? "∞" : p.SessionsCount.ToString(),
                    Безлимит = p.Unlimited,
                    Месяцев = p.Unlimited ? "∞" : p.DurationMonths.ToString(),
                    Цена = p.Cost.ToString("F2")
                })
                .ToList();

            dgvPurchases.Columns["Id"].Visible = false;
            dgvPurchases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPurchases.ClearSelection();
        }

        // ====================
        // Добавление
        // ====================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new PurchaseEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                _mainForm.UpdateNotification("Добавлен новый абонемент.");
            }
        }

        // ====================
        // Редактирование
        // ====================
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvPurchases.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите абонемент для редактирования.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = (int)dgvPurchases.CurrentRow.Cells["Id"].Value;

            using var db = new AppDbContext();
            var purchase = db.Purchases.Find(id);
            if (purchase == null) return;

            using var form = new PurchaseEditForm(purchase);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadData();
                _mainForm.UpdateNotification("Абонемент отредактирован.");
            }
        }

        // ====================
        // Удаление
        // ====================
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvPurchases.CurrentRow == null)
            {
                MessageBox.Show("Пожалуйста, выберите абонемент для удаления.",
                                "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Удалить выбранный абонемент?", "Подтверждение",
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            int id = (int)dgvPurchases.CurrentRow.Cells["Id"].Value;

            using var db = new AppDbContext();
            var purchase = db.Purchases.Find(id);
            if (purchase == null) return;

            db.Purchases.Remove(purchase);
            db.SaveChanges();

            LoadData();
            _mainForm.UpdateNotification("Абонемент удалён.");
        }

        // ====================
        // Вспомогательный метод – может понадобиться во внешних отчётах
        // ====================
        public static string FormatSubscriptionEndDate(DateTime date) =>
            date.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
    }
}
