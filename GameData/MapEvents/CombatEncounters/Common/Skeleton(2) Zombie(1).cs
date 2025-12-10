using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.Characters.Enemies.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents.CombatEncounters.Common
{
    [EventType("Common Battle")]
    public class Skeleton_2__Zombie_1_ : CombatEncounter
    {
        public Skeleton_2__Zombie_1_(int targetLevel) : base(targetLevel)
        {
            eventType = "Battle";
            initializeEvent(targetLevel);
        }
        public override void initializeEvent(int targetLevel)
        {
            enemies = new List<Character>()
            {
                new Skeleton(),
                new Skeleton(),
                new Zombie()
            };

            scaleEnemies(targetLevel);
        }
    }
}
