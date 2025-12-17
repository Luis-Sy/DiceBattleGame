using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.EnemySkills;

namespace DiceBattleGame.GameData.Characters.Enemies.Common
{
    internal class Mercenary : Character
    {
        public Mercenary() : base()
        {
            type = "Enemy";
            name = "Mercenary";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 0},
                {"Constitution", 1},
                {"Strength", 2},
                {"Dexterity", 2},
                {"Intellect", -1},
                {"Faith", -3}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.25 },
                { "Pierce", 1.0 },
                { "Blunt", 1.5 },
                { "Magic", 1.0 },
                { "Radiant", 0.75 },
                { "Arcane", 1.0 },
                { "Psychic", 1.0 }
            };
            armorClass = 14;
            skills.Add(new SneakyStrike());
            skills.Add(new SwiftSlice());
            weapon = new Custom("Sword", "Broad Sword", "Slash", new D8());
        }
    }
}
