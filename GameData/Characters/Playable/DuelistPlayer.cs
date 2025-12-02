using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class DuelistPlayer : Character
    {
        public DuelistPlayer() : base()
        {
            name = "Duelist";
            type = "Player";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -1},
                {"Constitution", -1},
                {"Strength", -1},
                {"Dexterity", 4},
                {"Intellect", -1},
                {"Faith", -3}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 2.0 },
                { "Pierce", 0.5 },
                { "Blunt", 1.0 }
            };
            armorClass = 12;
            weapon = new Rapier();
        }
    }
}
