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
            InitializeContextMenu();
            InitUI();

            YandexDiskUploader.ShowNotification = UpdateNotification;

            _networkTimer = new System.Windows.Forms.Timer();
            _networkTimer.Interval = 5000;
            _networkTimer.Tick += NetworkTimer_Tick;
            _networkTimer.Start();
            UpdateNetworkStatus();

            _ = LoadClientsAndUploadAsync();

            btnExport.Click += BtnExport_Click;
            btnImport.Click += BtnImport_Click;
        }

        private void InitUI() => ShowClientsTab();

        public void ShowClientsTab()
        {
            foreach (TabPage page in tabControlMain.TabPages)
            {
                if (page.Text == "�������")
                {
                    tabControlMain.SelectedTab = page;
                    return;
                }
            }

            _clientListControl = new ClientListControl(this);
            OpenTab("�������", _clientListControl);
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

        private async Task LoadClientsAndUploadAsync()
        {
            using var db = new AppDbContext();
            List<Client> clients = db.Clients.ToList();

            try
            {
                string json = JsonSerializer.Serialize(clients, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(jsonFile, json);
                UpdateNotification("������� ��������� � ����.");

                bool uploaded = await YandexDiskUploader.UploadFileAsync(jsonFile, "clients.json");
                UpdateNotification(uploaded ? "������ ��������� �� ������.����" : "������ �������� � ������.����");
            }
            catch (Exception ex)
            {
                UpdateNotification($"������ ������������/��������: {ex.Message}");
            }
        }

        private void BtnExport_Click(object? sender, EventArgs e)
        {
            try
            {
                using var db = new AppDbContext();
                var clients = db.Clients.ToList();
                var json = JsonSerializer.Serialize(clients, new JsonSerializerOptions { WriteIndented = true });
                var datedFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"clients_{DateTime.Now:yyyyMMdd_HHmmss}.json");
                File.WriteAllText(datedFile, json);

                string log = $"{DateTime.Now:dd.MM.yy HH:mm} | ������� | ID=- | ������� �������� � ���� {Path.GetFileName(datedFile)}";
                File.AppendAllText(logFile, log + Environment.NewLine);
                UpdateNotification("���� �������� ������������� � �����.");
            }
            catch (Exception ex)
            {
                UpdateNotification($"������ ��������: {ex.Message}");
            }
        }

        private void BtnImport_Click(object? sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "JSON ����� (*.json)|*.json",
                Title = "�������� ���� ��������"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var json = File.ReadAllText(ofd.FileName);
                    var clients = JsonSerializer.Deserialize<List<Client>>(json);
                    if (clients != null)
                    {
                        using var db = new AppDbContext();
                        db.Clients.RemoveRange(db.Clients);
                        db.Clients.AddRange(clients);
                        db.SaveChanges();

                        string log = $"{DateTime.Now:dd.MM.yy HH:mm} | ������ | ID=- | ������ �������� �� ����� {Path.GetFileName(ofd.FileName)}";
                        File.AppendAllText(logFile, log + Environment.NewLine);

                        UpdateNotification("������ �������� �������� �������.");
                        ClientsDataChanged?.Invoke(this, EventArgs.Empty);
                    }
                }
                catch (Exception ex)
                {
                    UpdateNotification($"������ �������: {ex.Message}");
                }
            }
        }

        private void InitializeContextMenu()
        {
            _tabContextMenu = new ContextMenuStrip();

            var closeTabItem = new ToolStripMenuItem("�������");
            closeTabItem.Click += (s, e) =>
            {
                if (_rightClickedTab != null && _rightClickedTab.Text != "�������")
                    tabControlMain.TabPages.Remove(_rightClickedTab);
            };

            var closeAllItem = new ToolStripMenuItem("������� ���");
            closeAllItem.Click += (s, e) =>
            {
                for (int i = tabControlMain.TabPages.Count - 1; i >= 0; i--)
                {
                    var tab = tabControlMain.TabPages[i];
                    if (tab.Text != "�������")
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
                Invoke((MethodInvoker)(() => lblNetworkStatus.Text = $"����������: {quality}"));
            else
                lblNetworkStatus.Text = $"����������: {quality}";
        }

        private async Task<string> GetConnectionQualityAsync()
        {
            try
            {
                using var ping = new Ping();
                var reply = await ping.SendPingAsync("8.8.8.8", 1000);
                if (reply.Status != IPStatus.Success) return "�����������";

                long rtt = reply.RoundtripTime;
                return rtt < 80 ? "��������"
                     : rtt < 200 ? "�������"
                     : rtt < 300 ? "�������"
                     : rtt < 400 ? "���� ��������"
                     : "������";
            }
            catch { return "�����������"; }
        }

        public void UpdateNotification(string message)
        {
            if (InvokeRequired)
                Invoke((MethodInvoker)(() => lblNotifications.Text = message));
            else
                lblNotifications.Text = message;
        }

        public void UpdateHostStatus(string message) { }

        public void AddLog(string message)
        {
            try
            {
                string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}{Environment.NewLine}";
                File.AppendAllText(logFile, entry);
            }
            catch (Exception ex)
            {
                UpdateNotification($"������ ��� ������ ����: {ex.Message}");
            }
        }

        public void NotifyClientsDataChanged()
        {
            _ = LoadClientsAndUploadAsync();
            ClientsDataChanged?.Invoke(this, EventArgs.Empty);
        }

        private void btnClients_Click(object sender, EventArgs e) => ShowClientsTab();
        private void btnPurchases_Click(object sender, EventArgs e) => OpenTab("����������", new PurchaseControl(this));
        private void btnLogs_Click(object sender, EventArgs e) => OpenTab("������", new LogControl(logFile));
        private void btnReport_Click(object sender, EventArgs e) => OpenTab("����� �� �����������", new SubscriptionReportControl());
        private void btnExit_Click(object sender, EventArgs e) => Close();
    }
}
