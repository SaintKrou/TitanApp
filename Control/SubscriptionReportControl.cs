using System;
using System.Linq;
using System.Windows.Forms;
using TitanApp.Data;
using TitanApp.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

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
        }

        private void InitializeFilters()
        {
            dtpFrom.Value = DateTime.Today.AddMonths(-1);
            dtpTo.Value = DateTime.Today;

            clbPurchase.Items.Clear();

            try
            {
                var purchaseNames = _db.Purchases
                    .Select(p => p.Name)
                    .Distinct()
                    .OrderBy(p => p)
                    .ToArray();

                foreach (var name in purchaseNames)
                    clbPurchase.Items.Add(name, true); // Выбраны по умолчанию
            }
            catch (SqliteException)
            {
                // Ошибка доступа к таблице Purchases
            }

            cbPayment.Items.Clear();
            cbPayment.Items.Add("Все");
            cbPayment.Items.Add("Наличные");
            cbPayment.Items.Add("Безналичные");
            cbPayment.SelectedIndex = 0;

            dtpFrom.ValueChanged += (s, e) => LoadData();
            dtpTo.ValueChanged += (s, e) => LoadData();
            clbPurchase.ItemCheck += (s, e) => BeginInvoke((MethodInvoker)LoadData);
            cbPayment.SelectedIndexChanged += (s, e) => LoadData();

            LoadData();
        }

        private void LoadData()
        {
            var from = dtpFrom.Value.Date;
            var to = dtpTo.Value.Date.AddDays(1);

            try
            {
                // Чтение клиентов в память
                var clients = _db.Clients
                    .Select(c => new { c.Id, c.LastName, c.FirstName, c.MiddleName })
                    .ToDictionary(c => c.Id);

                var query = _db.SubscriptionLogs
                    .Where(l => l.AppliedAt >= from && l.AppliedAt < to);

                var selectedPurchases = clbPurchase.CheckedItems.Cast<string>().ToList();
                if (selectedPurchases.Any())
                {
                    query = query.Where(l => selectedPurchases.Contains(l.PurchaseName));
                }

                if (cbPayment.SelectedIndex > 0)
                {
                    var methodRus = cbPayment.SelectedItem?.ToString();
                    if (methodRus == "Наличные")
                        query = query.Where(l => l.PaymentMethod == PaymentMethod.Cash);
                    else if (methodRus == "Безналичные")
                        query = query.Where(l => l.PaymentMethod == PaymentMethod.NonCash);
                }

                // Выполняем запрос
                var logs = query
                    .OrderByDescending(l => l.AppliedAt)
                    .ToList(); // важно: сначала ToList, потом преобразования

                var data = logs
                    .Select(l => new
                    {
                        ID = l.ClientId,
                        Клиент = clients.TryGetValue(l.ClientId, out var c)
                            ? $"{c.LastName} {GetInitial(c.FirstName)}{GetInitial(c.MiddleName)}"
                            : l.ClientName,
                        Абонемент = l.PurchaseName,
                        Тип = l.Unlimited ? "Безлимит" : "Ограниченный",
                        Посещений = l.SessionsAdded ?? 0,
                        До = l.NewSubscriptionEnd,
                        Способ = l.PaymentMethod == PaymentMethod.Cash ? "Наличные" : "Безналичные",
                        Сумма = l.Cost,
                        Дата = l.AppliedAt
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

        private static string GetInitial(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) return "";
            return name.Trim()[0] + ".";
        }

        private void BtnExport_Click(object sender, EventArgs e)
        {
            ExportHelper.ExportDataGridViewToExcel(dgvRecords);
        }

    }
}