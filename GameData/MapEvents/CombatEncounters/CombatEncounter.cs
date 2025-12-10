using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.MapEvents.CombatEncounters
{
    public abstract class CombatEncounter : MapEvent // this is the generic class used to represent combat encounters on the map
    {
        protected int targetLevel; // target level for scaling enemy difficulty
        protected List<Character> enemies = new List<Character>(); // list of enemy characters in the encounter

        public CombatEncounter(int targetLevel):base("Combat Encounter")

        {
            this.targetLevel = targetLevel; 
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

        public List<Character> getEnemies()
        {
            return enemies;
        }

        // Fix for CS0508 and CS0453:
        // - Change return type from T? to T to match the base class signature.
        // - Remove use of Nullable<T> (T?) since T can be a reference type or value type.
        public override T GetEventData<T>()
        {
            if (typeof(T) == typeof(List<Character>))
            {
                // Cast enemies to T and return
                return (T)(object)enemies;
            }

            return base.GetEventData<T>();
        }

    }
}
