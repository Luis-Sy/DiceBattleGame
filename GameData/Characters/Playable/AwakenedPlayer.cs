using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class AwakenedPlayer : Character
    {
        public AwakenedPlayer() : base()
        {
            type = "Player";
            name = "Awakened";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -3},
                {"Constitution", 4},
                {"Strength", -2},
                {"Dexterity", 2},
                {"Intellect", 3},
                {"Faith", 3}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.0 },
                { "Blunt", 1.0 }
            };
            armorClass = 12;
            weapon = new Custom("Magic Staff", "Staff of Awakening", "Blunt", new diceBag(7, 2));
        }
    }
}
