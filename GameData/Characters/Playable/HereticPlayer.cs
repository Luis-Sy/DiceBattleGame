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
                { "Blunt", 1.0 },
                { "Magic", 1.0 },
                { "Radiant", 1.5 },
                { "Arcane", 0.5 },
                { "Psychic", 0.75 }
            };
            armorClass = 11;
            skills.Add(new Afflict());
            weapon = new Custom("Staff", "Occult Staff", "Blunt", new D8());
        }
    }
}
