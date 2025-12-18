using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class Werewolf : Character
    {
        public Werewolf() : base()
        {
            type = "Elite Enemy";
            name = "Werewolf";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 5},
                {"Constitution", 5},
                {"Strength", 5},
                {"Dexterity", 3},
                {"Intellect", -4},
                {"Faith", -4}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 0.5 },
                { "Pierce", 1.5 },
                { "Blunt", 1.0 },
                { "Magic", 1.0 },
                { "Radiant", 2.0 },
                { "Arcane", 1.0 },
                { "Psychic", 1.5 }
            };
            armorClass = 16;
            weapon = new Custom("Claws", "Razor Claws", "Slash", new diceBag(5, 2));
        }
    }
}
