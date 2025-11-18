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
        // armor class is the value an attack roll must meet or exceed to hit the character
        protected int armorClass;
        // resistances are multipliers to incoming damage (higher means more damage received from that type)
        protected double slashRes;
        protected double pierceRes;
        protected double bluntRes;

        protected string name = "Character"; // display name
        protected string type = "Character"; // type of character (player/enemy/etc)

        protected Weapon? weapon;

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

    /// <summary>
    /// TODO FOR FINAL:
    /// -Add unique abilities to each class (both player and enemy)
    /// -Add stat scaling to weapons and character stats
    /// -Add elemental damage types and resistances(?)
    /// -separate each category of character into their own files for organization
    /// </summary>

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

    // enemies (uses custom weapons)

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

    internal class MadCommander :Character
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

    // twisted elite enemies (enemies based on the playable classes, but with major differences)

    internal class FallenKnight : Character
    {
        public FallenKnight()
        {
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

}
