using DiceBattleGame.Data.Characters;
using Microsoft.VisualBasic;
using System.Numerics;

namespace DiceBattleGame.GameData.System
{
    internal class CampaignManager // this is the master class for handling the data of the game state during a playthrough
    {
        private List<Character> playerParty = new List<Character>();
        // private MapData mapData; // future implementation for map handling
        // private List<Item> inventory; // future implementation for inventory handling

        // method to initialize a new campaign with a player character and a random seed
        public CampaignManager(Character player)
        {
            playerParty.Add(player);
            int seed = DateAndTime.Now.Millisecond;
            Random random = new Random(seed);

            /*
            mapData = new MapData(); // initialize map data
            
            mapData.Generate(seed); // generate map with the random seed
            inventory = new List<Item>(); // initialize empty inventory
            inventory.add(new HealthPotion()); // starting item

            whatever else needs to be initialized here
            
            */
        }

        // method to start a campaign with a specified seed
        public CampaignManager(Character player, int seed)
        {
            playerParty.Add(player);
            Random random = new Random(seed);

            /*
            mapData = new MapData(); // initialize map data
            
            mapData.Generate(seed); // generate map with the set seed
            inventory = new List<Item>(); // initialize empty inventory
            inventory.add(new HealthPotion()); // starting item

            whatever else needs to be initialized here
            
            */
        }

    }
}
