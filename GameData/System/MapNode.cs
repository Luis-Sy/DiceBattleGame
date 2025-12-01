using DiceBattleGame.GameData.MapEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.System
{
    internal class MapNode // this is the container class used to represent the nodes on the map during a campaign
    {
        private string nodeType = "undefined"; // type of node (e.g., battle, shop, event, rest, etc.)
        private bool isVisited = false; // whether the node has been visited by the player
        private MapEvent nodeData;
        public MapNode next;

        public MapNode(string type, MapEvent data)
        {
            nodeType = type;
            nodeData = data;
        }

        public void VisitNode()
        {
            // mark the node as visited and execute its event behavior
            isVisited = true;
            // determine behavior based on node type and then pass control to the appropriate form

            // to be implemented
        }

        public string GetNodeType()
        {
            return nodeType;
        }

        public MapEvent GetNodeData()
        {
            return nodeData;
        }

        public bool IsVisited()
        {
            return isVisited;
        }

    }
}
