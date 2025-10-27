using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame
{
    internal abstract class Dice
    {
        int sides = 2;

        Random roll = new Random();
        public virtual int Roll()
        {
            Console.WriteLine("If youre seeing this, something has gone wrong involving the Dice class");
            return roll.Next(1, sides);
        }
    }

    internal class D20 : Dice
    {
        private int sides = 20;

        Random roll = new Random();
        public override int Roll()
        {
            return roll.Next(1, sides);
        }
    }

    internal class D8 : Dice
    {
        private int sides = 8;

        Random roll = new Random();

        public override int Roll()
        {
            return roll.Next(1, sides);
        }
    }

    internal class D4 : Dice
    {
        private int sides = 4;

        Random roll = new Random();

        public override int Roll()
        {
            return roll.Next(1, sides);
        }
    }


}
