using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class KnightPlayer : Character
    {
        public KnightPlayer() : base()
        {
            type = "Player";
            name = "Knight";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 2},
                {"Constitution", 2},
                {"Strength", 3},
                {"Dexterity", -3},
                {"Intellect", -4},
                {"Faith", -1}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 0.5 },
                { "Blunt", 2.0 }
            };
            armorClass = 15;
            weapon = new Sword();
        }
    }
}
