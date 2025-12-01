using DiceBattleGame.Data.Characters;
using DiceBattleGame.Data.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Common
{
    internal class Orc : Character
    {
        public Orc() : base()
        {
            type = "Enemy";
            name = "Orc";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 5},
                {"Constitution", 3},
                {"Strength", 3},
                {"Dexterity", -2},
                {"Intellect", -3},
                {"Faith", -2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 0.5 },
                { "Pierce", 1.5 },
                { "Blunt", 1.5 }
            };
            armorClass = 16;
            weapon = new Custom("Axe", "Battle Axe", "Slash", new D12());
        }
    }
}
