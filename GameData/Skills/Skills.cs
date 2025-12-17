using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Skills
{
    public abstract partial class Skill // Might do something silly here, might not, its why the class is partial, disregard - J
    { //TO DO add skill descriptions
        public string Name { get; set; }
        //public int ManaCost { get; set; } // for energy use
        protected Skill(string name)
        {
            Name = name;
        }

        internal virtual int UseSkill(Character entity, Character enemy) //These overloads allow a flexible number of inputs this should be your default when using skills unless to reqiure the others - J
        {
            return 0;
        }
        internal virtual int UseSkill(Character entity)
        {
            return 0;
        }
        internal virtual int UseSkill(Character entity, TurnManager t) //Im just assuming we're going to return the damage of the skill here to save everyone time
        {
            return 0;
        }
    }
}
