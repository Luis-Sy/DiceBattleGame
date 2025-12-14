using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Boss
{
    internal class DarkAvatar : Character
    {
        public DarkAvatar() : base()
        {
            type = "Boss Enemy";
            name = "Dark Avatar";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 30},
                {"Constitution", 15},
                {"Strength", 5},
                {"Dexterity", 25},
                {"Intellect", 5},
                {"Faith", 5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 2.0 },
                { "Pierce", 2.0 },
                { "Blunt", 2.0 },
                { "Magic", 0.25 },
                { "Radiant", 2.0 },
                { "Arcane", 1.75 },
                { "Psychic", 0.5 }
            };
            armorClass = 14;
            weapon = new Custom("Claws", "Shadow Claws", "Arcane", new diceBag(9, 3));
        }
    }
}
