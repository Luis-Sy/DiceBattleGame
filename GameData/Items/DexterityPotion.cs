using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Items
{
    internal class DexterityPotion:Item
    {
        public DexterityPotion():base("Dexeterity Potion",10, "Increases Dexterity by 5")
        {
            
        }

        public override void Use(Character entity)
        {
            entity.getStats()["Dexterity"] += 5;
        }

        public string Examine() //hate that the hp restore value must be static :( - J
        {
            return "Increases dexterity by 5";
        }
    }
}
