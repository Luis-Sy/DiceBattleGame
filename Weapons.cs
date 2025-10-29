using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame
{
    internal abstract class Weapon
    {
        private string weaponName = "Weapon";

        private string damageType = "Damage";

        public virtual int Attack()
        {
            int damage = 0;
            return damage;
        }
        // Added helper methods //read only info to UI/systems
        public string GetName()
        {
            return weaponName;
        }

        public string GetDamageType()
        {
            return damageType;
        }

        // Let child classes update the base name/type safely
        protected void SetWeaponInfo(string name, string type)
        {
            // these assign to the *base* private fields
            weaponName = name;
            damageType = type;
        }

    }

    internal class Debug : Weapon //This is a weapon for debuggin purposes. Mess with this to if you want to play around before commmiting any changes
    {
        Dice d20 = new D20();
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
        string weaponName = "Bernard's Large Cake Cutter";

        string damageType = "Slash";

        public override int Attack()
        {
            return d8.Roll();
        }
        public Sword()
        {
            // Use the base setter so GetName()/GetDamageType() return the right values
            SetWeaponInfo("Bernard's Large Cake Cutter", "Slash");
        }

    }

    internal class Rapier : Weapon
    {
        Dice d4 = new D4();

        string weaponName = "Medieval Hole Puncher";

        string damageType = "Pierce";

        public override int Attack()
        {
            return d4.Roll();
        }
        public Rapier()
        {
            SetWeaponInfo("Medieval Hole Puncher", "Pierce");
        }

    }
}
