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
    internal class MadSoldier_2__Commander_1_ : CombatEncounter
    {
        public MadSoldier_2__Commander_1_(int targetLevel) : base(targetLevel)
        {

            eventType = "Elite Battle";
            initializeEvent(targetLevel);
        }

        public override void initializeEvent(int targetLevel)
        {
            enemies = new List<Character>()
            {
                new MadSoldier(),
                new MadSoldier(),
                new MadCommander()
            };

            scaleEnemies(targetLevel);
        }
    }
}
