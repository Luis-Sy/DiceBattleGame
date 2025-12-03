using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.Characters.Enemies.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents.CombatEncounters.Starting
{
    internal class Start_Goblin_2_ : CombatEncounter
    {
        public Start_Goblin_2_(int targetLevel) : base(targetLevel)
        {
            eventType = "Starting Battle";
            initializeEvent(targetLevel);
        }
        public override void initializeEvent(int targetLevel)
        {
            enemies = new List<Character>()
            {
                new Goblin(),
                new Goblin()
            };

        }
    }
}
