using DiceBattleGame.Data.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class HereticPlayer : Character
    {
        public HereticPlayer() : base()
        {
            type = "Player";
            name = "Heretic";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -2},
                {"Constitution", -2},
                {"Strength", 1},
                {"Dexterity", 3},
                {"Intellect", 4},
                {"Faith", 2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.5 },
                { "Blunt", 1.0 }
            };
            armorClass = 11;
            weapon = new Custom("Staff", "Occult Staff", "Blunt", new D8());
        }
    }
}
