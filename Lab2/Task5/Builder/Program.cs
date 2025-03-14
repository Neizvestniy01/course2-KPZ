using System;
using System.Collections.Generic;
using ClassLibrary;

namespace CharacterTest
{
    class Program
    {
        static Character hero = null;
        static Character enemy = null;
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Виберіть дію:");
                Console.WriteLine("1. Створити героя");
                Console.WriteLine("2. Створити ворога");
                Console.WriteLine("3. Вивести дані про героя");
                Console.WriteLine("4. Вивести дані про ворога");
                Console.WriteLine("5. Вийти");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        CreateHero();
                        break;
                    case "2":
                        CreateEnemy();
                        break;
                    case "3":
                        DisplayCharacter(hero, "Герой");
                        break;
                    case "4":
                        DisplayCharacter(enemy, "Ворог");
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }
            }
        }
        static void CreateHero()
        {
            Console.WriteLine("Створення героя:");
            ICharacterBuilder heroBuilder = new HeroBuilder();
            heroBuilder = SetCharacterAttributes(heroBuilder, "Герой");
            hero = heroBuilder.Build();
            Console.WriteLine("\nГерой успішно створений!");
            Console.WriteLine("\nНатисніть будь-яку клавішу для повернення в меню...");
            Console.ReadKey();
        }
        static void CreateEnemy()
        {
            Console.WriteLine("Створення ворога:");
            ICharacterBuilder enemyBuilder = new EnemyBuilder();
            enemyBuilder = SetCharacterAttributes(enemyBuilder, "Ворог");
            enemy = enemyBuilder.Build();
            Console.WriteLine("\nВорог успішно створений!");
            Console.WriteLine("\nНатисніть будь-яку клавішу для повернення в меню...");
            Console.ReadKey();
        }
        static void DisplayCharacter(Character character, string characterType)
        {
            if (character == null)
            {
                Console.WriteLine($"\n{characterType} ще не створений.");

                if (characterType == "Ворог")
                {
                    Console.WriteLine("\nБажаєте створити ворога за замовчуванням? (y/n)");
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "y")
                    {
                        CreateDefaultEnemy();
                    }
                    else
                    {
                        Console.WriteLine("\nПовернення в меню...");
                    }
                }
            }
            else
            {
                Console.WriteLine($"\nІнформація про {characterType}:");
                character.DisplayInfo();
            }
            Console.WriteLine("\nНатисніть будь-яку клавішу для повернення в меню...");
            Console.ReadKey();
        }
        static void CreateDefaultEnemy()
        {
            ICharacterBuilder enemyBuilder = new EnemyBuilder();
            enemyBuilder.SetHeight(1.8)
                        .SetBuild("Стандарт")
                        .SetHairColor("Чорне")
                        .SetEyeColor("Сірі")
                        .SetClothing("Одяг фюрера")
                        .SetInventory(new List<string> { "Ядерна кнопка", "Люгер" });
            enemyBuilder = ((EnemyBuilder)enemyBuilder).AddBadDeed("Почав 2 світову");
            enemy = enemyBuilder.Build();
            Console.WriteLine("\nВорог за замовчуванням успішно створений!");
            DisplayCharacter(enemy, "Адольф Гітлер");
        }
        static ICharacterBuilder SetCharacterAttributes(ICharacterBuilder builder, string characterType)
        {
            Console.WriteLine($"Введіть параметри для {characterType}:");
            Console.Write("Зріст (метри): ");
            double height = Convert.ToDouble(Console.ReadLine());
            builder.SetHeight(height);

            Console.Write("Тіло (наприклад, спортивна, кремезна): ");
            string build = Console.ReadLine();
            builder.SetBuild(build);

            Console.Write("Колір волосся: ");
            string hairColor = Console.ReadLine();
            builder.SetHairColor(hairColor);

            Console.Write("Колір очей: ");
            string eyeColor = Console.ReadLine();
            builder.SetEyeColor(eyeColor);

            Console.Write("Одяг: ");
            string clothing = Console.ReadLine();
            builder.SetClothing(clothing);

            Console.Write("Інвентар (через кому): ");
            List<string> inventory = new List<string>(Console.ReadLine().Split(','));
            builder.SetInventory(inventory);
            if (characterType == "Герой")
            {
                Console.Write("Введіть гарний вчинок: ");
                string goodDeed = Console.ReadLine();
                builder = ((HeroBuilder)builder).AddGoodDeed(goodDeed);
            }
            else if (characterType == "Ворог")
            {
                Console.Write("Введіть поганий вчинок: ");
                string badDeed = Console.ReadLine();
                builder = ((EnemyBuilder)builder).AddBadDeed(badDeed);
            }
            return builder;
        }
    }
}