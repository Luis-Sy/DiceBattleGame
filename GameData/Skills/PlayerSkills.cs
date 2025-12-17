using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Skills
{
    //These skills have 3 overloads, please default to the overload that takes in the player (user) and the enemy (target)
    internal class PlayerSkills
    {
        //public class Backstab : Skill
        //{
        //    public Backstab() : base("Backstab") 
        //    {

        //    }

        //    internal override int Use(Character entity)
        //    {
        //        int damage = (entity.attack() * 2);
        //        return damage;

        //    }

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

        //    }

        //}
        //============================================================Assassin Skills======================================================
        public class PreciseStrike : Skill
        {
            internal PreciseStrike() : base("Precise Strike", 3, 3)
            {

            }

            internal override int UseSkill(Character entity, Character enemy) //precise strike, good for non agile entities
            {
                Uses--; //comsumes a use
                if(Uses > 0)
                {
                    if (enemy.getStats()["Dexterity"] < 5)
                    {
                        int damage = (entity.attack() * 2);
                        return damage;
                    }
                    else
                    {
                        int damage = (entity.attack() / 2);
                        return damage;
                    }
                }
                else //popup should be changed, returns 0 if there are not uses This will skill consume the turn, might have to be handled in battle flow.
                {
                    MessageBox.Show("This ability is out of uses!");
                    return 0;
                }

            }

            internal override void RestoreUses()
            {
                Uses = DefaultUses;
            }
        }
        //============================================================Awakened Skills========================================================

        //============================================================Berserker Skills=======================================================

        public class KillingBlow : Skill
        {
            internal KillingBlow() : base("Killing Blow", 3, 3) //Low hp enemies will get crumpled should the attack hit, otherwise, normal attack damage
            {

            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                Uses--; //comsumes a use

                float remainingHp = enemy.getHealth() / enemy.getMaxHealth();

                if (remainingHp < .33)
                {
                    int damage = (entity.attack() * 5);
                    return damage;
                }
                else
                {
                    int damage = entity.attack();
                    return damage;
                }
            }

            internal override void RestoreUses()
            {
                Uses = DefaultUses;
            }
        }
        //===================================================================Cleric Skills======================================================

        public class DivineBlessing : Skill
        {
            internal DivineBlessing() : base("Divine Intervention", 3, 3) //A heal
            {

            }

            internal override int UseSkill(Character entity, Character target) // I dont know if this a good way to implement this - J
            {
                Uses--; //comsumes a use

                int health = entity.getStats()["Faith"] * 5;
                target.setHealth(target.getHealth() + health);
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

            }

            internal override int UseSkill(Character entity, Character enemy) //I dont know if this will even work - J
            {
                Uses--; //comsumes a use

                int damage = 1;
                enemy.getStats()["Dexterity"] = enemy.getStats()["Dexterity"] - 1;
                return damage;
            }

            internal override void RestoreUses()
            {
                Uses = DefaultUses;
            }
        }

        //========================================================================Duelist Skills===================================================

    }
}

