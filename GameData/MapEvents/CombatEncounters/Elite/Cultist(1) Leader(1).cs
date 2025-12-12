using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.Characters.Enemies.Elite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents.CombatEncounters.Elite
{
    [EventType("Elite Battle")]
    internal class Cultist_1__Leader_1_ : CombatEncounter
    {
        public Cultist_1__Leader_1_(int targetLevel) : base(targetLevel){
            eventType = "Elite Battle";
            initializeEvent(targetLevel);
        }

        public override void initializeEvent(int targetLevel)
        {
            enemies = new List<Character>()
            {
                new Cultist(),
                new CultistLeader()
            };

            scaleEnemies(targetLevel);
        }
    }
}
