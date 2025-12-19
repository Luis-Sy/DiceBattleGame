using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Common
{
    internal class Goblin : Character
    {
        public Goblin() : base()
        {
            type = "Enemy";
            name = "Goblin";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -3},
                {"Constitution", -2},
                {"Strength", 0},
                {"Dexterity", 2},
                {"Intellect", -3},
                {"Faith", -2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.25 },
                { "Pierce", 1.25 },
                { "Blunt", 1.25 },
                { "Magic", 1.0 },
                { "Radiant", 0.75 },
                { "Arcane", 1.0 },
                { "Psychic", 0.5 }
            };
            armorClass = 10;
            weapon = new Custom("Club", "Dirty Club", "Blunt", new D4(), "Strength");
        }
    }
}
