using DiceBattleGame.Data.Characters;
using DiceBattleGame.Data.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Boss
{
    internal class Dragon : Character
    {

        public Dragon() : base()
        {
            type = "Boss Enemy";
            name = "Dragon";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 20},
                {"Constitution", 15},
                {"Strength", 10},
                {"Dexterity", 8},
                {"Intellect", 8},
                {"Faith", 6}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 2.0 },
                { "Blunt", 0.75 },
            };
            armorClass = 18;
            weapon = new Custom("Flame Breath", "A powerful breath of fire", "Fire", new diceBag(11, 3));
        }
    }
}
