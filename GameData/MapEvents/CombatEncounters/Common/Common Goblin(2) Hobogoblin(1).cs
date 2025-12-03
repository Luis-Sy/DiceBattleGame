using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents.CombatEncounters.Common
{
    internal class Common_Goblin_1__Hobogoblin_1_ : CombatEncounter
    {
        public Common_Goblin_1__Hobogoblin_1_(int targetLevel) : base(targetLevel)
        {
            eventType = "Battle";
            initializeEvent(targetLevel);
        }
        public override void initializeEvent(int targetLevel)
        {
            enemies = new List<Character>()
            {
                new Characters.Enemies.Common.Goblin(),
                new Characters.Enemies.Common.Goblin(),
                new Characters.Enemies.Common.Hobogoblin()
            };

            scaleEnemies(targetLevel);
        }
    }
}
