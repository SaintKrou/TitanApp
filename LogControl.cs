using System;
using System.IO;
using System.Windows.Forms;

namespace TitanApp.Controls
{
    public partial class LogControl : UserControl
    {
        private readonly string _logPath;

        public LogControl(string logPath)
        {
            InitializeComponent();
            _logPath = logPath;
            LoadLog();
        }

        private void LoadLog()
        {
            if (File.Exists(_logPath))
                txtLog.Text = File.ReadAllText(_logPath);
            else
                txtLog.Text = "Лог-файл не найден.";
        }
    }
}
