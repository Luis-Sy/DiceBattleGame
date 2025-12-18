using DiceBattleGame.GameData.Skills;
using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.PlayerSkills;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class DeprivedPlayer : Character
    {
        public DeprivedPlayer() : base()
        {
            type = "Player";
            name = "Deprived";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 0},
                {"Constitution", 2},
                {"Strength", 2},
                {"Dexterity", 2},
                {"Intellect", -1},
                {"Faith", -5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.0 },
                { "Blunt", 1.0 },
                { "Magic", 1.0 },
                { "Radiant", 1.0 },
                { "Arcane", 2.0 },
                { "Psychic", 2.0 }
            };
            armorClass = 10;
            skills.Add(new PocketSand());
            weapon = new Custom("Club", "Wooden Club", "Blunt", new D6());
        }
    }
}
