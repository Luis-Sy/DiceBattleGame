using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.MapEvents;
using DiceBattleGame.GameData.MapEvents.CombatEncounters;
using System.Diagnostics;
using System.Reflection;

namespace DiceBattleGame.GameData.System
{
    public class MapData // this is the class used for handling map data and generation in a campaign
    {
        private Random random;
        private List<MapNode> mapNodes = new List<MapNode>();
        private List<string> nodeTypes;
        private MapNode currentNode;

        /*
         TODO
         -implement validation for node types
         -implement more complex map layouts with branching paths
         */
        public MapData(int seed, List<string> nodeTypes)
        {
            // generate map data based on seed
            random = new Random(seed);
            this.nodeTypes = nodeTypes;
            Generate(seed);
            currentNode = mapNodes[0];
        }

        // default map gen with default node types
        private void Generate(int seed)
        {
            // generate a map layout based on the seed

            // create a weight table for selecting encounters
            WeightedRandomSelector<string> encounterTable = new WeightedRandomSelector<string>(seed);
            encounterTable.AddItem("Common Battle", 70.0);
            encounterTable.AddItem("Elite Battle", 30.0);


            // get all the defined map events
            List<Type> events = getAllEvents();

            // retrieve possible combat encounter types by querying their custom attribute

            // get starting battle encounters
            List<Type> startingEncounters = events
                .Where(type => type.GetCustomAttribute<EventType>()?.TypeName == "Start")
                .ToList();
            // get common battle encounters
            List<Type> commonEncounters = events
                .Where(type => type.GetCustomAttribute<EventType>()?.TypeName == "Common Battle")
                .ToList();
            // get elite battle encounters
            List<Type> eliteEncounters = events
                .Where(type => type.GetCustomAttribute<EventType>()?.TypeName == "Elite Battle")
                .ToList();
            // get boss encounters
            List<Type> bossEncounters = events
                .Where(type => type.GetCustomAttribute<EventType>()?.TypeName == "Boss Battle")
                .ToList();

            Trace.WriteLine(
                $"Map Generation Debug Info:\n" +
                $"----------------------------------------\n" +
                $"Found {startingEncounters.Count} starting battle encounters\n" +
                $"Found {commonEncounters.Count} common battle encounters\n" +
                $"Found {eliteEncounters.Count} elite battle encounters\n" +
                $"Found {bossEncounters.Count} boss battle encounters\n"
                );


            // level for enemy scaling
            int enemyLevel = 1;

            // create the unique starting node (always a battle encounter from the starting battle pool)
            MapEvent? startEvent = null;
            if (startingEncounters.Count > 0)
            {
                startEvent = Activator.CreateInstance(startingEncounters[random.Next(startingEncounters.Count)], enemyLevel) as CombatEncounter;
            }
            if (startEvent == null)
            {
                throw new InvalidOperationException("No valid starting encounter found for Start node.");
            }
            MapNode start = new MapNode("Start", startEvent);

            mapNodes.Add(start);

            // create a series of random nodes based on the node types provided

            // use a weighted selector to select battle types

            WeightedRandomSelector<string> selector = new WeightedRandomSelector<string>(seed);
            selector.AddItem("Common Battle", 60);
            selector.AddItem("Elite Battle", 30);
            selector.AddItem("Shop", 10);

            int scaleInterval = 3; // increase enemy level every 3 nodes
            int scaleCounter = 0;

            for (int i = 0; i < 13; i++) // generate the next 13 nodes
            {
                string nodeType = "undefined";
                MapEvent? nodeEvent = null;

                // guarantee shops on certain nodes for balancing
                if (i == 2 || i == 5 || i == 8 || i == 11)
                {
                    nodeEvent = new Shop(enemyLevel);
                    nodeType = "Shop";
                    mapNodes.Add(new MapNode(nodeType, nodeEvent));
                    continue;
                }
                // guarantee a rest node before the boss
                if(i == 12)
                {
                    nodeType = "Rest";
                    mapNodes.Add(new MapNode(nodeType, nodeEvent)); // I've yet to implement rest nodes, so no event data for now - Luis
                    continue;
                }
                string selectedNode = selector.GetRandomItem();

                if (selectedNode == "Common Battle")
                {
                    if (commonEncounters.Count > 0)
                    {
                        int selection = random.Next(commonEncounters.Count);
                        nodeEvent = Activator.CreateInstance(commonEncounters[selection], enemyLevel) as CombatEncounter;
                        nodeType = typeof(CombatEncounter).GetCustomAttribute<EventType>()?.TypeName ?? "Common Battle";
                        // scale the encounter to the current enemy level
                        nodeEvent.initializeEvent(enemyLevel);
                        enemyLevel++;
                        // remove the encounter from the list to prevent repeats
                        commonEncounters.RemoveAt(selection);
                    }
                    if (nodeEvent == null)
                    {
                        throw new InvalidOperationException("No valid combat encounter found for node.");
                    }
                }
                else if (selectedNode == "Elite Battle")
                {
                    if (eliteEncounters.Count > 0)
                    {
                        int selection = random.Next(eliteEncounters.Count);
                        nodeEvent = Activator.CreateInstance(eliteEncounters[selection], enemyLevel) as CombatEncounter;
                        nodeType = typeof(CombatEncounter).GetCustomAttribute<EventType>()?.TypeName ?? "Elite Battle";
                        // scale the encounter to the current enemy level
                        nodeEvent.initializeEvent(enemyLevel);
                        enemyLevel++;
                        // remove the encounter from the list to prevent repeats
                        eliteEncounters.RemoveAt(selection);
                    }
                    if (nodeEvent == null)
                    {
                        throw new InvalidOperationException("No valid combat encounter found for node.");
                    }
                }else if (selectedNode == "Shop")
                {
                    nodeEvent = new Shop(enemyLevel);
                    nodeType = "Shop";
                }
                
                else if (selectedNode == "Shop")
                {
                    enemyLevel++;
                    scaleCounter++;
                }
                else
                {
                    scaleCounter = 0;
                }
                MapNode newNode = new MapNode(nodeType, nodeEvent);


                mapNodes.Add(newNode);
            }

            // create the boss node at the end
            MapEvent? bossEvent = null;
            if (bossEncounters.Count > 0)
            {
                bossEvent = Activator.CreateInstance(bossEncounters[random.Next(bossEncounters.Count)], enemyLevel) as CombatEncounter;
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

            for (int i = 0; i < mapNodes.Count; i++)
            {
                // if the encounter is a combat encounter, write enemy list to console
                if (mapNodes[i].GetNodeData() is CombatEncounter)
                {
                    Trace.WriteLine($"Node {i} is a combat encounter with these enemies:");
                    List<Character> enemies = mapNodes[i].GetNodeData().GetEventData<List<Character>>();
                    foreach (var enemy in enemies)
                    {
                        Trace.WriteLine(enemy);
                    }
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

        // helper function to retrieve all defined map events

        private List<Type> getAllEvents()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies().SelectMany(assembly => assembly.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(MapEvent)) && !type.IsAbstract)
                .ToList();

        }

    }
}