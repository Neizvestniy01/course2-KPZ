using System;
using ClassLibrary;

namespace Lightweight
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string[] bookLines =
            {
                "Назва книги",
                "Розділ 1",
                "  Це цитата з книги.",
                "Опис розділу...",
                "Розділ 2",
                "  Ще одна цитата.",
                "Основний текст книги..."
            };
            LightElementNode body = new LightElementNode("body");
            foreach (string line in bookLines)
            {
                string trimmedLine = line.Trim();
                LightElementNode element;

                if (line == bookLines[0])
                    element = new LightElementNode("h1");
                else if (trimmedLine.Length < 20 && !line.StartsWith("  "))
                    element = new LightElementNode("h2");
                else if (line.StartsWith("  "))
                    element = new LightElementNode("blockquote");
                else
                    element = new LightElementNode("p");

                element.AddChild(new LightTextNode(trimmedLine));
                body.AddChild(element);
            }
            Console.WriteLine(body.GetOuterHTML());
        }
    }
}