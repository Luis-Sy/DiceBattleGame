using DiceBattleGame.Data.Characters;
using DiceBattleGame.GameData.MapEvents;
using DiceBattleGame.GameData.MapEvents.CombatEncounters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DiceBattleGame.GameData.System
{
    internal class MapData // this is the class used for handling map data and generation in a campaign
    {
        private Random random;
        private List<MapNode> mapNodes = new List<MapNode>();
        private List<string> nodeTypes;
        private MapNode currentNode;

        public MapData(int seed, List<string> nodeTypes)
        {
            // generate map data based on seed
            random = new Random(seed);
            this.nodeTypes = nodeTypes;
            Generate(seed);
        }

        private void Generate(int seed)
        {
            // generate a map layout based on the seed

            // retrieve possible encounter types
            List<Type> combatEncounters = getCombatEncounters()
                .Where(type => type.Name.Contains("Common") || type.Name.Contains("Elite"))
                .ToList();
            // get starting encounters
            List<Type> startingEncounters = getCombatEncounters()
                .Where(type => type.Name.Contains("Start") )
                .ToList();
            // get boss encounters
            List<Type> bossEncounters = getCombatEncounters()
                .Where(type => type.Name.Contains("Boss"))
                .ToList();

            Trace.WriteLine($"Found {startingEncounters.Count} starting combat encounters.");
            Trace.WriteLine($"Found {combatEncounters.Count} combat encounters.");
            Trace.WriteLine($"Found {bossEncounters.Count} boss combat encounters.");
            

            // level for enemy scaling
            int enemyLevel = 1;

            // create the unique starting node (always a battle encounter from the starting battle pool)
            MapEvent? startEvent = null;
            if (startingEncounters.Count > 0)
            {
                startEvent = Activator.CreateInstance(startingEncounters[random.Next(startingEncounters.Count)], enemyLevel) as MapEvent;
            }
            if (startEvent == null)
            {
                throw new InvalidOperationException("No valid starting encounter found for Start node.");
            }
            MapNode start = new MapNode("Start", startEvent);

            mapNodes.Add(start);

            // create a series of random nodes based on the node types provided
            for (int i = 0; i < 8; i++) // generate the next 8 nodes
            {
                string nodeType = nodeTypes[random.Next(nodeTypes.Count)];
                MapEvent? nodeEvent = null;
                if (combatEncounters.Count > 0)
                {
                    nodeEvent = Activator.CreateInstance(combatEncounters[random.Next(combatEncounters.Count)], enemyLevel) as MapEvent;
                    // scale the encounter to the current enemy level
                    nodeEvent.initializeEvent(enemyLevel);
                    enemyLevel++;
                }
                if (nodeEvent == null)
                {
                    throw new InvalidOperationException("No valid combat encounter found for node.");
                }
                MapNode newNode = new MapNode(nodeType, nodeEvent);
                mapNodes.Add(newNode);
            }

            // create the boss node at the end
            MapEvent? bossEvent = null;
            if (bossEncounters.Count > 0)
            {
                bossEvent = Activator.CreateInstance(bossEncounters[random.Next(bossEncounters.Count)], enemyLevel) as MapEvent;
                // scale the encounter to the current enemy level
                bossEvent.initializeEvent(enemyLevel);
                enemyLevel++;
            }
            if (bossEvent == null)
            {
                throw new InvalidOperationException("No valid boss encounter found for Boss node.");
            }

            MapNode bossNode = new MapNode("Boss Battle", bossEvent);
            mapNodes.Add(bossNode);

            // link them all together from start to finish
            for (int i = 0; i < mapNodes.Count - 1; i++)
            {
                mapNodes[i].next = mapNodes[i + 1];
                if (mapNodes[i].GetNodeType().Contains("Battle"))
                {
                    Trace.WriteLine($"Node {i} is a {mapNodes[i].GetNodeType()} " +
                        $"with encounter {mapNodes[i].GetNodeData().GetEventData<List<Character>>().Last()}.");
                }
            }

            // set the current node to the start
            currentNode = mapNodes[0];
        }

        public MapNode GetCurrentNode()
        {
            return currentNode;
        }

        public List<MapNode> GetAllNodes()
        {
            return mapNodes;
        }

        // helper functions to retrieve all defined encounters in the database

        private List<Type> getCombatEncounters()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies().SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(CombatEncounter)) && !type.IsAbstract)
                .ToList();

        }

    }
}
