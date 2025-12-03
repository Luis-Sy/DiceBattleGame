using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents.CombatEncounters
{
    internal abstract class CombatEncounter : MapEvent // this is the generic class used to represent combat encounters on the map
    {
        protected int targetLevel; // target level for scaling enemy difficulty
        protected List<Character> enemies = new List<Character>(); // list of enemy characters in the encounter
        
        public CombatEncounter(int targetLevel)
        {
            initializeEvent(targetLevel);
        }

        public override void initializeEvent(int targetLevel)
        {
            // override in derived classes to create specific encounters
            // this is a test message to ensure it works
            Console.WriteLine("Creating generic combat encounter at level " + targetLevel);
        }

        public void scaleEnemies(int targetLevel)
        {
            this.targetLevel = targetLevel;
            foreach (var enemy in enemies)
            {
                enemy.setLevel(targetLevel);
            }
        }

        public override T GetEventData<T>()
        {
            if (typeof(T) == typeof(List<Character>))
            {
                return (T)(object)enemies;
            }
            return default(T);
        }
    }
}
