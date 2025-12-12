using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Items
{
    internal class FaithPotion:Item
    {
        public FaithPotion() :base("Faith Potion",10,"Description")
        {
            //string name = "Faith Potion"; //just read a prayer book really fast or some random mushroom
            //int price = 10;
        }

        public override void Use(Character entity)
        {
            entity.getStats()["Faith"] += 5;
        }

        public string Examine() //hate that the hp restore value must be static :( - J
        {
            return "Increases faith by 5";
        }
    }
}
