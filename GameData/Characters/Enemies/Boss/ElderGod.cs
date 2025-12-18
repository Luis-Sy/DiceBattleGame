using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Boss
{
    internal class ElderGod : Character
    {
        public ElderGod() : base()
        {
            type = "Boss Enemy";
            name = "Elder God";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 35},
                {"Constitution", 25},
                {"Strength", 15},
                {"Dexterity", 10},
                {"Intellect", 25},
                {"Faith", 25}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.5 },
                { "Pierce", 1.0 },
                { "Blunt", 1.0 },
                { "Magic", 0.25 },
                { "Radiant", 2.0 },
                { "Arcane", 0.5 },
                { "Psychic", 0.5 }
            };
            armorClass = 14;
            weapon = new Custom("Arcane", "Eldritch Tendrils", "Arcane", new diceBag(9, 2));
        }
    }
}
