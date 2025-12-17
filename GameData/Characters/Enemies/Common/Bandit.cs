using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.EnemySkills;

namespace DiceBattleGame.GameData.Characters.Enemies.Common
{
    internal class Bandit : Character
    {
        public Bandit() : base()
        {
            type = "Enemy";
            name = "Bandit";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -3},
                {"Constitution", 0},
                {"Strength", 1},
                {"Dexterity", 3},
                {"Intellect", -2},
                {"Faith", -2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.5 },
                { "Pierce", 1.0 },
                { "Blunt", 1.0 },
                { "Magic", 1.0 },
                { "Radiant", 1.0 },
                { "Arcane", 1.0 },
                { "Psychic", 1.0 }
            };
            armorClass = 12;
            skills.Add(new SneakyStrike());
            skills.Add(new SwiftSlice());
            weapon = new Custom("Dagger", "Sharp Dagger", "Pierce", new diceBag(5, 2));
        }
    }
}
