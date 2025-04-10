using System;
using System.IO;

namespace ClassLibrary
{
    public class Logger
    {
        public virtual void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[INFO] " + message);
            Console.ResetColor();
        }
        public virtual void Error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[ERROR] " + message);
            Console.ResetColor();
        }
        public virtual void Warn(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("[WARNING] " + message);
            Console.ResetColor();
        }
    }

    public class FileWriter
    {
        private string filePath;
        public FileWriter(string filePath)
        {
            this.filePath = filePath;
        }
        public void WriteLine(string text)
        {
            File.AppendAllText(filePath, text + Environment.NewLine);
        }
    }

    public class FileLogger : Logger
    {
        private FileWriter fileWriter;
        public FileLogger(string filePath)
        {
            fileWriter = new FileWriter(filePath);
        }
        public override void Log(string message)
        {
            fileWriter.WriteLine("[INFO] " + message);
        }
        public override void Error(string message)
        {
            fileWriter.WriteLine("[ERROR] " + message);
        }
        public override void Warn(string message)
        {
            fileWriter.WriteLine("[WARNING] " + message);
        }
    }
}