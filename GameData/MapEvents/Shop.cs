using DiceBattleGame.GameData.Items;
using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents
{
    internal class Shop : MapEvent
    {
        private List<Item > shopInventory = new List<Item>();

        public Shop(int targetLevel)
        {
            initializeEvent(targetLevel);
        }

        public override void initializeEvent(int targetLevel)
        {
            // When there are more items it'll use a weighted selector instead
            // WeightedRandomSelector<String> itemSelector = new WeightedRandomSelector<string>();


            // get a list of all available items
            shopInventory = new List<Item>()
            {
                new HealthPotion(),
                new DexterityPotion(),
                new StrengthPotion(),
                new IntelligencePotion(),
                new FaithPotion()
            };
        }

        public override T GetEventData<T>()
        {
            if (typeof(T) == typeof(List<Item>))
            {
                return (T)(object)shopInventory;
            }
            return base.GetEventData<T>();
        }

    }
}
