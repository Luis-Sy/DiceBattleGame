using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame
{
    internal abstract class Dice
    {
        private int sides = 2;
        private string name = "Abstract dice"; //this is for debugging

        Random roll = new Random();
        public virtual int Roll()
        {
            Console.WriteLine("If youre seeing this, something has gone wrong involving the Dice class");
            return roll.Next(1, sides);
        }

    }

    // flexible class made for rolling multiple dice at once
    internal class diceBag : Dice
    {
        private int sides;
        private int amount;

        Random roll = new Random();

        public diceBag(int sides, int amount)
        {
            this.sides = sides;
            this.amount = amount;
        }

        public override int Roll()
        {
            int sum = 0;
            for(int i = 0; i < this.amount; i++)
            {
                sum += this.roll.Next(1, this.sides);
            }
            return sum;
        }
    }

    internal class D20 : Dice
    {
        private int sides = 21; //needs max value +1 so it actually rolls the 20, changes made in the other dice types
        private string name = "D20";

        Random roll = new Random();
        public override int Roll()
        {
            return roll.Next(1, sides);
        }
    }

    internal class D8 : Dice
    {
        private int sides = 9; //+1
        private string name = "D8";

        Random roll = new Random();

        public override int Roll()
        {
            return roll.Next(1, sides);
        }
    }

    internal class D4 : Dice
    {
        private int sides = 5; //+1
        private string name = "D4";

        Random roll = new Random();

        public override int Roll()
        {
            return roll.Next(1, sides);
        }
    }


}
