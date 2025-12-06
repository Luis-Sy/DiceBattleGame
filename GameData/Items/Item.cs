using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Items
{ //ABSTRACT CLASS, ADD METHODS.
    internal abstract class Item
    {
        string name;
        int price;

        public virtual void Use(Character entity)
        {
            
        }
    }
}
