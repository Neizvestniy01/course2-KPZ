using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ClassLibrary
{
    public class SmartTextReader
    {
        protected string filePath;
        public SmartTextReader(string filePath)
        {
            this.filePath = filePath;
        }
        public virtual char[][] Read()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine($"Файл {filePath} не знайдено!");
                return new char[0][];
            }
            string[] lines = File.ReadAllLines(filePath);
            char[][] content = new char[lines.Length][];
            for (int i = 0; i < lines.Length; i++)
            {
                content[i] = lines[i].ToCharArray();
            }
            return content;
        }
    }

    public class SmartTextChecker : SmartTextReader
    {
        public SmartTextChecker(string filePath) : base(filePath) { }
        public override char[][] Read()
        {
            Console.WriteLine("Opening file...");
            char[][] content = base.Read();
            int totalChars = 0;
            foreach (var line in content)
                totalChars += line.Length;
            Console.WriteLine("File read successfully.");
            Console.WriteLine($"Total lines: {content.Length}");
            Console.WriteLine($"Total characters: {totalChars}");
            Console.WriteLine("Closing file...");
            return content;
        }
    }

    public class SmartTextReaderLocker : SmartTextReader
    {
        private string pattern;
        public SmartTextReaderLocker(string filePath, string pattern) : base(filePath)
        {
            this.pattern = pattern;
        }
        public override char[][] Read()
        {
            if (Regex.IsMatch(filePath, pattern))
            {
                Console.WriteLine("\nAccess denied!");
                return new char[0][];
            }
            return base.Read();
        }
    }
}