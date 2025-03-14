using System;

namespace ClassLibrary
{
    public interface IDevice
    {
        void ShowInfo();
    }
    public abstract class Device : IDevice
    {
        protected string brand;
        protected string type;
        public Device(string brand, string type)
        {
            this.brand = brand;
            this.type = type;
        }
        public void ShowInfo() => Console.WriteLine($"{type} від {brand}");
    }

    public class Laptop : Device { public Laptop(string brand) : base(brand, "Laptop") { } }
    public class Netbook : Device { public Netbook(string brand) : base(brand, "Netbook") { } }
    public class EBook : Device { public EBook(string brand) : base(brand, "EBook") { } }
    public class Smartphone : Device { public Smartphone(string brand) : base(brand, "Smartphone") { } }

    public interface ITechFactory
    {
        IDevice CreateLaptop();
        IDevice CreateNetbook();
        IDevice CreateEBook();
        IDevice CreateSmartphone();
    }
    public abstract class TechFactory : ITechFactory
    {
        protected string brand;
        protected TechFactory(string brand) => this.brand = brand;
        public IDevice CreateLaptop() => new Laptop(brand);
        public IDevice CreateNetbook() => new Netbook(brand);
        public IDevice CreateEBook() => new EBook(brand);
        public IDevice CreateSmartphone() => new Smartphone(brand);
    }

    public class IphoneFactory : TechFactory { public IphoneFactory() : base("Iphone") { } }
    public class XiaomiFactory : TechFactory { public XiaomiFactory() : base("Xiaomi") { } }
    public class GalaxyFactory : TechFactory { public GalaxyFactory() : base("Galaxy") { } }
}