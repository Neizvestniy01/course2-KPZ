using System;
using System.Collections.Generic;
using System.Text;
using ClassLibrary1;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        var warehouse = new Warehouse();
        var reporting = new Reporting(warehouse);

        var priceLaptop = new Money(100, 0, "USD");
        var productLaptop = new Product("Ноутбук", priceLaptop, "Електроніка");
        reporting.RegisterIncome(productLaptop, 10, "шт");
        var priceSmartphone = new Money(50, 0, "USD");
        var productSmartphone = new Product("Смартфон", priceSmartphone, "Електроніка");
        reporting.RegisterIncome(productSmartphone, 15, "шт");

        reporting.InventoryReport();

        reporting.RegisterOutcome("Ноутбук", 5);
        reporting.RegisterOutcome("Смартфон", 3);
        reporting.InventoryReport();

        Console.WriteLine("Зменшення ціни на 20 USD для ноутбука");
        productLaptop.ReducePrice(new Money(20, 0, "USD"));
        Console.WriteLine($"Нова ціна ноутбука: {productLaptop}");
        Console.WriteLine("Зменшення ціни на 10 USD для смартфона");
        productSmartphone.ReducePrice(new Money(10, 0, "USD"));
        Console.WriteLine($"Нова ціна смартфона: {productSmartphone}");
        reporting.InventoryReport();

        reporting.RegisterOutcome("Ноутбук", 10); 
        reporting.RegisterOutcome("Неіснуючий товар", 1); 
        reporting.InventoryReport();
    }
}