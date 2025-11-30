using DiceBattleGame.Data.Characters;
using DiceBattleGame.Data.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Characters.Enemies.Common
{
    internal class Skeleton : Character
    {
        public Skeleton() : base()
        {
            type = "Enemy";
            name = "Skeleton";
            statGrowths = new Dictionary<string, int>
            {
                {"Vigor", -5},
                {"Constitution", -5},
                {"Strength", 3},
                {"Dexterity", 3},
                {"Intellect", -5},
                {"Faith", -5}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>
            {
                { "Slash", 0.5 },
                { "Pierce", 0.5 },
                { "Blunt", 1.5 }
            };
            armorClass = 12;
            weapon = new Custom("Bone Sword", "Rusty Bone Sword", "Slash", new D8());
        }
    }
}
