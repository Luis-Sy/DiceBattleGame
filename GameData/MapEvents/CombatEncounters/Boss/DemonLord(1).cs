using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents.CombatEncounters.Boss
{
    [EventType("Boss Battle")]
    internal class DemonLord_1_ : CombatEncounter
    {
        public DemonLord_1_(int targetLevel) : base(targetLevel)
        {
            initializeEvent(targetLevel);
        }
        public override void initializeEvent(int targetLevel)
        {
            enemies = new List<Characters.Character>()
            {
                new Characters.Enemies.Boss.DemonLord()
            };
            scaleEnemies(targetLevel);
        }
    }
}
