using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Common
{
    internal class Slime : Character
    {
        public Slime() : base()
        {
            type = "Enemy";
            name = "Slime";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -4},
                {"Constitution", 5},
                {"Strength", -2},
                {"Dexterity", -3},
                {"Intellect", -5},
                {"Faith", -5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.5 },
                { "Pierce", 1.5 },
                { "Blunt", 0.5 }
            };
            armorClass = 8;
            weapon = new Custom("Pseudopod", "Gooey Pseudopod", "Blunt", new diceBag(5,2));
        }
    }
}
