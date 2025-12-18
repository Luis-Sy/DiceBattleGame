using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.EnemySkills;

namespace DiceBattleGame.GameData.Characters.Enemies.Boss
{
    internal class LichKing : Character
    {
        public LichKing() : base()
        {
            type = "Boss Enemy";
            name = "Lich King";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 15},
                {"Constitution", 10},
                {"Strength", 8},
                {"Dexterity", 12},
                {"Intellect", 20},
                {"Faith", 15}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.5 },
                { "Pierce", 1.0 },
                { "Blunt", 1.25 },
                { "Magic", 0.5 },
                { "Radiant", 2.0 },
                { "Arcane", 0.75 },
                { "Psychic", 1.0 }
            };
            armorClass = 15;
            skills.Add(new SoulSiphon());
            weapon = new Custom("Staff", "Frostmourne", "Magic", new diceBag(7, 3));
        }
    }
}
