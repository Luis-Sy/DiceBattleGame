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
    internal class ClericPlayer : Character
    {
        public ClericPlayer() : base()
        {
            type = "Player";
            name = "Cleric";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 2},
                {"Constitution", 2},
                {"Strength", 1},
                {"Dexterity", -2},
                {"Intellect", 0},
                {"Faith", 4}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.0 },
                { "Blunt", 1.0 },
                { "Magic", 0.75 },
                { "Radiant", 0.5 },
                { "Arcane", 1.0 },
                { "Psychic", 1.0 }
            };
            armorClass = 14;
            skills.Add(new DivineBlessing());
            weapon = new Custom("Mace", "Holy Mace", "Blunt", new diceBag(7, 2), "Faith");
        }
    }
}
