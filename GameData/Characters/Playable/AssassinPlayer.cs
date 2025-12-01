using DiceBattleGame.Data.Characters;
using DiceBattleGame.Data.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class AssassinPlayer : Character
    {
        public AssassinPlayer() : base()
        {
            type = "Player";
            name = "Assassin";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -3},
                {"Constitution", -1},
                {"Strength", -2},
                {"Dexterity", 5},
                {"Intellect", 3},
                {"Faith", -2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 2.0 },
                { "Pierce", 0.5 },
                { "Blunt", 1.5 }
            };
            armorClass = 12;
            weapon = new Custom("Daggers", "Twin Daggers", "Pierce", new diceBag(7, 2));
        }
    }
}
