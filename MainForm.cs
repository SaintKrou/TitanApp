using System;
using System.Windows.Forms;
using TitanApp.Controls;

namespace TitanApp
{
    public partial class MainForm : Form
    {
        private ContextMenuStrip _tabContextMenu;
        private TabPage _rightClickedTab;

        public MainForm()
        {
            InitializeComponent();
            InitUI();
            InitializeContextMenu();
        }

        private void InitUI()
        {
            // Открываем список клиентов при старте
            OpenTab("Клиенты", new ClientListControl(this));
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

        private void btnClients_Click(object sender, EventArgs e)
        {
            OpenTab("Клиенты", new ClientListControl(this));
        }

        private void btnPurchases_Click(object sender, EventArgs e)
        {
            OpenTab("Покупки", new PurchaseControl(this));
        }

        private readonly string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity.log.txt");


        private void btnLogs_Click(object sender, EventArgs e)
        {
            //string logFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "activity.log.txt");
            OpenTab("Журнал", new LogControl(logFile));
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void InitializeContextMenu()
        {
            _tabContextMenu = new ContextMenuStrip();

            var closeTabItem = new ToolStripMenuItem("Закрыть");
            closeTabItem.Click += (s, e) =>
            {
                if (_rightClickedTab != null && _rightClickedTab.Text != "Клиенты")
                {
                    tabControlMain.TabPages.Remove(_rightClickedTab);
                }
            };

            var closeAllItem = new ToolStripMenuItem("Закрыть все");
            closeAllItem.Click += (s, e) =>
            {
                for (int i = tabControlMain.TabPages.Count - 1; i >= 0; i--)
                {
                    var tab = tabControlMain.TabPages[i];
                    if (tab.Text != "Клиенты")
                    {
                        tabControlMain.TabPages.RemoveAt(i);
                    }
                }
            };

            _tabContextMenu.Items.Add(closeTabItem);
            _tabContextMenu.Items.Add(closeAllItem);

            tabControlMain.MouseUp += TabControlMain_MouseUp;
        }

        private void TabControlMain_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                for (int i = 0; i < tabControlMain.TabPages.Count; i++)
                {
                    var rect = tabControlMain.GetTabRect(i);
                    if (rect.Contains(e.Location))
                    {
                        _rightClickedTab = tabControlMain.TabPages[i];
                        _tabContextMenu.Show(tabControlMain, e.Location);
                        break;
                    }
                }
            }
        }
    }
}
