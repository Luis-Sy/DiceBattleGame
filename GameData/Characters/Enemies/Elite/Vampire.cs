using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.EnemySkills;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class Vampire : Character
    {
        public Vampire() : base()
        {
            type = "Elite Enemy";
            name = "Vampire";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 5},
                {"Constitution", 5},
                {"Strength", 4},
                {"Dexterity", 5},
                {"Intellect", 3},
                {"Faith", 2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 0.5 },
                { "Pierce", 2.0 },
                { "Blunt", 0.5 },
                { "Magic", 1.0 },
                { "Radiant", 2.0 },
                { "Arcane", 1.5 },
                { "Psychic", 0.5 }
            };
            armorClass = 16;
            skills.Add(new LifeDrain());
            weapon = new Custom("Claws", "Vampire's Claws", "Slash", new D12());
        }
    }
}
