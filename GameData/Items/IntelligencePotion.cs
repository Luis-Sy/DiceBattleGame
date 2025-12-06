using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Items
{
    internal class IntelligencePotion:Item
    {
        public IntelligencePotion() 
        {
            string name = "Intelligence Potion";
            int price = 10;
        }

        public override void Use(Character entity)
        {
            entity.getStats()["Intelect"] += 5;
        }

        public string Examine() //hate that the hp restore value must be static :( - J
        {
            return "Increases intellect by 5";
        }
    }
}
