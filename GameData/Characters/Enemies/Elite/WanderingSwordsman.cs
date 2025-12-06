using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class WanderingSwordsman : Character
    {
        public WanderingSwordsman() : base()
        {
            type = "Elite Enemy";
            name = "Wandering Swordsman";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -3},
                {"Constitution", -3},
                {"Strength", 3},
                {"Dexterity", 5},
                {"Intellect", 2},
                {"Faith", 2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 0.5 },
                { "Pierce", 1.25 },
                { "Blunt", 1.25 },
            };
            armorClass = 18;
            weapon = new Custom("Sword", "Katana", "Slash", new D10());
        }
    }
}
