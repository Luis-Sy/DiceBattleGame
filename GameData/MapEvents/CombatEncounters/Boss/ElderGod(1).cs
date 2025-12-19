using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents.CombatEncounters.Boss
{
    [EventType("Boss Battle")]
    internal class ElderGod_1_ : CombatEncounter
    {
        public ElderGod_1_(int targetLevel) : base(targetLevel)
        {
            initializeEvent(targetLevel);
        }
        public override void initializeEvent(int targetLevel)
        {
            enemies = new List<Character>()
            {
                new Characters.Enemies.Boss.ElderGod()
            };
            scaleEnemies(targetLevel);
        }
    }
}
