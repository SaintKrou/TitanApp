using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using TitanApp;
using TitanApp.Data;
using TitanApp.Models;
using Microsoft.EntityFrameworkCore;

public partial class ApplySubscriptionControl : UserControl
{
    private MainForm _mainForm;
    private Client client;

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

        // Заполняем comboBoxPayment русскими значениями
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

    // Получаем PaymentMethod enum из выбранного в comboBox русского значения
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

    // Для отображения enum PaymentMethod как строки на русском
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

        if (purchase.Unlimited)
        {
            client.Unlimited = true;
        }
        else
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
                PaymentMethod = method.Value,  // сохраняем enum, как есть
                AppliedAt = DateTime.Now,
                NewSubscriptionEnd = client.SubscriptionEnd,
                SessionsAdded = purchase.Unlimited ? null : purchase.SessionsCount,
                Unlimited = purchase.Unlimited
            };

            context.SubscriptionLogs.Add(log);
            context.SaveChanges();
        }

        string changes = "";
        if (oldEnd != client.SubscriptionEnd)
            changes += $"Окончание: \"{oldEnd:dd.MM.yyyy}\" → \"{client.SubscriptionEnd:dd.MM.yyyy}\"; ";
        if (oldUnlimited != client.Unlimited)
            changes += $"Безлимит: \"{oldUnlimited}\" → \"{client.Unlimited}\"; ";
        if (oldSessions != client.PurchasedSessions)
            changes += $"Сеансы: \"{oldSessions}\" → \"{client.PurchasedSessions}\"; ";

        if (!string.IsNullOrWhiteSpace(changes))
        {
            string logText = $"Применён абонемент: ID {client.Id}, {client.LastName}. " +
                             $"Абонемент: \"{purchase.Name}\" за {purchase.Cost} руб. Изменения: {changes}";

            _mainForm.AddLog(logText);
            _mainForm.UpdateNotification($"Абонемент «{purchase.Name}» применён клиенту {client.LastName} (ID {client.Id})");

            string fileLog = $"{DateTime.Now:yyyy-MM-dd HH:mm} | Покупка | ID={client.Id} | {client.LastName} | " +
                             $"Абонемент: \"{purchase.Name}\" | Оплата: {PaymentMethodToRussian(method.Value)} | Цена: {purchase.Cost} руб.";
            File.AppendAllText("log.txt", fileLog + Environment.NewLine);

            string reportLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "subscription.log.txt");
            string reportLog = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | ClientID={client.Id} | LastName={client.LastName} | " +
                               $"Purchase={purchase.Name} | Price={purchase.Cost} | Payment={PaymentMethodToRussian(method.Value)} | " +
                               $"Sessions={(purchase.Unlimited ? "∞" : purchase.SessionsCount.ToString())} | " +
                               $"Duration={purchase.DurationMonths}мес | NewEnd={client.SubscriptionEnd:yyyy-MM-dd}";
            File.AppendAllText(reportLogPath, reportLog + Environment.NewLine);
        }

        if (markAttendance)
        {
            if (purchase.Unlimited)
            {
                File.AppendAllText("log.txt", $"{DateTime.Now:yyyy-MM-dd HH:mm} | Посещение | ID={client.Id} | Безлимит\n");
            }
            else if (client.PurchasedSessions > 0)
            {
                client.PurchasedSessions -= 1;

                using (var context = new AppDbContext())
                {
                    context.Clients.Attach(client);
                    context.Entry(client).Property(c => c.PurchasedSessions).IsModified = true;
                    context.SaveChanges();
                }

                File.AppendAllText("log.txt",
                    $"{DateTime.Now:yyyy-MM-dd HH:mm} | Посещение | ID={client.Id} | Осталось занятий: {client.PurchasedSessions}\n");
            }

            _mainForm.UpdateNotification("Подписка применена и посещение отмечено");
        }

        _mainForm.NotifyClientsDataChanged();
        _mainForm.ShowClientsTab();
    }
}
