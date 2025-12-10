using DiceBattleGame.GameData.Items;
using DiceBattleGame.GameData.System;
using System.Diagnostics;

namespace DiceBattleGame.GameData.Characters
{
    // this class is used as a base for both playable and non-playable characters
    public abstract class Character
    {
        // make these protected so derived classes set them instead of hiding them
        protected int health;
        protected int maxHealth; // This stores the original hp for the character, this will need to be changed to account for longer gameplay. - Junaid
        // armor class is the value an attack roll must meet or exceed to hit the character
        protected int armorClass;

        protected int level = 1;
        protected int experience = 0;

        // resistances are multipliers to incoming damage (higher means more damage received from that type)
        // e.g. 1.0 = normal damage, 0.5 = half damage, 2.0 = double damage
        // elemental resistances at some point?
        protected Dictionary<string, double> damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
        {
            {"Slash", 1.0},
            {"Pierce", 1.0},
            {"Blunt", 1.0},
            {"Magic", 1.0 },
            {"Radiant", 1.0 },
            {"Arcane", 1.0 },
            {"Psychic", 1.0 }
        };

        protected string name = "Character"; // display name
        protected string type = "Character"; // type of character (player/common enemy/elite enemy/twisted elite enemy, boss enemy)

        protected Weapon? weapon;

        // this dictionary holds character stats
        // all stats start at 10 by default
        protected Dictionary<string, int> stats = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
        {
            {"Vigor", 10}, // determines max health (Vigor * 2 = health)
            {"Constitution", 10}, // factors in damage mitigation and resistances later
            {"Strength", 10}, // the rest are for damage scaling and stat checks
            {"Dexterity", 10},
            {"Intellect", 10},
            {"Faith", 10}
        };
        // this dictionary sets the character's stat growth modifiers, they vary from each character
        // modifiers in the same order as above and are clamped between -5 and +5
        // may consider lifting this restriction for enemies only
        protected Dictionary<string, int> statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
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
            initializeStats();

        }

        // constructor to make a character of a specific level
        public Character(int level)
        {
            initializeStats();

        }

        // on level up, all characters receive +1 to all stats (may be changed later)
        // currently, a character will level up for every 5 exp accumulated
        public void levelUp()
        {
            foreach (var stat in stats.Keys.ToList())
            {
                stats[stat] += 1;
            }

            //additionally, recalculate health
            maxHealth = stats["Vigor"] * 2;

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
            // check to see if the character has a defined resistance for the provided damage type
            if (damageResistances.ContainsKey(type))
            {
                // multiply damage by the character's damage resistance modifier
                finalDamage = (int)Math.Ceiling(amount * damageResistances[type]);

                // round up to 1 if necessary to prevent stalemates
                if (finalDamage < 1)
                {
                    finalDamage = 1;
                }

                health -= finalDamage;
            }
            else
            {
                // if no defined damage resistance for provided type, deal raw damage
                Trace.WriteLine($"Character does not have a defined value for {type} resistance. Assuming 1.0x and dealing damage.");
                finalDamage = amount;
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

        public int getMaxHealth()
        {
            return maxHealth;
        }

        public int getLevel()
        {
            return level;
        }

        public int setLevel(int level)
        {
            // if the level is greater than the current level, repeat level ups until the desired level is reached
            if (level > 1)
            {
                while (level > this.level)
                {
                    levelUp();
                }
            }
            else // if the level change is lower than the current level, set the level down directly and recalculate stats
            {
                this.level = level;
                initializeStats();
            }

                return this.level;
        }


        public int gainExp(int amount)
        {
            experience += amount;
            // check for level up
            while (experience >= 5)
            {
                levelUp();
            }
            return experience;
        }

        // methods to retrieve different dictionaries of the character
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
            foreach (var stat in stats.Keys.ToList())
            {
                // calculate stat based on level and growth modifier
                stats[stat] = 10 + (level - 1) + statGrowths[stat];
            }

            maxHealth = stats["Vigor"] * 2;
            restoreHp();
        }

        public int getArmoclass()
        {
            return armorClass;
        }

        public Weapon? getWeapon()
        {
            return weapon;
        }

        // used to diffrentiate between player and enemy characters
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

        public void setHealth(int amount) // updated to allow changing the character's current health to whatever we want - Luis
        {
            health = amount;
        }

        public void restoreHp() //Restores the character back to full health, currently used on battle start, will need to be changed when longer campaign - J
        {
            health = maxHealth;
        }

        public void changeHp(int x)
        {
            health = x;
        }

        // used exclusively for enemy ai actions
        // inside each defined enemy class , this method will be overridden to define unique behaviors
        public virtual Character takeAction(List<Character> targets)
        {
            Random random = new Random();
            return targets[random.Next(targets.Count)];
        }

        
         
        public void useItem(Item item, Character target){
            item.Use(target);
        }

        /* placeholder skill usage method

        public void useSkill(Skill skill){
            skill.use();
        }
         */

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
