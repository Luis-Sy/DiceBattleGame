using DiceBattleGame.Data.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Items
{
    internal class StrengthPotion:Item
    {
        public StrengthPotion()
        {
            string name = "Strength Potion";
            int price = 10;
        }

        public override void Use(Character entity) //I dont know if this even works - J
        {
            entity.getStats()["Strength"] = entity.getStats()["Strength"] + 5;
        }
    }
}
