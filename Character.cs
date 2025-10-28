using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame
{
    // this class is used as a base for both playable and non-playable characters
    internal abstract class Character
    {
        // make these protected so derived classes set them instead of hiding them
        protected int health;
        protected int armorClass;
        protected double slashRes;
        protected double pierceRes;
        protected double bluntRes;

        protected Weapon? weapon;

        public int attack()
        {
            if (weapon != null)
            {
                return weapon.Attack();
            }
            else
            {
                return 0;
            }
        }

        public void takeDamage(int amount, string type)
        {
            int finalDamage = 0;
            // check for what type of damage is incoming and multiply by resistances accordingly
            if (type.ToLower() == "slash")
            {
                finalDamage = (int)Math.Ceiling(amount * slashRes);
            }
            if (type.ToLower() == "pierce")
            {
                finalDamage = (int)Math.Ceiling(amount * pierceRes);
            }
            if (type.ToLower() == "blunt")
            {
                finalDamage = (int)Math.Ceiling(amount * bluntRes);
            }

            health -= finalDamage;
        }

        public int getHealth()
        {
            return this.health;
        }
    }

    // player classes
    internal class Knight : Character
    {
        public Knight()
        {
            health = 15;
            armorClass = 15;
            slashRes = 1.0;
            pierceRes = 0.5;
            bluntRes = 2.0;
            weapon = new Sword();
        }
    }

    internal class Duelist : Character
    {
        public Duelist()
        {
            health = 10;
            armorClass = 12;
            slashRes = 2.0;
            pierceRes = 0.5;
            bluntRes = 1.0;
            weapon = new Rapier();
        }
    }

    // enemies (no weapons yet)
    internal class Goblin : Character
    {
        public Goblin()
        {
            health = 10;
            armorClass = 10;
            slashRes = 1.25;
            pierceRes = 1.25;
            bluntRes = 1.25;
            weapon = new Debug();
        }
    }

    internal class HoboGoblin : Character
    {
        public HoboGoblin()
        {
            health = 20;
            armorClass = 14;
            slashRes = 1.0;
            pierceRes = 1.5;
            bluntRes = 0.5;
            weapon = new Debug();
        }
    }

    internal class Bandit : Character
    {
        public Bandit()
        {
            health = 15;
            armorClass = 12;
            slashRes = 1.5;
            pierceRes = 1.0;
            bluntRes = 1.0;
            weapon = new Debug();
        }
    }

    internal class Skeleton : Character
    {
        public Skeleton()
        {
            health = 15;
            armorClass = 12;
            slashRes = 0.5;
            pierceRes = 0.5;
            bluntRes = 1.5;
            weapon = new Debug();
        }
    }

}
