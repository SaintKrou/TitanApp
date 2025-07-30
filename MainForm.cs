using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitanApp.Controls;
using TitanApp.Data;
using TitanApp.Models;
using TitanApp.Services;

namespace TitanApp
{
    public partial class MainForm : Form
    {
        private ContextMenuStrip? _tabContextMenu;
        private TabPage? _rightClickedTab;
        private System.Windows.Forms.Timer _networkTimer;

        private readonly string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity.log.txt");
        private readonly string jsonFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "clients.json");
        private ClientListControl? _clientListControl;

        public event EventHandler ClientsDataChanged = delegate { };

        public MainForm()
        {
            InitializeComponent();
            InitUI();
            InitializeContextMenu();

            _networkTimer = new System.Windows.Forms.Timer();
            _networkTimer.Interval = 5000;
            _networkTimer.Tick += NetworkTimer_Tick;
            _networkTimer.Start();
            UpdateNetworkStatus();

            _ = LoadClientsAndUploadAsync();
        }

        private async Task LoadClientsAndUploadAsync()
        {
            using var db = new AppDbContext();
            List<Client> clients = db.Clients.ToList();

            try
            {
                string json = JsonSerializer.Serialize(clients, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonFile, json);
                UpdateNotification("Клиенты сохранены в файл.");

                bool uploaded = await YandexDiskUploader.UploadFileAsync(jsonFile, "clients.json");
                UpdateNotification(uploaded ? "Данные загружены на Яндекс.Диск" : "Ошибка загрузки в Яндекс.Диск");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка сериализации/загрузки: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InitUI() => ShowClientsTab();

        public void ShowClientsTab()
        {
            foreach (TabPage page in tabControlMain.TabPages)
            {
                if (page.Text == "Клиенты")
                {
                    tabControlMain.SelectedTab = page;
                    return;
                }
            }

            _clientListControl = new ClientListControl(this);
            OpenTab("Клиенты", _clientListControl);
        }

        public void OpenTab(string title, UserControl control)
        {
            foreach (TabPage page in tabControlMain.TabPages)
            {
                if (page.Text == title)
                {
                    tabControlMain.SelectedTab = page;
                    return;
                }
            }

            var tabPage = new TabPage(title);
            control.Dock = DockStyle.Fill;
            tabPage.Controls.Add(control);
            tabControlMain.TabPages.Add(tabPage);
            tabControlMain.SelectedTab = tabPage;
        }

        private void btnClients_Click(object? sender, EventArgs e) => ShowClientsTab();
        private void btnPurchases_Click(object? sender, EventArgs e) => OpenTab("Абонементы", new PurchaseControl(this));
        private void btnLogs_Click(object? sender, EventArgs e) => OpenTab("Журнал", new LogControl(logFile));
        private void btnReport_Click(object? sender, EventArgs e) => OpenTab("Отчёт по абонементам", new SubscriptionReportControl());
        private void btnExit_Click(object? sender, EventArgs e) => Close();

        private void InitializeContextMenu()
        {
            _tabContextMenu = new ContextMenuStrip();

            var closeTabItem = new ToolStripMenuItem("Закрыть");
            closeTabItem.Click += (s, e) =>
            {
                if (_rightClickedTab != null && _rightClickedTab.Text != "Клиенты")
                    tabControlMain.TabPages.Remove(_rightClickedTab);
            };

            var closeAllItem = new ToolStripMenuItem("Закрыть все");
            closeAllItem.Click += (s, e) =>
            {
                for (int i = tabControlMain.TabPages.Count - 1; i >= 0; i--)
                {
                    var tab = tabControlMain.TabPages[i];
                    if (tab.Text != "Клиенты")
                        tabControlMain.TabPages.RemoveAt(i);
                }
            };

            _tabContextMenu.Items.Add(closeTabItem);
            _tabContextMenu.Items.Add(closeAllItem);
            tabControlMain.MouseUp += TabControlMain_MouseUp;
        }

        private void TabControlMain_MouseUp(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabControlMain.TabPages.Count; i++)
                {
                    var rect = tabControlMain.GetTabRect(i);
                    if (rect.Contains(e.Location))
                    {
                        _rightClickedTab = tabControlMain.TabPages[i];
                        _tabContextMenu?.Show(tabControlMain, e.Location);
                        break;
                    }
                }
            }
        }

        private void NetworkTimer_Tick(object? sender, EventArgs e) => UpdateNetworkStatus();

        private async void UpdateNetworkStatus()
        {
            string quality = await GetConnectionQualityAsync();
            if (InvokeRequired)
                Invoke((MethodInvoker)(() => lblNetworkStatus.Text = $"Соединение: {quality}"));
            else
                lblNetworkStatus.Text = $"Соединение: {quality}";
        }

        private async Task<string> GetConnectionQualityAsync()
        {
            try
            {
                using var ping = new Ping();
                var reply = await ping.SendPingAsync("8.8.8.8", 1000);
                if (reply.Status != IPStatus.Success) return "Отсутствует";

                long rtt = reply.RoundtripTime;
                return rtt < 80 ? "Отличное"
                     : rtt < 200 ? "Хорошее"
                     : rtt < 300 ? "Среднее"
                     : rtt < 400 ? "Ниже среднего"
                     : "Плохое";
            }
            catch { return "Отсутствует"; }
        }

        public void UpdateNotification(string message)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)(() => lblNotifications.Text = message));
            else
                lblNotifications.Text = message;
        }

        public void UpdateHostStatus(string message) { }
        public void UpdateTelegramStatus(string message) { }

        public void AddLog(string message)
        {
            try
            {
                string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}{Environment.NewLine}";
                File.AppendAllText(logFile, entry);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при записи лога: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void NotifyClientsDataChanged()
        {
            _ = LoadClientsAndUploadAsync();
            ClientsDataChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
