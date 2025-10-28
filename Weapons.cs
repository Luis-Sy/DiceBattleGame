using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame
{
    internal abstract class Weapon
    {
        private string weaponType = "Weapon";
        private string weaponName = "Weapon";

        private string damageType = "Damage";

        public virtual int Attack()
        {
            int damage = 0;
            return damage;
        }

    }

    internal class Debug : Weapon //This is a weapon for debuggin purposes. Mess with this to if you want to play around before commmiting any changes
    {
        Dice d20 = new D20();
        private string weaponType = "Debug";
        private string weaponName = "debugging tool";

        private string damageType = "ouchy";

        public override int Attack()
        {
            //int damage = d20.Roll(); DEBUG

            //Console.WriteLine($"Damage was {damage}"); DEBUG

            return d20.Roll();
        }
    }

    internal class Sword : Weapon
    {
        Dice d8 = new D8();
        private string weaponType = "Sword";
        private string weaponName = "Bernard's Large Cake Cutter";

        private string damageType = "Slash";

        public override int Attack()
        {
            return d8.Roll();
        }
    }

    internal class Rapier : Weapon
    {
        Dice d4 = new D4();
        private string weaponType = "Rapier";
        private string weaponName = "Medieval Hole Puncher";

        private string damageType = "Pierce";

        public override int Attack()
        {
            return d4.Roll();
        }
    }

    internal class Hammer : Weapon
    {

    }
}
