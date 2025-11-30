using DiceBattleGame.Data.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.Data.Characters
{
    // this class is used as a base for both playable and non-playable characters
    internal abstract class Character
    {
        // make these protected so derived classes set them instead of hiding them
        protected int health;
        protected int defaultHealth; // This stores the original hp for the character, this will need to be changed to account for longer gameplay. - Junaid
        // armor class is the value an attack roll must meet or exceed to hit the character
        protected int armorClass;

        protected int level = 1;
        protected int experience = 0;

        // resistances are multipliers to incoming damage (higher means more damage received from that type)
        // e.g. 1.0 = normal damage, 0.5 = half damage, 2.0 = double damage
        // elemental resistances at some point?
        protected Dictionary<string, double> damageResistances = new Dictionary<string, double>()
        {
            {"Slash", 1.0},
            {"Pierce", 1.0},
            {"Blunt", 1.0}
        };

        protected string name = "Character"; // display name
        protected string type = "Character"; // type of character (player/enemy/etc)

        protected Weapon? weapon;

        // this dictionary holds character stats
        // all stats start at 10 by default
        protected Dictionary<string, int> stats = new Dictionary<string, int>()
        {
            {"Vigor", 10},
            {"Constitution", 10},
            {"Strength", 10},
            {"Dexterity", 10},
            {"Intellect", 10},
            {"Faith", 10}
        };
        // this dictionary sets the character's stat growth modifiers, they vary from each character
        // modifiers in the same order as above and are clamped between -5 and +5
        protected Dictionary<string, int> statGrowths = new Dictionary<string, int>()
        {
            {"Vigor", 0},
            {"Constitution", 0},
            {"Strength", 0},
            {"Dexterity", 0},
            {"Intellect", 0},
            {"Faith", 0}
        };

        // default constructor to create a level 1 character
        public Character()
        {
            // set stats based on growth modifiers
            foreach(var stat in stats.Keys.ToList())
            {
                stats[stat] += statGrowths[stat];
            }

            // calculate health
            defaultHealth = stats["Vigor"] * 2;
            health = defaultHealth;

        }

        // constructor to make a character of a specific level
        public Character(int level)
        {
            // calculate stats based on growth modifiers
            foreach (var stat in stats.Keys.ToList())
            {
                stats[stat] = 10 + (level - 1) + statGrowths[stat];
            }

            // calculate health
            defaultHealth = stats["Vigor"] * 2;
            health = defaultHealth;

        }

        // on level up, all characters receive +1 to all stats (may be changed later)
        // currently, a character will level up for every 5 exp accumulated
        public void levelUp()
        {
            foreach(var stat in stats.Keys.ToList())
            {
                stats[stat] += 1;
            }

            //additionally, recalculate health and restore to full
            defaultHealth = stats["Vigor"] * 2;
            health = defaultHealth;

            level += 1;
            experience -= 5;
        }


        public int attack()
        {
            if (weapon != null)
            {
                return weapon.Attack(); // roll weapon's damage dice
            }
            else
            {
                return 0;
            }
        }

        public void takeDamage(int amount, string type)
        {
            int finalDamage = 0;
            // check to see if the damage type exists
            if(damageResistances.ContainsKey(type))
            {
                finalDamage = (int)Math.Ceiling(amount * damageResistances[type]);

                // round up to 1 if necessary
                if(finalDamage < 1)
                {
                    finalDamage = 1;
                }

                health -= finalDamage;
            }
            else
            {
                // deal no damage and log a message to the console
                Console.WriteLine($"Damage type {type} not recognized! No damage taken.");
                finalDamage = 0;
            }
            
        }

        public string getName()
        {
            return name;
        }

        public int getHealth()
        {
            return health;
        }

        public int getLevel()
        {
            return level;
        }

        public int setLevel(int level)
        {
            while(level > this.level)
            {
                levelUp();
            }
            return this.level;
        }

        public int gainExp(int amount)
        {
            experience += amount;
            // check for level up
            while(experience >= 5)
            {
                levelUp();
            }
            return experience;
        }

        public Dictionary<string, int> getStats()
        {
            return stats;
        }

        public Dictionary<string, int> getStatGrowths()
        {
            return statGrowths;
        }
        public Dictionary<string, double> getResistances()
        {
            return damageResistances;
        }


        // get the stat roll bonus for a given stat
        // used for anything that requires a stat check
        public int getStatCheckBonus(string stat)
        {
            // every 5 points in a stat gives +1 bonus
            if (stats.ContainsKey(stat))
            {
                return (int)Math.Floor(stats[stat] / 5.0);
            }
            else
            {
                // otherwise, return no bonus and log to console
                Console.WriteLine($"Stat {stat} not recognized! No bonus applied.");
                return 0;
            }
        }

        // method for external character files
        public void initializeStats()
        {
            foreach(var stat in stats.Keys.ToList())
            {
                stats[stat] += statGrowths[stat];
            }

            defaultHealth = stats["Vigor"] * 2;
            health = defaultHealth;
        }

        public int getArmoclass()
        {
            return armorClass;
        }

        public Weapon? getWeapon()
        {
            return weapon;
        }

        public string getCharacterType()
        {
            return type;
        }

        public string getWeaponType()
        {
             if (weapon != null)
            {
                return weapon.GetDamageType();
            }
            else
            {
                return "None";
            }
        }

        public void equip(Weapon weapon)
        {
            this.weapon = weapon;
        }

        public int attackRoll()
        {
            Dice dice = new D20();
            return dice.Roll();
        }

        public void setHealth() //This allows us to directly restore the health of a character back its default - Junaid
        {
            health = defaultHealth;
        }

        public void restoreHp() //Restores the character back to full health, currently used on battle start, will need to be changed when longer campaign - J
        {
            health = defaultHealth;
        }

        public void changeHp(int x)
        {
            health = x;
        }
    }

    /// <summary>
    /// TODO FOR FINAL:
    /// -Add unique abilities to each class (both player and enemy)
    /// -Add stat scaling to weapons and character stats
    /// -Add elemental damage types and resistances(?)
    /// -separate each category of character into their own files for organization
    /// </summary>

    // player classes (in the process of migrating to separate files)
    /*
    internal class Berserker : Character
    {
        public Berserker()
        {
            defaultHealth = 18;
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
            defaultHealth = 14;
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
            defaultHealth = 10;
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
            defaultHealth = 16;
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
            defaultHealth = 20;
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
            defaultHealth = 8;
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
            defaultHealth = 16;
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
            defaultHealth = 18;
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
            defaultHealth = 14;
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
            defaultHealth = 15;
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
            defaultHealth = 18;
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

    // enemies (uses custom weapons)

    // standard enemies
    internal class Goblin : Character
    {
        public Goblin()
        {
            defaultHealth = 10;
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
            defaultHealth = 20;
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
            defaultHealth = 12;
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
            defaultHealth = 15;
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
            defaultHealth = 20;
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
            defaultHealth = 25;
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
            defaultHealth = 15;
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
            defaultHealth = 30;
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
            defaultHealth = 25;
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
            defaultHealth = 40;
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
            defaultHealth = 35;
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

    internal class MadCommander :Character
    {
        public MadCommander()
        {
            defaultHealth = 50;
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
            defaultHealth = 45;
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
            defaultHealth = 40;
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
            defaultHealth = 55;
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
            defaultHealth = 50;
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
            defaultHealth = 45;
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
            defaultHealth = 60;
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

    // twisted elite enemies (enemies based on the playable classes, but with major differences)

    internal class FallenKnight : Character
    {
        public FallenKnight()
        {
            defaultHealth = 40;
            health = 40;
            armorClass = 16;
            name = "Fallen Knight";
            type = "Elite Enemy";
            slashRes = 1.0;
            pierceRes = 1.5;
            bluntRes = 1.0;
            weapon = new Custom("Cursed Sword", "Sword of the Damned", "Slash", new D10());
        }
    }

    internal class ShadowDuelist : Character
    {
        public ShadowDuelist()
        {
            defaultHealth = 30;
            health = 30;
            armorClass = 14;
            name = "Shadow Duelist";
            type = "Elite Enemy";
            slashRes = 1.5;
            pierceRes = 1.0;
            bluntRes = 1.5;
            weapon = new Custom("Shadow Rapier", "Rapier of Shadows", "Pierce", new D10());
        }
    }

    internal class CorruptedPaladin : Character
    {
        public CorruptedPaladin()
        {
            defaultHealth = 50;
            health = 50;
            armorClass = 16;
            name = "Corrupted Paladin";
            type = "Elite Enemy";
            slashRes = 1.5;
            pierceRes = 1.5;
            bluntRes = 1.0;
            weapon = new Custom("Dark Hammer", "Hammer of Corruption", "Blunt", new D12());
        }
    }

    internal class PhantomRanger : Character
    {
        public PhantomRanger()
        {
            defaultHealth = 30;
            health = 30;
            armorClass = 13;
            name = "Phantom Ranger";
            type = "Elite Enemy";
            slashRes = 1.5;
            pierceRes = 1.5;
            bluntRes = 1.5;
            weapon = new Custom("Ethereal Bow", "Bow of Phantoms", "Pierce", new diceBag(5, 4));
        }
    }

    internal class SavageBerserker : Character
    {
        public SavageBerserker()
        {
            defaultHealth = 45;
            health = 45;
            armorClass = 15;
            name = "Savage Berserker";
            type = "Elite Enemy";
            slashRes = 1.0;
            pierceRes = 2.0;
            bluntRes = 1.0;
            weapon = new Custom("Savage Axe", "Axe of the Savage", "Slash", new D12());
        }
    }

    internal class ShadowMonk : Character
    {
        public ShadowMonk()
        {
            defaultHealth = 28;
            health = 28;
            armorClass = 12;
            name = "Shadow Monk";
            type = "Elite Enemy";
            slashRes = 1.0;
            pierceRes = 1.0;
            bluntRes = 1.0;
            weapon = new Custom("Shadow Fists", "Fists of the Shadow", "Blunt", new diceBag(7, 3));
        }
    }

    internal class NightstalkerAssassin : Character
    {
        public NightstalkerAssassin()
        {
            defaultHealth = 25;
            health = 25;
            armorClass = 13;
            name = "Nightstalker Assassin";
            type = "Elite Enemy";
            slashRes = 2.0;
            pierceRes = 0.5;
            bluntRes = 1.0;
            weapon = new Custom("Shadow Daggers", "Daggers of the Night", "Pierce", new diceBag(9, 2));
        }
    }

    internal class BlightedHeretic : Character
    {
        public BlightedHeretic()
        {
            defaultHealth = 35;
            health = 35;
            armorClass = 14;
            name = "Blighted Heretic";
            type = "Elite Enemy";
            slashRes = 1.0;
            pierceRes = 2.0;
            bluntRes = 1.0;
            weapon = new Custom("Blighted Scythe", "Scythe of the Blight", "Slash", new diceBag(9, 2));
        }
    }

    internal class LoathsomeDeprived : Character
    {
        public LoathsomeDeprived()
        {
            defaultHealth = 50;
            health = 50;
            armorClass = 10;
            name = "Loathsome Deprived";
            type = "Elite Enemy";
            slashRes = 1.5;
            pierceRes = 1.5;
            bluntRes = 1.5;
            weapon = new Custom("Spiked Club", "Club of the Loathsome", "Blunt", new D10());
        }
    }

    internal class CursedTourist : Character
    {
        public CursedTourist()
        {
            defaultHealth = 20;
            health = 20;
            armorClass = 14;
            name = "Cursed Tourist";
            type = "Elite Enemy";
            slashRes = 1.5;
            pierceRes = 1.5;
            bluntRes = 1.5;
            weapon = new Custom("Cursed Camera", "Camera of Misfortune", "Blunt", new D10());
        }
    }

    internal class CorruptedWarden : Character
    {
        public CorruptedWarden()
        {
            defaultHealth = 40;
            health = 40;
            armorClass = 16;
            name = "Corrupted Warden";
            type = "Elite Enemy";
            slashRes = 1.0;
            pierceRes = 1.5;
            bluntRes = 1.0;
            weapon = new Custom("Corrupted Flail", "Flail of Corruption", "Blunt", new D12());
        }
    }

    internal class SlaveDriverInstructor : Character
    {
        public SlaveDriverInstructor()
        {
            defaultHealth = 45;
            health = 45;
            armorClass = 15;
            name = "Slave Driver Instructor";
            type = "Elite Enemy";
            slashRes = 1.5;
            pierceRes = 1.0;
            bluntRes = 1.5;
            weapon = new Custom("Whip of Pain", "Whip of Endless Pain", "Slash", new diceBag(9, 2));
        }
    }

    internal class AvariciousNoble : Character
    {
        public AvariciousNoble()
        {
            defaultHealth = 38;
            health = 38;
            armorClass = 15;
            name = "Avaricious Noble";
            type = "Elite Enemy";
            slashRes = 1.25;
            pierceRes = 1.25;
            bluntRes = 1.25;
            weapon = new Custom("Jeweled Rapier", "Rapier of Avarice", "Pierce", new D10());
        }
    }

    internal class TrueAwakened : Character
    {
        public TrueAwakened()
        {
            defaultHealth = 35;
            health = 35;
            armorClass = 13;
            name = "True Awakened";
            type = "Elite Enemy";
            slashRes = 1.0;
            pierceRes = 1.0;
            bluntRes = 1.0;
            weapon = new Custom("Staff of Truth", "Staff of True Awakening", "Blunt", new diceBag(9, 3));
        }
    }

    // boss enemies

    internal class Dragon : Character
    {
        public Dragon()
        {
            defaultHealth = 100;
            health = 100;
            armorClass = 15;
            name = "Dragon";
            type = "Boss Enemy";
            slashRes = 1.0;
            pierceRes = 2.0;
            bluntRes = 0.75;
            weapon = new Custom("Fire Breath", "Inferno", "Blunt", new diceBag(11, 3));
        }
    }

    internal class DemonLord : Character
    {
        public DemonLord()
        {
            defaultHealth = 120;
            health = 120;
            armorClass = 15;
            name = "Demon Lord";
            type = "Boss Enemy";
            slashRes = 2.0;
            pierceRes = 1.25;
            bluntRes = 1.25;
            weapon = new Custom("Hellfire Sword", "Demon's Blade", "Slash", new D20());
        }
    }

    internal class LichKing : Character
    {
        public LichKing()
        {
            defaultHealth = 110;
            health = 110;
            armorClass = 15;
            name = "Lich King";
            type = "Boss Enemy";
            slashRes = 1.0;
            pierceRes = 1.5;
            bluntRes = 2.0;
            weapon = new Custom("Frost Staff", "Staff of the Frozen Dead", "Blunt", new diceBag(11, 3));
        }
    }

    internal class DarkAvatar : Character
    {
        public DarkAvatar()
        {
            defaultHealth = 150;
            health = 150;
            armorClass = 10;
            name = "Dark Avatar";
            type = "Boss Enemy";
            slashRes = 2.0;
            pierceRes = 2.0;
            bluntRes = 2.0;
            weapon = new Custom("Shadow Claws", "Claws of the Abyss", "Slash", new D20());
        }
    }

    internal class ElderGod : Character
    {
        public ElderGod()
        {
            defaultHealth = 150;
            health = 150;
            armorClass = 14;
            name = "Elder God";
            type = "Boss Enemy";
            slashRes = 1.0;
            pierceRes = 1.0;
            bluntRes = 1.0;
            weapon = new Custom("Cosmic Wrath", "Elder God's Wrath", "Blunt", new diceBag(13, 3));
        }
    }

    internal class TheMalformed : Character
    {
        public TheMalformed()
        {
            defaultHealth = 250;
            health = 250;
            armorClass = 10;
            name = "The Malformed";
            type = "Boss Enemy";
            slashRes = 2.0;
            pierceRes = 2.0;
            bluntRes = 2.0;
            weapon = new Custom("Reality Shred", "Shredder of Realities", "Slash", new D20());
        }
    }

    internal class AvatarOfWrath : Character
    {
        public AvatarOfWrath()
        {
            defaultHealth = 200;
            health = 200;
            armorClass = 12;
            name = "Avatar of Wrath";
            type = "Boss Enemy";
            slashRes = 2.0;
            pierceRes = 2.0;
            bluntRes = 1.0;
            weapon = new Custom("Wrathful Strike", "Strike of Ultimate Wrath", "Blunt", new diceBag(13, 2));
        }
    }

    internal class AvatarOfGluttony : Character
    {
        public AvatarOfGluttony()
        {
            defaultHealth = 200;
            health = 200;
            armorClass = 13;
            name = "Avatar of Gluttony";
            type = "Boss Enemy";
            slashRes = 2.0;
            pierceRes = 1.5;
            bluntRes = 2.0;
            weapon = new Custom("Devouring Slash", "Slash of Endless Hunger", "Slash", new diceBag(5, 6));
        }
    }

    internal class AvatarOfSloth : Character
    {
        public AvatarOfSloth()
        {
            defaultHealth = 400;
            health = 400;
            armorClass = 10;
            name = "Avatar of Sloth";
            type = "Boss Enemy";
            slashRes = 2.0;
            pierceRes = 2.0;
            bluntRes = 2.0;
            weapon = new Custom("Lethargic Pierce", "Pierce of Eternal Laziness", "Pierce", new D20());
        }
    }

    internal class AvatarOfPride : Character
    {
        public AvatarOfPride()
        {
            defaultHealth = 150;
            health = 150;
            armorClass = 16;
            name = "Avatar of Pride";
            type = "Boss Enemy";
            slashRes = 2.0;
            pierceRes = 2.0;
            bluntRes = 2.0;
            weapon = new Custom("Haughty Blow", "Blow of Supreme Arrogance", "Blunt", new D20());
        }
    }

    internal class AvatarOfEnvy : Character
    {
        public AvatarOfEnvy()
        {
            defaultHealth = 200;
            health = 200;
            armorClass = 12;
            name = "Avatar of Envy";
            type = "Boss Enemy";
            slashRes = 2.0;
            pierceRes = 2.0;
            bluntRes = 2.0;
            weapon = new Custom("Covetous Strike", "Strike of Jealous Desire", "Slash", new diceBag(7, 3));
        }
    }

    internal class AvatarOfLust : Character
    {
        public AvatarOfLust()
        {
            defaultHealth = 180;
            health = 180;
            armorClass = 14;
            name = "Avatar of Lust";
            type = "Boss Enemy";
            slashRes = 1.5;
            pierceRes = 1.0;
            bluntRes = 1.5;
            weapon = new Custom("Alluring Thrust", "Thrust of Irresistible Desire", "Pierce", new diceBag(9, 3));
        }
    }
    
    internal class AvatarOfAvarice : Character
    {
        public AvatarOfAvarice()
        {
            defaultHealth = 220;
            health = 220;
            armorClass = 13;
            name = "Avatar of Avarice";
            type = "Boss Enemy";
            slashRes = 2.0;
            pierceRes = 1.5;
            bluntRes = 2.0;
            weapon = new Custom("Greedy Slash", "Slash of Insatiable Greed", "Slash", new diceBag(9, 3));
        }
    }

*/
}
    