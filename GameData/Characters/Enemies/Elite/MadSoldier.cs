using DiceBattleGame.Data.Characters;
using DiceBattleGame.Data.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class MadSoldier : Character
    {
        public MadSoldier() : base()
        {
            type = "Elite Enemy";
            name = "Mad Soldier";
            statGrowths = new Dictionary<string, int>
            {
                {"Vigor", 4},
                {"Constitution", 4},
                {"Strength", 4},
                {"Dexterity", -2},
                {"Intellect", -3},
                {"Faith", -2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>
            {
                { "Slash", 1.5 },
                { "Pierce", 1.0 },
                { "Blunt", 1.0 }
            };
            armorClass = 15;
            weapon = new Custom("Great Axe", "Berserker's Great Axe", "Slash", new diceBag(9, 2));
        }
    }
}
