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

        // inventory used exclusively for enemy characters, player inventory is managed in the CampaignManager
        protected List<Item> enemyInventory = new List<Item>();

        // to be implemented
        // protected List<Skill> skills = new List<Skill>();


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
        // used for anything that requires a stat check (item usage, skill checks, etc.)
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
                Trace.WriteLine($"Stat {stat} not recognized! No bonus applied.");
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
            // if it's a player class, add a flat 10 hp to their health pool
            if (this.type == "Player")
            {
                maxHealth += 10;
            }
            restoreHp();
        }

        public int getArmoclass()
        {
            return armorClass;
        }

        public bool isAlive()
        {
            return health > 0;
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
        // inside each defined enemy class, this method will be overridden to define unique behaviors
        // by default, the character will attack a random target and return the attack roll
        public virtual Character enemySelectTarget(List<Character> targets)
        {
            // enemies will now have their attacks be handled by this method instead of in TurnManager
            Random random = new Random();
            Character target = targets[random.Next(targets.Count)];

            return target;
        }

        // used exclusively for enemy ai actions
        // return the item to be used and handle usage in TurnManager
        public virtual Item enemyUseItem()
        {
            Random random = new Random();
            Item item = enemyInventory[random.Next(enemyInventory.Count)];
            return item;
        }

        /*
        // used exclusively for enemy ai actions
        // return skill to be used and handle usage in TurnManager
        public virtual Skill enemyUseSkill(){
            Random random = new Random();
            Skill skill = skills[random.Next(skills.Count)];
            return skill;
        }
         
         */

        // used exclusively for enemy ai actions
        // enemies will return a string to determine their action that turn
        public virtual string enemyTakeAction()
        {
            // by default, enemies will always attack
            // override this in enemy classes to define unique behaviors
            List<string> actions = new List<string> { "Attack" };

            return actions[0];
        }

        // TurnManager will use the above two methods to determine enemy actions during their turn


        public void useItem(Item item, Character target)
        {
            item.Use(target);
        }

        /* placeholder skill methods

        public void useSkill(Skill skill){
            skill.use();
        }

        public List<Skill> getSkills(){
            return skills;
        }
         */

    }

    /// <summary>
    /// TODO FOR FINAL:
    /// -Add unique abilities to each class (both player and enemy)
    /// </summary>
}
