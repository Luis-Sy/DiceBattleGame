using DiceBattleGame.GameData.Characters;

namespace DiceBattleGame.GameData.Items
{
    // Stronger versions of existing potions with increased prices

    internal class GreaterStrengthPotion : Item
    {
        public GreaterStrengthPotion()
            : base("Greater Strength Potion", 60, "A stronger potion that increases strength by more than the normal version.")
        {
            value1 = 8;
        }

        public override void Use(Character entity)
        {
            entity.getStats()["Strength"] += value1;
        }
    }

    internal class GreaterDexterityPotion : Item
    {
        public GreaterDexterityPotion()
            : base("Greater Dexterity Potion", 60, "A stronger potion that increases dexterity by more than the normal version.")
        {
            value1 = 8;
        }

        public override void Use(Character entity)
        {
            entity.getStats()["Dexterity"] += value1;
        }
    }

    internal class GreaterIntelligencePotion : Item
    {
        public GreaterIntelligencePotion()
            : base("Greater Intelligence Potion", 60, "A stronger potion that increases intelligence by more than the normal version.")
        {
            value1 = 8;
        }

        public override void Use(Character entity)
        {
            
            entity.getStats()["Intelect"] += value1;
        }
    }

    internal class GreaterFaithPotion : Item
    {
        public GreaterFaithPotion()
            : base("Greater Faith Potion", 60, "A stronger potion that increases faith by more than the normal version.")
        {
            value1 = 8;
        }

        public override void Use(Character entity)
        {
            entity.getStats()["Faith"] += value1;
        }
    }

    internal class GreaterHealthPotion : Item
    {
        public GreaterHealthPotion()
            : base("Greater Health Potion", 55, "A stronger potion that restores more HP than the normal version.")
        {
            value1 = 15;
        }

        public override void Use(Character entity)
        {
            
            entity.changeHp(value1);
        }
    }
}
