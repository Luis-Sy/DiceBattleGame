using DiceBattleGame.GameData.Characters;
using Microsoft.VisualBasic;
using System.Diagnostics;
using System.Numerics;

namespace DiceBattleGame.GameData.System
{
    internal class CampaignManager // this is the master class for handling the data of the game state during a playthrough
    {
        private List<Character> playerParty = new List<Character>();
        private MapData mapData;
        public List<string> NodeTypes = new List<string> // default node types
        { 
            "Start", // starting nodes
            "Common Battle",
            "Elite Battle",
            "Boss Battle",
            "Shop", 
            "Event", 
            "Rest" 
        };
        // private List<Item> inventory; // future implementation for inventory handling

        // default method to initialize a new campaign with a player character, a random seed, and the default node types
        public CampaignManager(Character player)
        {
            playerParty.Add(player);
            int seed = DateAndTime.Now.Millisecond;
            Random random = new Random(seed);

            mapData = new MapData(seed, this.NodeTypes); // initialize map data and generate with random seed

            /*
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

            
            mapData = new MapData(seed, this.NodeTypes); // initialize map data and generate map with the set seed
            
            /*
            inventory = new List<Item>(); // initialize empty inventory
            inventory.add(new HealthPotion()); // starting item

            whatever else needs to be initialized here
            
            */
        }

        // method to start a campaign with a specified seed and custom node types
        public CampaignManager(Character player, int seed, List<string> nodeTypes)
        {
            playerParty.Add(player);
            Random random = new Random(seed);
            this.NodeTypes = nodeTypes;
            mapData = new MapData(seed, nodeTypes); // initialize map data and generate map with the set seed

            /*
            inventory = new List<Item>(); // initialize empty inventory
            inventory.add(new HealthPotion()); // starting item
            whatever else needs to be initialized here
            
            */
        }

        // debug function to log the nodes to the console
        public void displayMapData()
        {
            List<MapNode> nodes = mapData.GetAllNodes();
            foreach (MapNode node in nodes)
            {
                Trace.WriteLine("Node Type: " + node.GetNodeType() + ", Visited: " + node.IsVisited());
            }
        }

    }
}
