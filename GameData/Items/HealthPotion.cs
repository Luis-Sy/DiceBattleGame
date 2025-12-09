using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Items
{
    internal class HealthPotion : Item
    {
      

        public HealthPotion():base("Health Potion",10,"Restores 5 HP") { 
        }
        

        public override void Use(Character entity) //uses the changehp method on characters to add the value to the hp, value given must be an int
        {
            entity.changeHp(5);
        }

        public string Examine() //hate that the hp restore value must be static :( - J
        {
            return "This health potion restores 5 hp";       
        }
    }
}
