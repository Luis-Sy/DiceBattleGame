using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Elite
{
    internal class CultistLeader : Character
    {
        public CultistLeader() : base()
        {
            type = "Elite Enemy";
            name = "Cultist Leader";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", 5},
                {"Constitution", 2},
                {"Strength", 0},
                {"Dexterity", 3},
                {"Intellect", 5},
                {"Faith", 5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 1.0 },
                { "Pierce", 1.25 },
                { "Blunt", 1.5 },
                { "Magic", 0.5 },
                { "Radiant", 0.5 },
                { "Arcane", 0.75 },
                { "Psychic", 0.5 }
            };
            armorClass = 14;
            weapon = new Custom("Ritual Staff", "Ornate Ritual Staff", "Blunt", new diceBag(7, 2));
        }
    }
}
