using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.EnemySkills;

namespace DiceBattleGame.GameData.Characters.Enemies.Common
{
    internal class Skeleton : Character
    {
        public Skeleton() : base()
        {
            type = "Enemy";
            name = "Skeleton";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -5},
                {"Constitution", -5},
                {"Strength", 3},
                {"Dexterity", 3},
                {"Intellect", -5},
                {"Faith", -5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 0.5 },
                { "Pierce", 0.5 },
                { "Blunt", 1.5 },
                { "Magic", 1.0 },
                { "Radiant", 2.0 },
                { "Arcane", 1.0 },
                { "Psychic", 0.5 }
            };
            armorClass = 12;
            skills.Add(new SneakyStrike());
            weapon = new Custom("Sword", "Rusty Bone Sword", "Slash", new D8());
        }
    }
}
