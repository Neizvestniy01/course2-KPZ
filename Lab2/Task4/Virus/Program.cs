using System;
using ClassLibrary;

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Virus virusAlpha = new Virus("Alpha", "Virus Type A", 0.5, 10);
        Virus virusAlphaChild1 = new Virus("Alpha Child 1", "Virus Type A", 0.4, 5);
        Virus virusAlphaChild1_1 = new Virus("Alpha Child 1.1", "Virus Type A", 0.3, 2);  
        virusAlphaChild1.AddChild(virusAlphaChild1_1); 
        Virus virusAlphaChild2 = new Virus("Alpha Child 2", "Virus Type A", 0.45, 4); 
        virusAlpha.AddChild(virusAlphaChild2);
        virusAlpha.AddChild(virusAlphaChild1);
        Virus clonedVirusAlpha = (Virus)virusAlpha.Clone();

        Virus virusBeta = new Virus("Beta", "Virus Type B", 0.6, 8);
        Virus virusBetaChild1 = new Virus("Beta Child 1", "Virus Type B", 0.35, 3);
        Virus virusBetaChild2 = new Virus("Beta Child 2", "Virus Type B", 0.38, 2);
        virusBeta.AddChild(virusBetaChild1);
        virusBeta.AddChild(virusBetaChild2);
        Virus clonedVirusBeta = (Virus)virusBeta.Clone();

        Console.WriteLine("Справжній Virus Alpha:");
        virusAlpha.PrintInfo();
        Console.WriteLine("\nКлонований Virus Alpha:");
        clonedVirusAlpha.PrintInfo();
        Console.WriteLine("\nСправжній Virus Beta:");
        virusBeta.PrintInfo();
        Console.WriteLine("\nКлонований Virus Beta:");
        clonedVirusBeta.PrintInfo();
    }
}
