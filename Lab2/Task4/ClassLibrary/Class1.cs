using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public class Virus : ICloneable
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public List<Virus> Children { get; set; }
        public Virus(string name, string type, double weight, int age)
        {
            Name = name;
            Type = type;
            Weight = weight;
            Age = age;
            Children = new List<Virus>();
        }
        public void AddChild(Virus child)
        {
            Children.Add(child);
        }
        public object Clone()
        {
            Virus clone = (Virus)this.MemberwiseClone();
            clone.Children = new List<Virus>();
            foreach (var child in this.Children)
            {
                clone.Children.Add((Virus)child.Clone());
            }
            return clone;
        }
        public void PrintInfo()
        {
            Console.WriteLine($"Name: {Name}, Type: {Type}, Weight: {Weight}, Age: {Age}");
            if (Children.Count > 0)
            {
                Console.WriteLine("Children:");
                foreach (var child in Children)
                {
                    child.PrintInfo();
                }
            }
        }
    }
}