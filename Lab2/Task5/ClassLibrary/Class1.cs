using System;
using System.Collections.Generic;

namespace ClassLibrary
{
    public interface ICharacterBuilder
    {
        ICharacterBuilder SetHeight(double height);
        ICharacterBuilder SetBuild(string build);
        ICharacterBuilder SetHairColor(string color);
        ICharacterBuilder SetEyeColor(string color);
        ICharacterBuilder SetClothing(string clothing);
        ICharacterBuilder SetInventory(List<string> inventory);
        Character Build();
    }
    public class Character
    {
        public double Height { get; set; }
        public string Build { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string Clothing { get; set; }
        public List<string> Inventory { get; set; } = new List<string>();
        public List<string> GoodDeeds { get; set; } = new List<string>();
        public List<string> BadDeeds { get; set; } = new List<string>();
        public void DisplayInfo()
        {
            Console.WriteLine($"Зріст: {Height}, Тіло: {Build}, Колір волосся: {HairColor}, Колір очей: {EyeColor}, Одяг: {Clothing}");
            Console.WriteLine($"Інвентар: {(Inventory.Count > 0 ? string.Join(", ", Inventory) : "None")}");
            Console.WriteLine($"Гарні вчинки: {(GoodDeeds.Count > 0 ? string.Join(", ", GoodDeeds) : "None")}");
            Console.WriteLine($"Погані вчинки: {(BadDeeds.Count > 0 ? string.Join(", ", BadDeeds) : "None")}");
        }
    }
    public abstract class CharacterBuilder : ICharacterBuilder
    {
        protected Character character = new Character();

        public ICharacterBuilder SetHeight(double height)
        {
            character.Height = height;
            return this;
        }
        public ICharacterBuilder SetBuild(string build)
        {
            character.Build = build;
            return this;
        }
        public ICharacterBuilder SetHairColor(string color)
        {
            character.HairColor = color;
            return this;
        }
        public ICharacterBuilder SetEyeColor(string color)
        {
            character.EyeColor = color;
            return this;
        }
        public ICharacterBuilder SetClothing(string clothing)
        {
            character.Clothing = clothing;
            return this;
        }
        public ICharacterBuilder SetInventory(List<string> inventory)
        {
            character.Inventory = inventory;
            return this;
        }
        public Character Build()
        {
            return character;
        }
    }
    public class HeroBuilder : CharacterBuilder
    {
        public HeroBuilder AddGoodDeed(string deed)
        {
            character.GoodDeeds.Add(deed);
            return this;
        }
    }
    public class EnemyBuilder : CharacterBuilder
    {
        public EnemyBuilder AddBadDeed(string deed)
        {
            character.BadDeeds.Add(deed);
            return this;
        }
    }
}