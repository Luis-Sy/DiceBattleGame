using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class Samurai : Character
    {
        public Samurai() : base()
        {
            type = "Player";
            name = "Samurai";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -2},
                {"Constitution", 4},
                {"Strength", 4},
                {"Dexterity", 1},
                {"Intellect", -2},
                {"Faith", -3}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 0.5 },
                { "Pierce", 1.25 },
                { "Blunt", 1.25 }
            };
            armorClass = 17;
            weapon = new Custom("Katana", "Aged Katana", "Slash", new D10());
        }
    }
}
