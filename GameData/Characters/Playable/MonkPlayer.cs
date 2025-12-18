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
    internal class MonkPlayer : Character
    {
        public MonkPlayer() : base()
        {
            type = "Player";
            name = "Monk";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -1},
                {"Constitution", 2},
                {"Strength", 1},
                {"Dexterity", 4},
                {"Intellect", 0},
                {"Faith", 3}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.0 },
                { "Blunt", 1.0 },
                { "Magic", 1.5 },
                { "Radiant", 1.5 },
                { "Arcane", 0.5 },
                { "Psychic", 0.5 }
            };
            armorClass = 14;
            skills.Add(new TheOnePunch());
            weapon = new Custom("Fists", "Monk's Fists", "Blunt", new diceBag(5, 2));
        }
    }
}
