using DiceBattleGame.GameData.Characters;
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
                { "Blunt", 1.0 },
                { "Magic", 1.0 },
                { "Radiant", 1.0 },
                { "Arcane", 1.5 },
                { "Psychic", 0.5 }
            };
            
            armorClass = 13;
            skills.Add(new RainOfArrows());
            weapon = new Custom("Bow", "Longbow", "Pierce", new diceBag(7, 2), "Dexterity");
        }
    }
}
