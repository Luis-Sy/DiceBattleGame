using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DiceBattleGame.GameData.Skills.PlayerSkills;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class BerserkerPlayer : Character
    {
        public BerserkerPlayer() : base()
        {
            type = "Player";
            name = "Berserker";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 3},
                {"Constitution", 2},
                {"Strength", 4},
                {"Dexterity", 0},
                {"Intellect", -4},
                {"Faith", -1}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.5 },
                { "Blunt", 1.0 },
                { "Magic", 1.0 },
                { "Radiant", 1.0 },
                { "Arcane", 1.5 },
                { "Psychic", 1.5 }
            };
            armorClass = 13;
            skills.Add(new KillingBlow());
            weapon = new Custom("Axe", "Battle Axe", "Slash", new D10());
        }
    }
}
