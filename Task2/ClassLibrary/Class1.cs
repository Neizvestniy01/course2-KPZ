using System;

namespace ClassLibrary
{
    public abstract class Hero
    {
        public abstract string GetDescription();
        public abstract int GetPower();
    }
    public class Warrior : Hero
    {
        public override string GetDescription() => "Warrior";
        public override int GetPower() => 50;
    }
    public class Mage : Hero
    {
        public override string GetDescription() => "Mage";
        public override int GetPower() => 40;
    }
    public class Paladin : Hero
    {
        public override string GetDescription() => "Paladin";
        public override int GetPower() => 45;
    }
    public abstract class EquipmentDecorator : Hero
    {
        protected Hero hero;
        public EquipmentDecorator(Hero hero)
        {
            this.hero = hero;
        }
        public override string GetDescription() => hero.GetDescription();
        public override int GetPower() => hero.GetPower();
    }
    public class Armor : EquipmentDecorator
    {
        public Armor(Hero hero) : base(hero) { }
        public override string GetDescription() => hero.GetDescription() + " with Armor";
        public override int GetPower() => hero.GetPower() + 20;
    }
    public class Sword : EquipmentDecorator
    {
        public Sword(Hero hero) : base(hero) { }
        public override string GetDescription() => hero.GetDescription() + " with Sword";
        public override int GetPower() => hero.GetPower() + 30;
    }
    public class MagicRing : EquipmentDecorator
    {
        public MagicRing(Hero hero) : base(hero) { }
        public override string GetDescription() => hero.GetDescription() + " with Magic Ring";
        public override int GetPower() => hero.GetPower() + 15;
    }
}