using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.Data.Characters.Playable
{
    internal class PaladinPlayer : Character
    {
        public PaladinPlayer() : base()
        {
            type = "Player";
            name = "Paladin";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 2},
                {"Constitution", 3},
                {"Strength", 2},
                {"Dexterity", -3},
                {"Intellect", -3},
                {"Faith", 3}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 0.5 },
                { "Pierce", 1.0 },
                { "Blunt", 1.5 }
            };
            armorClass = 16;
            weapon = new Hammer();
        }
    }
}
