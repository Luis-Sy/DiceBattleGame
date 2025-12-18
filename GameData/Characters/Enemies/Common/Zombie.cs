using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.EnemySkills;

namespace DiceBattleGame.GameData.Characters.Enemies.Common
{
    internal class Zombie : Character
    {
        public Zombie() : base()
        {
            type = "Enemy";
            name = "Zombie";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 5},
                {"Constitution", 5},
                {"Strength", 3},
                {"Dexterity", -5},
                {"Intellect", -5},
                {"Faith", -5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.5 },
                { "Pierce", 1.0 },
                { "Blunt", 0.5 },
                { "Magic", 1.5 },
                { "Radiant", 2.0 },
                { "Arcane", 1.0 },
                { "Psychic", 0.5 }
            };
            armorClass = 10;
            skills.Add(new Bite());
            weapon = new Custom("Club", "Rotten Club", "Blunt", new D6());
        }
    }
}
