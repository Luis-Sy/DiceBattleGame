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
    internal class WardenPlayer : Character
    {
        public WardenPlayer() : base()
        {
            type = "Player";
            name = "Warden";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -2},
                {"Constitution", 5},
                {"Strength", 3},
                {"Dexterity", -2},
                {"Intellect", -3},
                {"Faith", 0}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 0.5 },
                { "Pierce", 1.0 },
                { "Blunt", 1.5 },
                { "Magic", 0.75 },
                { "Radiant", 1.0 },
                { "Arcane", 1.25 },
                { "Psychic", 0.75 }
            };
            armorClass = 16;
            skills.Add(new Shackles());
            weapon = new Custom("Halberd", "Halberd", "Slash", new D10(), "Strength");
        }
    }
}
