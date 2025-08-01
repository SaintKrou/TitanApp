﻿using System;
using System.Globalization;
using System.IO;
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
        private readonly string _logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity.log.txt");

        public PurchaseControl(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;

            dgvPurchases.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPurchases.MultiSelect = false;

            LoadData();
            dgvPurchases.ClearSelection();
        }

        private void LoadData()
        {
            using var db = new AppDbContext();

            dgvPurchases.DataSource = db.Purchases
                .AsNoTracking()
                .Select(p => new
                {
                    p.Id,
                    Название = p.Name,
                    Занятий = p.SessionsCount.ToString(),
                    Безлимит = p.Unlimited,
                    Месяцев = p.DurationMonths.ToString(),
                    Цена = p.Cost.ToString("F2")
                })
                .ToList();

            dgvPurchases.Columns["Id"].Visible = false;
            dgvPurchases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvPurchases.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using var form = new PurchaseEditForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                var purchase = form.Purchase;
                string log = $"{DateTime.Now:dd.MM.yy HH:mm} | Добавление абонемента | ID={purchase.Id} | Название: \"{purchase.Name}\", Цена: {purchase.Cost}, Занятий: {(purchase.Unlimited ? "∞" : purchase.SessionsCount.ToString())}";
                File.AppendAllText(_logFile, log + Environment.NewLine);

                LoadData();
                _mainForm.UpdateNotification("Добавлен новый абонемент.");
            }
        }

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

            string oldName = purchase.Name;

            using var form = new PurchaseEditForm(purchase);
            if (form.ShowDialog() == DialogResult.OK)
            {
                string newName = form.Purchase.Name;
                string log = $"{DateTime.Now:dd.MM.yy HH:mm} | Редактирование абонемента | ID={purchase.Id} | Название: \"{oldName}\" → \"{newName}\"";
                File.AppendAllText(_logFile, log + Environment.NewLine);

                LoadData();
                _mainForm.UpdateNotification("Абонемент отредактирован.");
            }
        }

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

            string log = $"{DateTime.Now:dd.MM.yy HH:mm} | Удаление абонемента | ID={purchase.Id} | Название: \"{purchase.Name}\"";
            File.AppendAllText(_logFile, log + Environment.NewLine);

            db.Purchases.Remove(purchase);
            db.SaveChanges();

            LoadData();
            _mainForm.UpdateNotification("Абонемент удалён.");
        }

        public static string FormatSubscriptionEndDate(DateTime date) =>
            date.ToString("dd.MM.yyyy", CultureInfo.InvariantCulture);
    }
}
