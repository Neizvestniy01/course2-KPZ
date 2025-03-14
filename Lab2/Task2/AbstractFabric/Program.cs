using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        ITechFactory iphoneFactory = new IphoneFactory();
        ITechFactory xiaomiFactory = new XiaomiFactory();
        ITechFactory galaxyFactory = new GalaxyFactory();

        IDevice iphoneLaptop = iphoneFactory.CreateLaptop();
        IDevice xiaomiSmartphone = xiaomiFactory.CreateSmartphone();
        IDevice galaxyEBook = galaxyFactory.CreateEBook();
        IDevice iphonenetbook = iphoneFactory.CreateNetbook();

        iphoneLaptop.ShowInfo();
        xiaomiSmartphone.ShowInfo();
        galaxyEBook.ShowInfo();
        iphonenetbook.ShowInfo();
    }
}