using System;
using System.Linq;
using System.Windows.Forms;
using TitanApp.Data;
using TitanApp.Models;
using Microsoft.Data.Sqlite;

namespace TitanApp.Controls
{
    public partial class SubscriptionReportControl : UserControl
    {
        private readonly AppDbContext _db;

        public SubscriptionReportControl()
        {
            InitializeComponent();
            _db = new AppDbContext();
            InitializeFilters();
            LoadData();
        }

        private void InitializeFilters()
        {
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;

            cbPurchase.Items.Clear();
            cbPurchase.Items.Add("Все");

            try
            {
                var purchaseNames = _db.Purchases
                    .Select(p => p.Name)
                    .Distinct()
                    .OrderBy(p => p)
                    .ToArray();

                cbPurchase.Items.AddRange(purchaseNames);
            }
            catch (SqliteException)
            {
                // Таблица Purchases не найдена — оставим "Все"
            }

            cbPurchase.SelectedIndex = 0;

            // Заполняем фильтр способа оплаты вручную
            cbPayment.Items.Clear();
            cbPayment.Items.Add("Все");
            cbPayment.Items.Add("Наличные");
            cbPayment.Items.Add("Безналичные");
            cbPayment.SelectedIndex = 0;

            dtpFrom.ValueChanged += (s, e) => LoadData();
            dtpTo.ValueChanged += (s, e) => LoadData();
            cbPurchase.SelectedIndexChanged += (s, e) => LoadData();
            cbPayment.SelectedIndexChanged += (s, e) => LoadData();
        }

        private void LoadData()
        {
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date.AddDays(1);

            try
            {
                var query = _db.SubscriptionLogs
                    .Where(l => l.AppliedAt >= from && l.AppliedAt < to);

                if (cbPurchase.SelectedIndex > 0)
                {
                    var title = cbPurchase.SelectedItem?.ToString();
                    query = query.Where(l => l.PurchaseName == title);
                }

                if (cbPayment.SelectedIndex > 0)
                {
                    var methodRus = cbPayment.SelectedItem?.ToString();

                    if (methodRus == "Наличные")
                        query = query.Where(l => l.PaymentMethod == PaymentMethod.Cash);
                    else if (methodRus == "Безналичные")
                        query = query.Where(l => l.PaymentMethod == PaymentMethod.NonCash);
                }

                var data = query
                    .OrderByDescending(l => l.AppliedAt)
                    .Select(l => new
                    {
                        Дата = l.AppliedAt,
                        Клиент = l.ClientName,
                        Абонемент = l.PurchaseName,
                        Тип = l.Unlimited ? "Безлимит" : "Ограниченный",
                        Посещений = l.SessionsAdded ?? 0,
                        До = l.NewSubscriptionEnd,
                        Способ = l.PaymentMethod == PaymentMethod.Cash ? "Наличные" : "Безналичные",
                        Сумма = l.Cost
                    })
                    .ToList();

                dgvRecords.DataSource = data;

                var total = data.Sum(d => d.Сумма);
                lblSummary.Text = $"Всего записей: {data.Count} | Общая сумма: {total:N0} ₽";
            }
            catch (SqliteException)
            {
                dgvRecords.DataSource = null;
                lblSummary.Text = "Ошибка: таблица SubscriptionLogs не найдена или не готова.";
            }
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Экспорт временно отключён (ExportHelper не реализован).", "Экспорт", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
