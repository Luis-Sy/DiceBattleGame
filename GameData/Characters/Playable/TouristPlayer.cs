using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class TouristPlayer : Character
    {
        public TouristPlayer() : base()
        {
            type = "Player";
            name = "Tourist";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -2},
                {"Constitution", -3},
                {"Strength", -2},
                {"Dexterity", 1},
                {"Intellect", 5},
                {"Faith", 4}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.25 },
                { "Pierce", 1.25 },
                { "Blunt", 1.25 },
                { "Magic", 1.0 },
                { "Radiant", 0.5 },
                { "Arcane", 1.0 },
                { "Psychic", 1.5 }
            };
            armorClass = 14;
            weapon = new Custom("Camera", "Digital Camera", "Blunt", new D8());
        }
    }
}
