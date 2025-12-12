using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents.CombatEncounters.Boss
{
    [EventType("Boss Battle")]
    public class Dragon_1_ : CombatEncounter
    {
        public Dragon_1_(int targetLevel) : base(targetLevel)
        {
            eventType = "Starting Battle";
            initializeEvent(targetLevel);
        }
        public override void initializeEvent(int targetLevel)
        {
            enemies = new List<Character>()
            {
                new Characters.Enemies.Boss.Dragon()
            };

            scaleEnemies(targetLevel);
        }
    }
}
