using DiceBattleGame.Data.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Common
{
    internal class Hobogoblin : Character
    {
        public Hobogoblin() : base()
        {
            type = "Enemy";
            name = "Hobogoblin";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 1},
                {"Constitution", 3},
                {"Strength", 2},
                {"Dexterity", -1},
                {"Intellect", -2},
                {"Faith", -2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.5 },
                { "Blunt", 0.5 }
            };
            armorClass = 14;
            weapon = new Custom("Shortsword", "Rusty Shortsword", "Slash", new D6());
        }
    }
}
