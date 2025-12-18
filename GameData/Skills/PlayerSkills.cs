using DiceBattleGame.GameData.Characters;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            internal override int UseSkill(Character entity, Character enemy) //precise strike, good for non agile entities
            {

                if (enemy.getStats()["Dexterity"] < 5)
                {
                    return (int)((entity.attack() * 2) * enemy.getResistances()["Pierce"]);
                }
                else
                {
                    return (int)((entity.attack() / 2) * enemy.getResistances()["Pierce"]);
                }
            }
               

            

            internal override void RestoreUses()
            {
                Uses = DefaultUses;
            }
        }
        //============================================================Awakened Skills========================================================
        public class ThethingStirs : Skill
        {
            public ThethingStirs() : base("The Thing Stirs", 3, 3)
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
            internal KillingBlow() : base("Killing Blow", 3, 3) //Low hp enemies will get crumpled should the attack hit, otherwise, normal attack damage
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                
                    //Uses--; //comsumes a use

                    float remainingHp = (float)enemy.getHealth() / enemy.getMaxHealth();

                    if (remainingHp < .33f)
                    {
                        return  (int)((entity.attack() * 5) * enemy.getResistances()["Blunt"]);
                        
                    }
                return entity.attack();
                }
                

            }

            
        }
        //===================================================================Cleric Skills======================================================

        public class DivineBlessing : Skill
        {
            internal DivineBlessing() : base("Divine Intervention", 3, 3) //A heal
            {
                TargetType = "Ally";
            }

            internal override int UseSkill(Character entity, Character target) // I dont know if this a good way to implement this - J
            {
            int heal = entity.getStats()["Faith"] * 5;
            target.setHealth(target.getHealth() + heal);
            return 0;
        }

            internal override void RestoreUses()
            {
                Uses = DefaultUses;
            }
        }
        //=======================================================================Deprived Skills=================================================

        public class PocketSand : Skill
        {
            internal PocketSand() : base("Pocket Sand", 3, 3) //what does a deprived even have? desperation, and with desperaton, comes pocket sand - J
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy) //I dont know if this will even work - J
            {


            //Uses--; //comsumes a use

                enemy.getStats()["Dexterity"] += 1;
                return 1;



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
                if(Uses > 0)
                {
                    //Uses--;
                    int damage = (int)((entity.attack() * 2) * enemy.getResistances()["Slash"]);

                    return damage;
                }
                else
                {
                    MessageBox.Show("This skill is out of uses!");
                    return 0;
                }
            }
        }
        //=============================================================================Fallen Noble Skills============================================
        public class BedazzledHandCannon : Skill
        {
            internal BedazzledHandCannon() : base("Bedazzled Hand Cannon", 3,3)
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                if(Uses > 0)
                {
                    //Uses--;
                    int damage = (int)((entity.attack() * 4) * enemy.getResistances()["Pierce"]);
                    return damage;
                }
                else
                {
                    MessageBox.Show("This skill is out of uses!");
                    return 0;

                }
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
                if(Uses > 0)
                {
                    //Uses--;
                    int damage = (int)((entity.attack()) * enemy.getResistances()["Arcane"]);
                    enemy.getResistances()["Arcane"] = enemy.getResistances()["Arcane"] + 1; //permanently reduces enemies arcane resistance
                    enemy.getResistances()["Magic"] = enemy.getResistances()["Magic"] + 1;
                    enemy.getResistances()["Psychic"] = enemy.getResistances()["Psychic"] + 1;
                    enemy.getResistances()["Radiant"] = enemy.getResistances()["Radiant"] + 1;
                    return damage;
                }
                else
                {
                    MessageBox.Show("This skill is out of uses!");
                    return 0;
                }
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
                if(Uses > 0)
                {
                    //Uses--;
                    int damage = (int)((entity.attack() * 0.5) * enemy.getResistances()["Blunt"]);
                    enemy.getResistances()["Blunt"] = enemy.getResistances()["Blunt"] + 1;
                    return damage;
                }
                else
                {
                    MessageBox.Show("This skill is out of uses!");
                    return 0;
                }
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
                if(Uses > 0)
                {
                    //Uses--;
                    float remainderHp = entity.getHealth() / entity.getMaxHealth();

                    if(remainderHp > 0.80)
                    {
                        int damage = (int)((entity.attack() * 3) * enemy.getResistances()["Blunt"]);
                        return damage;
                    }
                    else
                    {
                        int damage = (int)((entity.attack()) * enemy.getResistances()["Blunt"]);
                        return damage;
                    }
                    
                }
                else
                {
                    MessageBox.Show("This skill is out of uses!");
                    return 0;
                }
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
                if(Uses > 0)
                {
                    //Uses--;
                    int damage = (int)((entity.attack()) * enemy.getResistances()["Radiant"]);
                    return damage;
                }
                else
                {
                    MessageBox.Show("This skill is out of uses!");
                    return 0;
                }
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
               if(Uses > 0)
                {
                    //Uses--;
                    int damage = (int)((entity.attack() *2) * enemy.getResistances()["Pierce"]);
                    enemy.getResistances()["Pierce"] = enemy.getResistances()["Pierce"] + 1;
                    return damage;

                }
               else
                {
                    MessageBox.Show("This skill is out of uses!");
                    return 0;
                }
            }
        }
        //===================================================Samurai Skills==============================================
        public class AtomicSlash : Skill //This skill is going to be hilariously OP only 1 use
        {
            public AtomicSlash() : base("Atomic Slash",1,1)
            {
                TargetType = "Enemy";
               
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                if(Uses > 0)
                {
                    //Uses--;
                    int damage = (int)((entity.attack() * 10) * enemy.getResistances()["Slash"]);
                    return damage;
                }
                else
                {
                    MessageBox.Show("This skill is out of uses!");
                    return 0;
                }
            }
        }
        //====================================================Tourist Skills============================================
        public class SmileForTheCamera : Skill
        {
            public SmileForTheCamera() : base("Smile for the Camera", 3, 3) //another OP ability, very funny
            {
                TargetType = "Enemy";
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                if(Uses > 0)
                {
                    //Uses--;
                    int damage = 1;
                    enemy.getResistances()["Slash"] = enemy.getResistances()["Slash"] + 0.1;
                    enemy.getResistances()["Pierce"] = enemy.getResistances()["Pierce"] + 0.1;
                    enemy.getResistances()["Blunt"] = enemy.getResistances()["Blunt"] + 0.1;
                    enemy.getResistances()["Magic"] = enemy.getResistances()["Magic"] + 0.1;
                    enemy.getResistances()["Radiant"] = enemy.getResistances()["Radiant"] + 0.1;
                    enemy.getResistances()["Arcane"] = enemy.getResistances()["Arcane"] + 0.1;
                    enemy.getResistances()["Psychic"] = enemy.getResistances()["Psychic"] + 0.1;
                    return damage;
                }
                else
                {
                    MessageBox.Show("This skill is out of uses!");
                    return 0;
                }
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
                if(Uses > 0)
                {
                    //Uses--;
                    int damage = 1;
                    enemy.getResistances()["Slash"] = enemy.getResistances()["Slash"] + 0.2;
                    enemy.getResistances()["Pierce"] = enemy.getResistances()["Pierce"] + 0.3;
                    enemy.getResistances()["Blunt"] = enemy.getResistances()["Blunt"] + 0.1;
                    return damage;
                }
                else
                {
                    MessageBox.Show("This skill is out of uses!");
                    return 0;
                }
            }
        }
    
}

