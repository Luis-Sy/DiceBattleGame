using DiceBattleGame.Data.Characters;
using DiceBattleGame.Data.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class ElderFragment : Character
    {
        public ElderFragment() : base()
        {
            type = "Elite Enemy";
            name = "Elder Fragment";
            statGrowths = new Dictionary<string, int>
            {
                {"Vigor", 5},
                {"Constitution", 4},
                {"Strength", 3},
                {"Dexterity", -3},
                {"Intellect", 4},
                {"Faith", 5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>
            {
                { "Slash", 1.0 },
                { "Pierce", 1.0 },
                { "Blunt", 2.0 },
            };
            armorClass = 14;
            weapon = new Custom("Crystal Spike", "Elder Crystal Spike", "Pierce", new diceBag(11, 2));
        }
    }
}
