using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    public class Money
    {
        public int Whole { get; set; }
        public int Cents { get; set; }
        public string Currency { get; set; }
        public Money(int whole, int cents, string currency)
        {
            Whole = whole;
            Cents = cents;
            Currency = currency;
        }
        public void SetValue(int whole, int cents)
        {
            Whole = whole;
            Cents = cents;
        }
        public override string ToString()
        {
            return $"{Whole}.{Cents:D2} {Currency}";
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public Money Price { get; set; }
        public string Category { get; set; }
        public Product(string name, Money price, string category = "Загальна")
        {
            Name = name;
            Price = price;
            Category = category;
        }
        public void ReducePrice(Money amount)
        {
            int totalCents = Price.Whole * 100 + Price.Cents - (amount.Whole * 100 + amount.Cents);
            Price.SetValue(totalCents / 100, totalCents % 100);
        }
        public override string ToString()
        {
            return $"{Name} ({Category}): {Price.ToString()}";
        }
    }

    public class Warehouse
    {
        public List<Dictionary<string, object>> Products { get; set; }
        public Warehouse()
        {
            Products = new List<Dictionary<string, object>>();
        }
        public void AddProduct(Product product, int quantity, string unit, DateTime lastDelivery)
        {
            Products.Add(new Dictionary<string, object>
            {
                { "product", product },
                { "quantity", quantity },
                { "unit", unit },
                { "last_delivery", lastDelivery }
            });

            Console.WriteLine($"Додано товар: {product.ToString()}");
        }
        public override string ToString()
        {
            var report = "";
            foreach (var item in Products)
            {
                var product = (Product)item["product"];
                var quantity = (int)item["quantity"];
                var unit = (string)item["unit"];
                var lastDelivery = (DateTime)item["last_delivery"];
                report += $"{product.ToString()} - {quantity} {unit} (Остання доставка: {lastDelivery:yyyy-MM-dd HH:mm:ss})\n"; // Використання ToString()
            }
            return report;
        }
    }

    public class Reporting
    {
        public Warehouse Warehouse { get; set; }
        public Reporting(Warehouse warehouse)
        {
            Warehouse = warehouse;
        }
        public void RegisterIncome(Product product, int quantity, string unit)
        {
            Warehouse.AddProduct(product, quantity, unit, DateTime.Now);
            Console.WriteLine($"Зареєстровано надходження: {product.ToString()} - {quantity} {unit}");
        }
        public void RegisterOutcome(string productName, int quantity)
        {
            foreach (var item in Warehouse.Products)
            {
                var product = (Product)item["product"];
                var unit = (string)item["unit"];
                if (product.Name == productName)
                {
                    var currentQuantity = (int)item["quantity"];
                    if (currentQuantity >= quantity)
                    {
                        item["quantity"] = currentQuantity - quantity;
                        Console.WriteLine($"Зареєстровано відвантаження: {product.ToString()} - {quantity} {unit}");
                    }
                    else
                    {
                        Console.WriteLine($"Недостатньо товару: {product.ToString()}");
                    }
                    return;
                }
            }
            Console.WriteLine($"Товар {productName} не знайдено на складі");
        }
        public void InventoryReport()
        {
            Console.WriteLine("Звіт про інвентаризацію:");
            Console.WriteLine(Warehouse.ToString());
        }
    }
}