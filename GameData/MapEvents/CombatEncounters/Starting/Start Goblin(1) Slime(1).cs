using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents.CombatEncounters.Starting
{
    internal class Start_Goblin_Slime : CombatEncounter
    {
        public Start_Goblin_Slime(int targetLevel) : base(targetLevel)
        {
            eventType = "Starting Battle";
            initializeEvent(targetLevel);
        }
        public override void initializeEvent(int targetLevel)
        {
            enemies = new List<Data.Characters.Character>()
            {
                new Characters.Enemies.Common.Goblin(),
                new Characters.Enemies.Common.Slime()
            };

        }
    }
}
