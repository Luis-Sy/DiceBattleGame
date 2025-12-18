using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.Skills;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class DuelistPlayer : Character
    {
        public DuelistPlayer() : base()
        {
            name = "Duelist";
            type = "Player";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -1},
                {"Constitution", -1},
                {"Strength", -1},
                {"Dexterity", 4},
                {"Intellect", -1},
                {"Faith", -3}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 2.0 },
                { "Pierce", 0.5 },
                { "Blunt", 1.0 },
                { "Magic", 1.5 },
                { "Radiant", 1.0 },
                { "Arcane", 0.75 },
                { "Psychic", 0.5 }
            };
            armorClass = 12;
            skills.Add(new DoubleStrike());
            weapon = new Rapier();
        }
    }
}
