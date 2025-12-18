using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.EnemySkills;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class Lich : Character
    {
        public Lich() : base()
        {
            type = "Elite Enemy";
            name = "Lich";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 4},
                {"Constitution", 2},
                {"Strength", -1},
                {"Dexterity", 1},
                {"Intellect", 5},
                {"Faith", 3}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 0.8 },
                { "Pierce", 1.25 },
                { "Blunt", 1.5 },
                { "Magic", 0.5 },
                { "Radiant", 1.5 },
                { "Arcane", 0.75 },
                { "Psychic", 1.0 }
            };
            armorClass = 12;
            skills.Add(new SoulSiphon());
            weapon = new Custom("Staff", "Staff of the Damned", "Blunt", new D8());
        }
    }
}
