using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Items
{
    internal class StrengthPotion:Item
    {
        public StrengthPotion():base("Strength Potion",10, "Increases Strength by 5")
        {
            //string name = "Strength Potion";
            //int price = 10;
        }

        public override void Use(Character entity) //I dont know if this even works - J
        {
            entity.getStats()["Strength"] += 5;
        }

        public string Examine() //hate that the hp restore value must be static :( - J
        {
            return "Increases strength by 5";
        }
    }
}
