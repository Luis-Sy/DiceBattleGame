using DiceBattleGame.Data.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame
{
    //==============================================================================ABSTRACT
    internal abstract class Weapon
    {
        protected string weaponType = "Weapon";
        protected string weaponName = "Weapon";

        protected string damageType = "Damage";

        public Weapon()
        {
            weaponType = string.Empty;
            weaponName = string.Empty;
            damageType = string.Empty;
        }
        public Weapon(string weaponType, string weaponName, string damageType)
        {
            this.weaponType = weaponType;
            this.weaponName = weaponName;
            this.damageType = damageType;
        }
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

        public string GetWeaponType()
        {
            return weaponType;
        }

        public string getDamageType()
        {
            return damageType;
        }

    }
    //=================================================================================DEBUG
    internal class Debug : Weapon //This is a weapon for debuggin purposes. Mess with this to if you want to play around before commmiting any changes
    {
        Dice die;

        public Debug() : base()
        {
        die = new D20();
        weaponType = "Debug";
        weaponName = "debugging tool";

        damageType = "ouchy";
        }   
        
        public Debug(string weaponType, string weaponName, string damageType)
        {
            die = new D4();
            this.weaponType = weaponType;
            this.weaponName = weaponName;
            this.damageType = damageType;
        }


        public override int Attack()
        {
            return die.Roll();
        }
    }
     //=================================================================================WEAPONS=================
    internal class Sword : Weapon
    {
        Dice die;
        public Sword()
        {
            die = new D8();
            weaponType = "Sword";
            weaponName = "Cake Cutter";
            damageType = "Slash";
        }
        public Sword(string weaponType, string weaponName, string damageType)
        {
            die = new D8();
            this.weaponType = weaponType;
            this.weaponName = weaponName;
            this.damageType = damageType;
        }

        public override int Attack()
        {
            return die.Roll();
        }
    }

    internal class Rapier : Weapon
    {
        Dice die;
        public Rapier()
        {
            die = new D8();
            weaponType = "Sword";
            weaponName = "Cake Cutter";
            damageType = "Slash";
        }
        public Rapier(string weaponType, string weaponName, string damageType)
        {
            die = new D8();
            this.weaponType = weaponType;
            this.weaponName = weaponName;
            this.damageType = damageType;
        }

        public override int Attack()
        {
            return die.Roll();
        }
    }
//============================================================CUSTOM WEAPONS======================================
    internal class Custom : Weapon
    {
        //To use this constructor in forms 1, you must use static objects. examples below
        //        static Dice d4 = new D4();
        //        static Dice d8 = new D8();
        //        static Dice d20 = new D20();

        //          Weapon knife = new Custom("shoot", "debug", "ouchy", d8);  This creates a custom weapon with a D8. Ill fix this when I figure out whats wrong...
        Dice die;
        public Custom()
        {
            die = new D8();
            weaponType = "Sword";
            weaponName = "Cake Cutter";
            damageType = "Slash";
        }
        public Custom(string weaponType, string weaponName, string damageType, Dice dice)
        {
            die = dice;
            this.weaponType = weaponType;
            this.weaponName = weaponName;
            this.damageType = damageType;
        }

        public override int Attack()
        {
            return die.Roll();
        }
    }

    internal class Hammer : Weapon
    {

    }
}

