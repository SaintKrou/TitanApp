using System;
using System.IO;

namespace TitanApp.Utils
{
    public static class Logger
    {
        private static readonly string LogFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "logs.txt");

        public static void LogEvent(string message)
        {
            var timestamp = DateTime.Now.ToString("dd.MM.yyyy HH:mm");
            var fullMessage = $"{timestamp} | {message}";
            File.AppendAllText(LogFilePath, fullMessage + Environment.NewLine);
        }
    }
}