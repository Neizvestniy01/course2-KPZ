using System;
using ClassLibrary;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Hero warrior = new Warrior();
        warrior = new Armor(warrior);
        warrior = new Sword(warrior);
        Console.WriteLine(warrior.GetDescription() + " - Power: " + warrior.GetPower());

        Hero mage = new Mage();
        mage = new MagicRing(mage);
        mage = new Armor(mage);
        Console.WriteLine(mage.GetDescription() + " - Power: " + mage.GetPower());

        Hero paladin = new Paladin();
        paladin = new Sword(paladin);
        paladin = new MagicRing(paladin);
        Console.WriteLine(paladin.GetDescription() + " - Power: " + paladin.GetPower());
    }
}