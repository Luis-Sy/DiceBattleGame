using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Items
{
    internal class ItemDatabase
    {
        public static List<Item> ShopItems = new List<Item>()
        {
            new HealthPotion(),
            new StrengthPotion(),
            new DexterityPotion(),
            new IntelligencePotion(),
            new FaithPotion()
        };
    }
}
