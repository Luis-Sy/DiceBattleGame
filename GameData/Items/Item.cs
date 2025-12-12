using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Items
{ //ABSTRACT CLASS, ADD METHODS.
    public abstract class Item
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description {  get; set; }

        protected Item(string name, int price, string description)
        {
            Name = name;
            Description = description;
            Price = price;
            
        }
        public virtual void Use(Character entity)
        {
            
        }
    }
}
