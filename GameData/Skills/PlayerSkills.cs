using DiceBattleGame.GameData.Characters;

namespace DiceBattleGame.GameData.Skills
{
    //These skills have 3 overloads, please default to the overload that takes in the player (user) and the enemy (target) - J
    //It've been nice to use player stats to affect these skills but time constraints have prevented me from getting that far - J
    internal class PlayerSkills
    {
        //public class Backstab : Skill
        //{
        //    public Backstab() : base("Backstab") 
        //    {
        //
        //    }
        //
        //    internal override int Use(Character entity)
        //    {
        //        int damage = (entity.attack() * 2);
        //        return damage;
        //
        //    }
        //
        //    internal override int Use(Character entity, Character enemy)
        //    {
        //        enemy.getHealth();
        //    }
        //    internal override int Use(Character entity, TurnManager t) //This will probably break something. Ideally the turn manager gets a public bool firstTurn to make this work
        //    {
        //        int damage = 0;
        //        try //This is so... SO dumb but this will prevent nonsense 
        //        {
        //            if(t.firstTurn)
        //            {
        //            damage = (entity.attack() * 2); //On first turn 
        //            return damage;
        //            }
        //            else
        //            {
        //                damage = (entity.attack() / 4); //if its not firstturn
        //                return damage;
        //            }
        //        }
        //        catch(Exception e) //prevents an annoying CTD if the turnmanager use fails I think...
        //        {
        //            damage = (entity.attack() * 2);
        //            return damage;
        //        }
        //
        //    }
        //
        //} 
        //============================================================Assassin Skills======================================================
        public class PreciseStrike : Skill
        {
            internal PreciseStrike() : base("Precise Strike", 3, 3)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                double baseDamage;

                if (enemy.getStats()["Dexterity"] < 5)
                    baseDamage = entity.attack() * 2.0;
                else
                    baseDamage = entity.attack() * 0.5;

                double finalDamage = baseDamage * enemy.getResistances()["Pierce"];
                return Math.Max(1, (int)Math.Ceiling(finalDamage));
            }
        }

        //============================================================Awakened Skills========================================================
        public class TheThingStirs : Skill


        //-----------------------------------me fatla
        {
            public TheThingStirs() : base("The Thing Stirs", 3, 3)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {

                int damage = (int)((entity.attack() * 2) * enemy.getResistances()["Psychic"]);

                // debuff effect
                enemy.getResistances()["Psychic"] += 0.5;

                return damage;



            }
        }

        //============================================================Berserker Skills=======================================================

        public class KillingBlow : Skill
        {
            internal KillingBlow() : base("Killing Blow", 3, 3)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                double baseDamage = entity.attack();
                double multiplier = (enemy.getHealth() / (double)enemy.getMaxHealth()) < 0.33 ? 5.0 : 1.0;

