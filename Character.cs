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

        int health;
        int armorClass;
        double slashRes;
        double pierceRes;
        double bluntRes;
        
        Weapon? weapon;

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
    }

    // player classes
    internal class Knight : Character
    {

        int health = 15;
        int armorClass = 15;
        double slashRes = 1.0;
        double pierceRes = 0.5;
        double bluntRes = 2.0;
        Weapon weapon = new Sword();
    }

    internal class Duelist : Character
    {
        int health = 10;
        int armorClass = 12;
        double slashRes = 2.0;
        double pierceRes = 0.5;
        double bluntRes = 1.0;
        Weapon weapon = new Rapier();
    }

    // enemies
    internal class Goblin : Character
    {
        int health = 10;
        int armorClass = 10;
        double slashRes = 1.25;
        double pierceRes = 1.25;
        double bluntRes = 1.25;
        Weapon weapon = new Debug();
    }

    internal class HoboGoblin : Character
    {
        int health = 20;
        int armorClass = 14;
        double slashRes = 1.0;
        double pierceRes = 1.5;
        double bluntRes = 0.5;
        Weapon weapon = new Debug();
    }

    internal class Bandit : Character
    {
        int health = 15;
        int armorClass = 12;
        double slashRes = 1.5;
        double pierceRes = 1.0;
        double bluntRes = 1.0;
        Weapon weapon = new Debug();
    }

    internal class Skeleton : Character
    {
        int health = 15;
        int armorClass = 12;
        double slashRes = 0.5;
        double pierceRes = 0.5;
        double bluntRes = 1.5;
        Weapon weapon = new Debug();
    }

}
