using System;
using System.IO;
using System.Windows.Forms;
using TitanApp;
using TitanApp.Data;
using TitanApp.Models;
using Microsoft.EntityFrameworkCore;

public partial class ApplySubscriptionControl : UserControl
{
    private MainForm _mainForm;
    private Client client;
    private readonly string _logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity.log.txt");

    public ApplySubscriptionControl(MainForm mainForm, Client client)
    {
        InitializeComponent();
        _mainForm = mainForm;
        this.client = client;

        lblClientInfo.Text = $"ID: {client.Id}, Фамилия: {client.LastName}";

        using (var context = new AppDbContext())
        {
            var purchases = context.Purchases
                                   .AsNoTracking()
                                   .ToList();

            comboBoxSubscriptions.DataSource = purchases;
            comboBoxSubscriptions.DisplayMember = "Name";
            comboBoxSubscriptions.ValueMember = "Id";
        }

        comboBoxPayment.Items.Clear();
        comboBoxPayment.Items.Add("Наличные");
        comboBoxPayment.Items.Add("Безналичные");

        comboBoxSubscriptions.SelectedIndex = -1;
        comboBoxPayment.SelectedIndex = -1;

        comboBoxSubscriptions.SelectedIndexChanged += ComboBoxSubscriptions_SelectedIndexChanged;
        comboBoxPayment.SelectedIndexChanged += ComboBoxPayment_SelectedIndexChanged;

        btnApply.Enabled = false;
        btnApplyAndMark.Enabled = false;
    }

    private Purchase? SelectedPurchase =>
        comboBoxSubscriptions.SelectedItem as Purchase;

    private PaymentMethod? SelectedPayment
    {
        get
        {
            if (comboBoxPayment.SelectedItem == null)
                return null;

            string selected = comboBoxPayment.SelectedItem!.ToString()!;
            return selected switch
            {
                "Наличные" => PaymentMethod.Cash,
                "Безналичные" => PaymentMethod.NonCash,
                _ => null
            };
        }
    }

    private static string PaymentMethodToRussian(PaymentMethod method)
    {
        return method switch
        {
            PaymentMethod.Cash => "Наличные",
            PaymentMethod.NonCash => "Безналичные",
            _ => method.ToString()
        };
    }

    private void ComboBoxSubscriptions_SelectedIndexChanged(object? sender, EventArgs e)
    {
        var purchase = SelectedPurchase;

        if (purchase != null)
        {
            lblPriceVal.Text = purchase.Cost.ToString("F2");
            lblDurationVal.Text = purchase.DurationMonths + " мес.";
            lblSessionsVal.Text = purchase.Unlimited ? "Безлимит" : purchase.SessionsCount.ToString();

            DateTime baseDate = client.SubscriptionEnd > DateTime.Now
                ? client.SubscriptionEnd
                : DateTime.Now;

            DateTime newEndDate = baseDate.AddMonths(purchase.DurationMonths);
            lblEndDateVal.Text = newEndDate.ToString("dd.MM.yyyy");
        }
        else
        {
            lblPriceVal.Text = "0.00";
            lblDurationVal.Text = "-";
            lblSessionsVal.Text = "-";
            lblEndDateVal.Text = "-";
        }

        UpdateApplyButtonState();
    }

    private void ComboBoxPayment_SelectedIndexChanged(object? sender, EventArgs e)
    {
        UpdateApplyButtonState();
    }

    private void UpdateApplyButtonState()
    {
        btnApply.Enabled = SelectedPurchase != null && SelectedPayment != null;
        btnApplyAndMark.Enabled = btnApply.Enabled;
    }

    private void btnApply_Click(object sender, EventArgs e)
    {
        ApplySubscription(false);
    }

    private void btnApplyAndMark_Click(object sender, EventArgs e)
    {
        ApplySubscription(true);
    }

    private void ApplySubscription(bool markAttendance)
    {
        var purchase = SelectedPurchase;
        var method = SelectedPayment;

        if (purchase == null || method == null)
        {
            MessageBox.Show("Выберите абонемент и способ оплаты.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DateTime baseDate = client.SubscriptionEnd > DateTime.Now
            ? client.SubscriptionEnd
            : DateTime.Now;

        DateTime oldEnd = client.SubscriptionEnd;
        int oldSessions = client.PurchasedSessions;
        bool oldUnlimited = client.Unlimited;

        client.Unlimited = purchase.Unlimited;
        if (!purchase.Unlimited)
        {
            client.PurchasedSessions += purchase.SessionsCount;
        }

        client.SubscriptionEnd = baseDate.AddMonths(purchase.DurationMonths);

        using (var context = new AppDbContext())
        {
            context.Clients.Attach(client);
            context.Entry(client).Property(c => c.SubscriptionEnd).IsModified = true;
            context.Entry(client).Property(c => c.PurchasedSessions).IsModified = true;
            context.Entry(client).Property(c => c.Unlimited).IsModified = true;
            context.SaveChanges();

            var log = new SubscriptionLogs
            {
                ClientId = client.Id,
                ClientName = client.LastName,
                PurchaseName = purchase.Name,
                Cost = purchase.Cost,
                PaymentMethod = method.Value,
                AppliedAt = DateTime.Now,
                NewSubscriptionEnd = client.SubscriptionEnd,
                SessionsAdded = purchase.Unlimited ? null : purchase.SessionsCount,
                Unlimited = purchase.Unlimited
            };

            context.SubscriptionLogs.Add(log);
            context.SaveChanges();
        }

        string logText = $"{DateTime.Now:dd.MM.yy HH:mm} | Покупка | ID={client.Id} | " +
                         $"Абонемент: «{purchase.Name}», Цена: {purchase.Cost}, Оплата: {PaymentMethodToRussian(method.Value)}";
        File.AppendAllText(_logFile, logText + Environment.NewLine);
        _mainForm.UpdateNotification($"Абонемент применён: {purchase.Name} → {client.LastName}");

        if (markAttendance)
        {
            if (purchase.Unlimited)
            {
                string log = $"{DateTime.Now:dd.MM.yy HH:mm} | Посещение | ID={client.Id} | Безлимит";
                File.AppendAllText(_logFile, log + Environment.NewLine);
                _mainForm.UpdateNotification($"Посещение (безлимит) клиента {client.LastName}");
            }
            else if (client.PurchasedSessions > 0)
            {
                int before = client.PurchasedSessions;
                client.PurchasedSessions -= 1;

                using (var context = new AppDbContext())
                {
                    context.Clients.Attach(client);
                    context.Entry(client).Property(c => c.PurchasedSessions).IsModified = true;
                    context.SaveChanges();
                }

                string log = $"{DateTime.Now:dd.MM.yy HH:mm} | Посещение | ID={client.Id} | Занятия: {before} -> {client.PurchasedSessions}";
                File.AppendAllText(_logFile, log + Environment.NewLine);
                _mainForm.UpdateNotification($"Посещение клиента: {client.LastName}");
            }
        }

        _mainForm.NotifyClientsDataChanged();
        _mainForm.ShowClientsTab();
    }
}
