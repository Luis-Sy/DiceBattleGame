using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.EnemySkills;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class MadSoldier : Character
    {
        public MadSoldier() : base()
        {
            type = "Elite Enemy";
            name = "Mad Soldier";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 4},
                {"Constitution", 4},
                {"Strength", 4},
                {"Dexterity", -2},
                {"Intellect", -3},
                {"Faith", -2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.5 },
                { "Pierce", 1.0 },
                { "Blunt", 1.0 },
                { "Magic", 0.5 },
                { "Radiant", 0.5 },
                { "Arcane", 1.0 },
                { "Psychic", 1.0 }
            };
            armorClass = 15;
            skills.Add(new FrenziedStrike());
            weapon = new Custom("Axe", "Berserker's Great Axe", "Slash", new D8());
        }
    }
}
