using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.EnemySkills;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class ElderFragment : Character
    {
        public ElderFragment() : base()
        {
            type = "Elite Enemy";
            name = "Elder Fragment";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 5},
                {"Constitution", 4},
                {"Strength", 3},
                {"Dexterity", -3},
                {"Intellect", 4},
                {"Faith", 5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.0 },
                { "Blunt", 2.0 },
                { "Magic", 0.5 },
                { "Radiant", 1.25 },
                { "Arcane", 0.75 },
                { "Psychic", 0.75 }
            };
            armorClass = 14;
            skills.Add(new Scorn());
            skills.Add(new Enlighten());
            weapon = new Custom("Crystal Spike", "Elder Crystal Spike", "Pierce", new diceBag(7, 2));
        }
    }
}
