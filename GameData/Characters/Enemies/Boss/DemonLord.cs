using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Boss
{
    internal class DemonLord : Character
    {
        public DemonLord() : base()
        {
            type = "Boss Enemy";
            name = "Demon Lord";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 25},
                {"Constitution", 20},
                {"Strength", 15},
                {"Dexterity", 10},
                {"Intellect", 10},
                {"Faith", 5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 2.0 },
                { "Pierce", 1.25 },
                { "Blunt", 1.25 },
                { "Magic", 0.5 },
                { "Radiant", 2.0 },
                { "Arcane", 1.5 },
                { "Psychic", 0.5 }
            };
            armorClass = 15;
            weapon = new Custom("Sword", "Demonic Sword", "Arcane", new D20());
        }
    }
}
