using DiceBattleGame.Data.System;
using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.Data.Characters.Playable
{
    internal class RangerPlayer : Character
    {
        public RangerPlayer() : base()
        {
            type = "Player";
            name = "Ranger";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -4},
                {"Constitution", 1},
                {"Strength", 1},
                {"Dexterity", 4},
                {"Intellect", 0},
                {"Faith", -2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.5 },
                { "Pierce", 1.0 },
                { "Blunt", 1.0 }
            };
            
            armorClass = 13;
            weapon = new Custom("Bow", "Longbow", "Pierce", new diceBag(7, 2));
        }
    }
}
