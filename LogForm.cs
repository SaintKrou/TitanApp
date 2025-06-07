using System;
using System.IO;
using System.Windows.Forms;

namespace TitanApp
{
    public partial class LogForm : Form
    {
        public LogForm(string logFilePath)
        {
            InitializeComponent();
            if (File.Exists(logFilePath))
                txtLog.Text = File.ReadAllText(logFilePath);
            else
                txtLog.Text = "(Лог-файл не найден)";
        }
    }
}