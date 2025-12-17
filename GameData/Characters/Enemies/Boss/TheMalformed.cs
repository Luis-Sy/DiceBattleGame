using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Boss
{
    internal class TheMalformed : Character
    {
        public TheMalformed() : base()
        {
            type = "Boss Enemy";
            name = "The Malformed";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 35},
                {"Constitution", 35},
                {"Strength", 12},
                {"Dexterity", 18},
                {"Intellect", 10},
                {"Faith", 10}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.25 },
                { "Pierce", 1.5 },
                { "Blunt", 1.0 },
                { "Magic", 0.5 },
                { "Radiant", 1.75 },
                { "Arcane", 1.25 },
                { "Psychic", 0.75 }
            };
            armorClass = 15;
            weapon = new Custom("Claws", "Mutated Claws", "Arcane", new diceBag(11, 2));
        }
    }
}
