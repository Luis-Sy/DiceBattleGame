using DiceBattleGame.GameData.Characters.Enemies.Elite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents.CombatEncounters.Elite
{
    internal class Elite_Cultist_1_ : CombatEncounter
    {
        public Elite_Cultist_1_(int targetLevel) : base(targetLevel)
        {
            eventType = "Elite Battle";
            initializeEvent(targetLevel);
        }
        public override void initializeEvent(int targetLevel)
        {
            enemies = new List<Data.Characters.Character>()
            {
                new Cultist()
            };

            scaleEnemies(targetLevel);
        }
    }
}
