using System;
using ClassLibrary;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Logger consoleLogger = new Logger();

        consoleLogger.Log("Звичайне логування.");
        consoleLogger.Error("Повідомлення про помилку.");
        consoleLogger.Warn("Попередження.");

        string logFilePath = "log.txt";
        Logger fileLogger = new FileLogger(logFilePath);
        fileLogger.Log("Логування у файл.");
        fileLogger.Error("Повідомлення про помилку у файл.");
        fileLogger.Warn("Попередження у файл.");
        Console.WriteLine("Логи записані у файл " + logFilePath);
    }
}