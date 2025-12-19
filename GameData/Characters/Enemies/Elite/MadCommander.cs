using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.EnemySkills;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class MadCommander : Character
    {
        public MadCommander() : base()
        {
            type = "Elite Enemy";
            name = "Mad Commander";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 5},
                {"Constitution", 3},
                {"Strength", 5},
                {"Dexterity", 0},
                {"Intellect", -2},
                {"Faith", -1}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.5 },
                { "Blunt", 0.75 },
                { "Magic", 1.0 },
                { "Radiant", 1.0 },
                { "Arcane", 1.0 },
                { "Psychic", 1.5 }
            };
            armorClass = 14;
            skills.Add(new FrenziedStrike());
            weapon = new Custom("Spear", "War Commander's Standard", "Pierce", new D12(), "Strength");
        }
    }
}
