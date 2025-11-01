using Microsoft.VisualBasic.ApplicationServices;
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

        protected string name = "Character"; // display name
        protected string type = "Character"; // type of character (player/enemy/etc)

        protected Weapon? weapon;

        //to get the player or enemy character in turn manager
        public virtual string GetName()
        {
            return this.GetType().Name;
        }

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
            else if (type.ToLower() == "pierce")
            {
                finalDamage = (int)Math.Ceiling(amount * pierceRes);
            }
            else if (type.ToLower() == "blunt")
            {
                finalDamage = (int)Math.Ceiling(amount * bluntRes);
            }

            health -= finalDamage;
        }

        public int getHealth()
        {
            return this.health;
        }

        //alows the character to change weapons dynamically
        public void Equip(Weapon newWeapon)
        {
            weapon = newWeapon;
        }
        //returns the current weapon name 
        public string CurrentWeaponName()
        {
            return weapon != null ? weapon.GetName() : "(none)";
        }
        //
        public string GetWeaponType()
        {
            if(weapon != null)
            {
                return weapon.GetDamageType();
            }
            else 
            {
                return "-";

            }
        }
        public int getArmoclass()
        {
            return this.armorClass;
        }

        public Weapon? getWeapon()
        {
            return this.weapon;
        }

        public int attackRoll()
        {
            Dice dice = new D20();
            return dice.Roll();
        }
    }




    // player classes
    internal class Knight : Character
    {
        public Knight()
        {
            health = 15;
            armorClass = 15;
            name = "Knight";
            type = "Player";
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
            health = 12;
            armorClass = 12;
            name = "Duelist";
            type = "Player";
            slashRes = 2.0;
            pierceRes = 0.5;
            bluntRes = 1.0;
            weapon = new Rapier();
        }
    }

    internal class Paladin : Character
    {
        public Paladin()
        {
            health = 25;
            armorClass = 18;
            name = "Paladin";
            type = "Player";
            slashRes = 0.5;
            pierceRes = 1.0;
            bluntRes = 1.5;
            weapon = new Hammer();
        }
    }

    internal class Cleric : Character
    {
        public Cleric()
        {
            health = 20;
            armorClass = 14;
            name = "Cleric";
            type = "Player";
            slashRes = 1.0;
            pierceRes = 1.0;
            bluntRes = 1.0;
            weapon = new Custom("Mace", "Holy Mace", "Blunt", new diceBag(7, 2));
        }
    }

    internal class Ranger : Character
    {
        public Ranger()
        {
            health = 12;
            armorClass = 13;
            name = "Ranger";
            type = "Player";
            slashRes = 1.5;
            pierceRes = 1.0;
            bluntRes = 1.0;
            weapon = new Custom("Bow", "Longbow", "Pierce", new diceBag(5, 3));
        }
    }

    internal class Berserker : Character
    {
        public Berserker()
        {
            health = 18;
            armorClass = 14;
            name = "Berserker";
            type = "Player";
            slashRes = 1.0;
            pierceRes = 1.5;
            bluntRes = 1.0;
            weapon = new Custom("Axe", "Battle Axe", "Slash", new D10());
        }
    }

    internal class Monk : Character
    {
        public Monk()
        {
            health = 14;
            armorClass = 12;
            name = "Monk";
            type = "Player";
            slashRes = 1.0;
            pierceRes = 1.0;
            bluntRes = 1.0;
            weapon = new Custom("Fists", "Spiritual Fists", "Blunt", new diceBag(5, 3));
        }
    }

    internal class Assassin : Character
    {
        public Assassin()
        {
            health = 10;
            armorClass = 12;
            name = "Assassin";
            type = "Player";
            slashRes = 2.0;
            pierceRes = 0.5;
            bluntRes = 1.5;
            weapon = new Custom("Daggers", "Twin Daggers", "Pierce", new diceBag(7, 2));
        }
    }

    internal class Heretic : Character
    {
        public Heretic()
        {
            health = 16;
            armorClass = 13;
            name = "Heretic";
            type = "Player";
            slashRes = 1.0;
            pierceRes = 1.5;
            bluntRes = 1.0;
            weapon = new Custom("Scythe", "Dark Scythe", "Slash", new diceBag(7, 2));
        }
    }

    internal class Deprived : Character
    {
        public Deprived()
        {
            health = 20;
            armorClass = 10;
            name = "Deprived";
            type = "Player";
            slashRes = 1.0;
            pierceRes = 1.0;
            bluntRes = 1.0;
            weapon = new Custom("Club", "Wooden Club", "Blunt", new D6());
        }
    }

    internal class Tourist : Character
    {
        public Tourist()
        {
            health = 8;
            armorClass = 14;
            name = "Tourist";
            type = "Player";
            slashRes = 1.5;
            pierceRes = 1.5;
            bluntRes = 1.5;
            weapon = new Custom("Camera", "Point-and-Shoot Camera", "Blunt", new D8());
        }
    }

    internal class Warden : Character
    {
        public Warden()
        {
            health = 16;
            armorClass = 16;
            name = "Warden";
            type = "Player";
            slashRes = 0.5;
            pierceRes = 1.0;
            bluntRes = 1.5;
            weapon = new Custom("Flail", "Iron Flail", "Blunt", new D10());
        }
    }

    internal class Instructor : Character
    {
        public Instructor()
        {
            health = 18;
            armorClass = 14;
            name = "Instructor";
            type = "Player";
            slashRes = 1.0;
            pierceRes = 1.5;
            bluntRes = 0.5;
            weapon = new Custom("Whip", "Leather Whip", "Slash", new diceBag(7, 2));
        }
    }

    internal class Awakened : Character
    {
        public Awakened()
        {
            health = 14;
            armorClass = 12;
            name = "Awakened";
            type = "Player";
            slashRes = 1.0;
            pierceRes = 1.0;
            bluntRes = 1.0;
            weapon = new Custom("Magic Staff", "Staff of Awakening", "Blunt", new diceBag(7, 2));
        }
    }

    internal class Samurai : Character
    {
        public Samurai()
        {
            health = 15;
            armorClass = 17;
            name = "Samurai";
            type = "Player";
            slashRes = 0.5;
            pierceRes = 1.25;
            bluntRes = 1.25;
            weapon = new Custom("Katana", "Aged Katana", "Slash", new D10());
        }
    }

    internal class FallenNoble : Character
    {
        public FallenNoble()
        {
            health = 18;
            armorClass = 15;
            name = "Fallen Noble";
            type = "Player";
            slashRes = 1.25;
            pierceRes = 1.25;
            bluntRes = 1.25;
            weapon = new Custom("Rapier", "Elegant Rapier", "Pierce", new D8());
        }
    }


    // enemies (no weapons yet)


    // enemies(uses custom weapons)

    // standard enemies
    internal class Goblin : Character
    {
        public Goblin()
        {
            health = 10;
            armorClass = 10;
            name = "Goblin";
            type = "Enemy";
            slashRes = 1.25;
            pierceRes = 1.25;
            bluntRes = 1.25;
            weapon = new Custom("Club", "Rusty Club", "Blunt", new D4());
        }
    }

    internal class HoboGoblin : Character
    {
        public HoboGoblin()
        {
            health = 20;
            armorClass = 14;
            name = "HoboGoblin";
            type = "Enemy";
            slashRes = 1.0;
            pierceRes = 1.5;
            bluntRes = 0.5;
            weapon = new Custom("Sling", "Makeshift Sling", "Pierce", new diceBag(5, 2));
        }
    }

    internal class Slime : Character
    {
        public Slime()
        {
            health = 12;
            armorClass = 8;
            name = "Slime";
            type = "Enemy";
            slashRes = 1.5;
            pierceRes = 1.5;
            bluntRes = 0.5;
            weapon = new Custom("Pseudopod", "Gooey Pseudopod", "Blunt", new diceBag(5, 2));
        }
    }

    internal class Bandit : Character
    {
        public Bandit()
        {
            health = 15;
            armorClass = 12;
            name = "Bandit";
            type = "Enemy";
            slashRes = 1.5;
            pierceRes = 1.0;
            bluntRes = 1.0;
            weapon = new Custom("Dagger", "Sharp Dagger", "Pierce", new diceBag(5, 2));
        }
    }

    internal class Mercenary : Character
    {
        public Mercenary()
        {
            health = 20;
            armorClass = 15;
            name = "Mercenary";
            type = "Enemy";
            slashRes = 1.25;
            pierceRes = 1.0;
            bluntRes = 1.5;
            weapon = new Custom("Sword", "Broad Sword", "Slash", new D8());
        }
    }

    internal class Orc : Character
    {
        public Orc()
        {
            health = 25;
            armorClass = 16;
            name = "Orc";
            type = "Enemy";
            slashRes = 0.5;
            pierceRes = 1.5;
            bluntRes = 1.5;
            weapon = new Custom("Axe", "Orcish Axe", "Slash", new D12());
        }
    }

    internal class Skeleton : Character
    {
        public Skeleton()
        {
            health = 15;
            armorClass = 12;
            name = "Skeleton";
            type = "Enemy";
            slashRes = 0.5;
            pierceRes = 0.5;
            bluntRes = 1.5;
            weapon = new Custom("Sword", "Bone Sword", "Slash", new D8());
        }
    }

    internal class Zombie : Character
    {
        public Zombie()
        {
            health = 30;
            armorClass = 8;
            name = "Zombie";
            type = "Enemy";
            slashRes = 1.5;
            pierceRes = 1.0;
            bluntRes = 0.5;
            weapon = new Custom("Fists", "Rotten Fists", "Blunt", new diceBag(5, 2));
        }
    }

    // elite enemies

    internal class Cultist : Character
    {
        public Cultist()
        {
            health = 25;
            armorClass = 12;
            name = "Cultist";
            type = "Elite Enemy";
            slashRes = 1.0;
            pierceRes = 1.5;
            bluntRes = 1.0;
            weapon = new Custom("Scythe", "Dark Scythe", "Slash", new diceBag(5, 3));
        }
    }

    internal class CultistLeader : Character
    {
        public CultistLeader()
        {
            health = 40;
            armorClass = 14;
            name = "Cultist Leader";
            type = "Elite Enemy";
            slashRes = 1.0;
            pierceRes = 1.25;
            bluntRes = 1.5;
            weapon = new Custom("Greatsword", "Cursed Greatsword", "Slash", new D12());
        }
    }

    internal class MadWarrior : Character
    {
        public MadWarrior()
        {
            health = 35;
            armorClass = 13;
            name = "Mad Warrior";
            type = "Elite Enemy";
            slashRes = 1.5;
            pierceRes = 1.0;
            bluntRes = 1.0;
            weapon = new Custom("Great Axe", "Berserker's Great Axe", "Slash", new diceBag(9, 2));
        }
    }

    internal class MadCommander : Character
    {
        public MadCommander()
        {
            health = 50;
            armorClass = 14;
            name = "Mad Commander";
            type = "Elite Enemy";
            slashRes = 1.0;
            pierceRes = 1.5;
            bluntRes = 0.5;
            weapon = new Custom("Warhammer", "War Commander's Hammer", "Blunt", new D12());
        }
    }

    internal class Lich : Character
    {
        public Lich()
        {
            health = 45;
            armorClass = 15;
            name = "Lich";
            type = "Elite Enemy";
            slashRes = 1.0;
            pierceRes = 1.25;
            bluntRes = 1.5;
            weapon = new Custom("Staff", "Staff of the Damned", "Blunt", new diceBag(9, 2));
        }
    }

    internal class Mimic : Character
    {
        public Mimic()
        {
            health = 40;
            armorClass = 16;
            name = "Mimic";
            type = "Elite Enemy";
            slashRes = 1.5;
            pierceRes = 1.0;
            bluntRes = 0.5;
            weapon = new Custom("Bite", "Mimic's Bite", "Pierce", new D10());
        }
    }

    internal class Werewolf : Character
    {
        public Werewolf()
        {
            health = 55;
            armorClass = 15;
            name = "Werewolf";
            type = "Elite Enemy";
            slashRes = 0.5;
            pierceRes = 2.0;
            bluntRes = 1.0;
            weapon = new Custom("Claws", "Razor Sharp Claws", "Slash", new diceBag(9, 2));
        }
    }

    internal class Vampire : Character
    {
        public Vampire()
        {
            health = 50;
            armorClass = 16;
            name = "Vampire";
            type = "Elite Enemy";
            slashRes = 0.5;
            pierceRes = 2.0;
            bluntRes = 0.5;
            weapon = new Custom("Fangs", "Vampire's Fangs", "Pierce", new D12());
        }
    }

    internal class WanderingSwordsman : Character
    {
        public WanderingSwordsman()
        {
            health = 45;
            armorClass = 18;
            name = "Wandering Swordsman";
            type = "Elite Enemy";
            slashRes = 0.5;
            pierceRes = 1.25;
            bluntRes = 1.25;
            weapon = new Custom("Katana", "Master's Katana", "Slash", new D10());
        }
    }

    internal class ElderFragment : Character
    {
        public ElderFragment()
        {
            health = 60;
            armorClass = 14;
            name = "Elder Fragment";
            type = "Elite Enemy";
            slashRes = 1.0;
            pierceRes = 1.0;
            bluntRes = 2.0;
            weapon = new Custom("Crystal Spike", "Elder Crystal Spike", "Pierce", new diceBag(11, 2));
        }
    }

}
