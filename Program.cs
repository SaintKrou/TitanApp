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
            // Настройка визуальных стилей и конфигурации приложения
            ApplicationConfiguration.Initialize();

            // Создание базы данных и таблиц при первом запуске
            using (var db = new AppDbContext())
            {
                db.Database.EnsureCreated();
            }

            // Запуск главной формы
            Application.Run(new MainForm());
        }
    }
}
