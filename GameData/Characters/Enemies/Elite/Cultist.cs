using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.EnemySkills;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class Cultist : Character
    {
        public Cultist() : base()
        {
            type = "Elite Enemy";
            name = "Cultist";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 5},
                {"Constitution", -3},
                {"Strength", -2},
                {"Dexterity", 2},
                {"Intellect", 3},
                {"Faith", 5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.5 },
                { "Blunt", 1.0 },
                { "Magic", 0.5 },
                { "Radiant", 2.0 },
                { "Arcane", 0.5 },
                { "Psychic", 1.0 }
            };
            armorClass = 13;
            skills.Add(new FireBolt());
            weapon = new Custom("Dagger", "Ritual Dagger", "Pierce", new D6());
        }
    }
}
