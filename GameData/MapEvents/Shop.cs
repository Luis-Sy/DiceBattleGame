using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.Items;
using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents
{
    public class Shop : MapEvent
    {
        private List<Item> shopInventory = new List<Item>();
        private List<Character> partyMemberList = new List<Character>();
        public Shop(int targetLevel)
        {
            initializeEvent(targetLevel);
        }

        public override void initializeEvent(int targetLevel)
        {
            // When there are more items it'll use a weighted selector instead
            // WeightedRandomSelector<String> itemSelector = new WeightedRandomSelector<string>();
            Random rand = new Random();

            // get a list of all available items
            List<Type> itemPool = AppDomain.CurrentDomain
                .GetAssemblies().SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(Item)) && !type.IsAbstract)
                .ToList();

            int numItems = rand.Next(5, 11); // between 5 and 10 items in shop
            for (int i = 0; i < numItems; i++)
            {
                Item item = (Item)Activator.CreateInstance(
                    itemPool[rand.Next(itemPool.Count)])!;
                shopInventory.Add(item);
            }

            // generate recruitable party members

            // load every defined player character type
            List<Type> characterPool = AppDomain.CurrentDomain
                .GetAssemblies().SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(Character)) && !type.IsAbstract && type.Name.Contains("Player"))
                .ToList();

            int numRecruits = rand.Next(2, 6); // between 2 and 5 recruitable members
            for (int i = 0; i < numRecruits; i++)
            {
                //Character recruit = (Character)Activator.CreateInstance(
                //    characterPool[rand.Next(characterPool.Count)], targetLevel)!;
                Character recruit = (Character)Activator.CreateInstance(
                    characterPool[rand.Next(characterPool.Count)])!;
                recruit.setLevel(targetLevel);
                partyMemberList.Add(recruit);
            }
        }

        public override T GetEventData<T>()
        {
            // retrieve the shop inventory
            if (typeof(T) == typeof(List<Item>))
            {
                return (T)(object)shopInventory;
            }
            // retrieve recruitable party members
            else if (typeof(T) == typeof(List<Character>))
            {
                return (T)(object)partyMemberList;
            }
            return base.GetEventData<T>();
        }

    }
}
