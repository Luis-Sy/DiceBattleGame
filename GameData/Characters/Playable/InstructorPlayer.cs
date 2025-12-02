using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class InstructorPlayer : Character
    {
        public InstructorPlayer() : base()
        {
            type = "Player";
            name = "Instructor";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 2},
                {"Constitution", 3},
                {"Strength", 2},
                {"Dexterity", 2},
                {"Intellect", 4},
                {"Faith", -2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.5 },
                { "Blunt", 1.0 }
            };
            armorClass = 14;
            weapon = new Custom("Whip", "Leather Whip", "Slash", new diceBag(7, 2));
        }
    }
}