                double finalDamage = baseDamage * multiplier * enemy.getResistances()["Blunt"];
                return Math.Max(1, (int)Math.Ceiling(finalDamage));
            }
        }

        //===================================================================Cleric Skills======================================================

        public class DivineBlessing : Skill
        {
            internal DivineBlessing() : base("Divine Intervention", 3, 3)
            {
                TargetType = "Ally";
            }

            internal override int UseSkill(Character entity, Character target)
            {
                int heal = entity.getStats()["Faith"] * 5;
                int newHp = Math.Min(target.getHealth() + heal, target.getMaxHealth());
                target.setHealth(newHp);

                return 0;
            }
        }

        //=======================================================================Deprived Skills=================================================

        public class PocketSand : Skill

        //------------------------------------- me falta
        {
            internal PocketSand() : base("Pocket Sand", 3, 3) //what does a deprived even have? desperation, and with desperaton, comes pocket sand - J
            {
                TargetType = "Enemy";
            }

        internal override int UseSkill(Character entity, Character enemy) //I dont know if this will even work - J
        {


                //Uses--; //comsumes a use

                enemy.getStats()["Dexterity"] -= 5;
                return 0;



        }


        }

    //========================================================================Duelist Skills===================================================
    public class DoubleStrike : Skill
    {
        internal DoubleStrike() : base("Double Strike", 3, 3)
        {
            TargetType = "Enemy";
        }

            internal override int UseSkill(Character entity, Character enemy)
            {
                double finalDamage = (entity.attack() * 2.0) * enemy.getResistances()["Slash"];
                return Math.Max(1, (int)Math.Ceiling(finalDamage));
            }
        }

        //=============================================================================Fallen Noble Skills============================================
        public class BedazzledHandCannon : Skill

        //----------------------------------------me hace falta
        {
            internal BedazzledHandCannon() : base("Bedazzled Hand Cannon", 3, 3)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                int damage = (int)((entity.attack() * 4) * enemy.getResistances()["Pierce"]);
                return damage;
            }
        }
        //=============================================================================Heretic Skills=================================================
        public class Afflict : Skill
        {
            internal Afflict() : base("Afflict", 3, 3)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                enemy.getResistances()["Arcane"] += 1;
                enemy.getResistances()["Magic"] += 1;
                enemy.getResistances()["Psychic"] += 1;
                enemy.getResistances()["Radiant"] += 1;

                double finalDamage = entity.attack() * enemy.getResistances()["Arcane"];
                return Math.Max(1, (int)Math.Ceiling(finalDamage));
            }
        }

        //===================================================================================Knight Skills=============================================
        public class PommelStrike : Skill
        {
            internal PommelStrike() : base("Pommel Strike", 3, 3)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                enemy.getResistances()["Blunt"] += 1.0;

                double finalDamage = (entity.attack() * 0.5) * enemy.getResistances()["Blunt"];
                return Math.Max(1, (int)Math.Ceiling(finalDamage));
            }
        }

        //=========================================================================================Monk Skills===========================================
        public class TheOnePunch : Skill
        {
            internal TheOnePunch() : base("The One Punch", 3, 3)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                double hpRatio = entity.getHealth() / (double)entity.getMaxHealth();
                double multiplier = hpRatio > 0.8 ? 3.0 : 1.0;

                double finalDamage = (entity.attack() * multiplier) * enemy.getResistances()["Blunt"];
                return Math.Max(1, (int)Math.Ceiling(finalDamage));
            }
        }

        //===========================================================Paladin Skills==========================================
        public class Smite : Skill
        {
            public Smite() : base("Smite", 3, 3)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                double finalDamage = entity.attack() * enemy.getResistances()["Radiant"];
                return Math.Max(1, (int)Math.Ceiling(finalDamage));
            }
        }

        //==================================================Ranger Skill==================================================
        public class RainOfArrows : Skill
        {
            public RainOfArrows() : base("Rain of Arrows", 3, 3)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                enemy.getResistances()["Pierce"] += 1;

                double finalDamage = (entity.attack() * 2.0) * enemy.getResistances()["Pierce"];
                return Math.Max(1, (int)Math.Ceiling(finalDamage));
            }
        }

        //===================================================Samurai Skills==============================================
        public class AtomicSlash : Skill
        {
            public AtomicSlash() : base("Atomic Slash", 1, 1)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                double finalDamage = (entity.attack() * 10.0) * enemy.getResistances()["Slash"];
                return Math.Max(1, (int)Math.Ceiling(finalDamage));
            }
        }

        //====================================================Tourist Skills============================================
        public class SmileForTheCamera : Skill
        {
            public SmileForTheCamera() : base("Smile for the Camera", 3, 3)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                enemy.getResistances()["Slash"] += 0.1;
                enemy.getResistances()["Pierce"] += 0.1;
                enemy.getResistances()["Blunt"] += 0.1;
                enemy.getResistances()["Magic"] += 0.1;
                enemy.getResistances()["Radiant"] += 0.1;
                enemy.getResistances()["Arcane"] += 0.1;
                enemy.getResistances()["Psychic"] += 0.1;

                return 0;
            }
        }

        //===================================================Warden Skills===================================================
        public class Shackles : Skill
        {
            public Shackles() : base("Shackles", 3, 3)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                enemy.getResistances()["Slash"] += 0.2;
                enemy.getResistances()["Pierce"] += 0.3;
                enemy.getResistances()["Blunt"] += 0.1;

                return 0;
            }
        }


    }
}

