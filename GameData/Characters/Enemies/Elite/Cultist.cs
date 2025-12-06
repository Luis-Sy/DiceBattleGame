using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class Cultist : Character
    {
        public Cultist() : base()
        {
            type = "Elite Enemy";
            name = "Cultist";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 5},
                {"Constitution", -3},
                {"Strength", -2},
                {"Dexterity", 2},
                {"Intellect", 3},
                {"Faith", 5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.5 },
                { "Blunt", 1.0 }
            };
            armorClass = 13;
            weapon = new Custom("Dagger", "Ritual Dagger", "Pierce", new diceBag(5, 3));
        }
    }
}
