
using DiceBattleGame.Data.Characters;
using DiceBattleGame.Data.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class Lich : Character
    {
        public Lich() : base()
        {
            type = "Elite Enemy";
            name = "Lich";
            statGrowths = new Dictionary<string, int>
            {
                {"Vigor", 4},
                {"Constitution", 2},
                {"Strength", -1},
                {"Dexterity", 1},
                {"Intellect", 5},
                {"Faith", 3}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>
            {
                { "Slash", 0.8 },
                { "Pierce", 1.25 },
                { "Blunt", 1.5 },
            };
            armorClass = 12;
            weapon = new Custom("Staff", "Staff of the Damned", "Blunt", new diceBag(7, 2));
        }
    }
}
