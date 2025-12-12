using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class FallenNoblePlayer : Character
    {
        public FallenNoblePlayer() : base()
        {
            type = "Player";
            name = "Fallen Noble";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -1},
                {"Constitution", 2},
                {"Strength", 0},
                {"Dexterity", 2},
                {"Intellect", 3},
                {"Faith", 2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.25 },
                { "Pierce", 1.25 },
                { "Blunt", 1.25 },
                { "Magic", 1.25 },
                { "Radiant", 1.25 },
                { "Arcane", 1.25 },
                { "Psychic", 0.5 }
            };
            armorClass = 15;
            weapon = new Custom("Rapier", "Worn Rapier", "Pierce", new D8());
        }
    }
}
