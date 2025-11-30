using DiceBattleGame.Data.Characters;
using DiceBattleGame.Data.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class Mimic : Character
    {
        public Mimic() : base()
        {
            type = "Elite Enemy";
            name = "Mimic";
            statGrowths = new Dictionary<string, int>
            {
                {"Vigor", 5},
                {"Constitution", 4},
                {"Strength", 3},
                {"Dexterity", 2},
                {"Intellect", -5},
                {"Faith", -5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>
            {
                { "Slash", 1.5 },
                { "Pierce", 1.0 },
                { "Blunt", 0.5 },
            };
            armorClass = 16;
            weapon = new Custom("Bite", "Mimic's Jaw", "Pierce", new D10());
        }
    }
}
