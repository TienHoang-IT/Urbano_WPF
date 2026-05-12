using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Urbano_WPF.Helper
{
    public static class Logger
    {
        public static void WriteLine(string message)
        {
            try
            {
                string directory = AppDomain.CurrentDomain.BaseDirectory;
                string logDirectory = Path.Combine(directory, "log");
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }
                string filePath = Path.Combine(logDirectory, $"{DateTime.Now:dd_MM_yyyy}.txt");

                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] {message}{Environment.NewLine}";

                File.AppendAllText(filePath, logEntry, Encoding.UTF8);
            }
            catch { }
        }
    }
}
