using DiceBattleGame.GameData.Characters;

namespace DiceBattleGame.GameData.Items
{
    // Stronger versions of existing potions with increased prices

    internal class GreaterStrengthPotion : Item
    {
        public GreaterStrengthPotion()
            : base("Greater Strength Potion", 20, "A strong potion that increases Strength by 10.")
        {
            value1 = 10;
        }

        public override void Use(Character entity)
        {
            entity.getStats()["Strength"] += value1;
        }
    }

    internal class GreaterDexterityPotion : Item
    {
        public GreaterDexterityPotion()
            : base("Greater Dexterity Potion", 20, "A strong potion that increases Dexterity by 10.")
        {
            value1 = 10;
        }

        public override void Use(Character entity)
        {
            entity.getStats()["Dexterity"] += value1;
        }
    }

    internal class GreaterIntelligencePotion : Item
    {
        public GreaterIntelligencePotion()
            : base("Greater Intelligence Potion", 20, "A strong potion that increases Intellect by 10.")
        {
            value1 = 10;
        }

        public override void Use(Character entity)
        {
            
            entity.getStats()["Intelect"] += value1;
        }
    }

    internal class GreaterFaithPotion : Item
    {
        public GreaterFaithPotion()
            : base("Greater Faith Potion", 20, "A strong potion that increases Faith by 10.")
        {
            value1 = 10;
        }

        public override void Use(Character entity)
        {
            entity.getStats()["Faith"] += value1;
        }
    }

    internal class GreaterHealthPotion : Item
    {
        public GreaterHealthPotion()
            : base("Greater Health Potion", 15, "A strong potion that restores 20 HP")
        {
            value1 = 20;
        }

        public override void Use(Character entity)
        {
            
            entity.changeHp(value1);
        }
    }
}
