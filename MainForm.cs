using System;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using TitanApp.Controls;
using TitanApp.Models;

namespace TitanApp
{
    public partial class MainForm : Form
    {
        private ContextMenuStrip? _tabContextMenu;
        private TabPage? _rightClickedTab;
        private System.Windows.Forms.Timer _networkTimer;

        private readonly string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity.log.txt");
        private ClientListControl? _clientListControl;

        // �������������� ������� ������ ���������, ����� �������� NullReferenceException
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
        }

        private void InitUI()
        {
            ShowClientsTab();
        }

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

        private void btnClients_Click(object? sender, EventArgs e)
        {
            ShowClientsTab();
        }

        private void btnPurchases_Click(object? sender, EventArgs e)
        {
            OpenTab("�������", new PurchaseControl(this));
        }

        private void btnLogs_Click(object? sender, EventArgs e)
        {
            OpenTab("������", new LogControl(logFile));
        }

        private void btnReport_Click(object? sender, EventArgs e)
        {
            OpenTab("����� �� �����������", new SubscriptionReportControl());
        }

        private void btnExit_Click(object? sender, EventArgs e)
        {
            Close();
        }

        private void InitializeContextMenu()
        {
            _tabContextMenu = new ContextMenuStrip();

            var closeTabItem = new ToolStripMenuItem("�������");
            closeTabItem.Click += (s, e) =>
            {
                if (_rightClickedTab != null && _rightClickedTab.Text != "�������")
                {
                    tabControlMain.TabPages.Remove(_rightClickedTab);
                }
            };

            var closeAllItem = new ToolStripMenuItem("������� ���");
            closeAllItem.Click += (s, e) =>
            {
                for (int i = tabControlMain.TabPages.Count - 1; i >= 0; i--)
                {
                    var tab = tabControlMain.TabPages[i];
                    if (tab.Text != "�������")
                    {
                        tabControlMain.TabPages.RemoveAt(i);
                    }
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

        private void NetworkTimer_Tick(object? sender, EventArgs e)
        {
            UpdateNetworkStatus();
        }

        private async void UpdateNetworkStatus()
        {
            string quality = await GetConnectionQualityAsync();
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => lblNetworkStatus.Text = $"����: {quality}"));
            }
            else
            {
                lblNetworkStatus.Text = $"����: {quality}";
            }
        }

        private async Task<string> GetConnectionQualityAsync()
        {
            try
            {
                using (var ping = new Ping())
                {
                    var reply = await ping.SendPingAsync("8.8.8.8", 1000);
                    if (reply.Status == IPStatus.Success)
                    {
                        long rtt = reply.RoundtripTime;
                        if (rtt < 80) return "��������";
                        else if (rtt < 200) return "�������";
                        else if (rtt < 300) return "�������";
                        else if (rtt < 400) return "���� ��������";
                        else return "������";
                    }
                    else
                    {
                        return "�����������";
                    }
                }
            }
            catch
            {
                return "�����������";
            }
        }

        public void UpdateNotification(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke((MethodInvoker)(() => lblNotifications.Text = message));
            }
            else
            {
                lblNotifications.Text = message;
            }
        }

        public void AddLog(string message)
        {
            try
            {
                string entry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {message}{Environment.NewLine}";
                File.AppendAllText(logFile, entry);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ������ ����: {ex.Message}", "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // ����� ��� ����������� ����������� � ��������� ������ ��������
        public void NotifyClientsDataChanged()
        {
            ClientsDataChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}