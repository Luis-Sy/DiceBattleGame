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
    internal class Bandit_2_ : CombatEncounter
    {
        public Bandit_2_(int targetLevel) : base(targetLevel)
        {
            eventType = "Battle";
            initializeEvent(targetLevel);
        }
        public override void initializeEvent(int targetLevel)
        {
            enemies = new List<Character>()
            {
                new Bandit(),
                new Bandit()
            };

            scaleEnemies(targetLevel);
        }
    }
}
