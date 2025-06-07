using System;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using TitanApp.Data;

namespace TitanApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // ��������� ���������� ������ � ������������ ����������
            ApplicationConfiguration.Initialize();

            // �������� ���� ������ � ������ ��� ������ �������
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }

            // ������ ������� �����
            Application.Run(new MainForm());
        }
    }
}
