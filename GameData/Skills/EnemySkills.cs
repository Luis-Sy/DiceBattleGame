using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Skills
{
    // class encompassing all enemy skills
    internal class EnemySkills
    {
        // used by Orcs and Hobogoblins
        public class HeavySmash : Skill
        {
            internal HeavySmash() : base("Heavy Smash", 2, 2)
            {

            }
            internal override int UseSkill(Character entity, Character enemy)
            {
                if(Uses > 0)
                {
                    // Heavy smash does blunt plus extra 5 flat damage
                    int damage = ((int)entity.attack() + 5) * (int)enemy.getResistances()["Blunt"]; 
                    Uses--;
                    return damage;
                }
                return 0;
            }
        }

        // used by Goblins, Bandits, and Mercenaries
        public class SneakyStrike : Skill
        {

            internal SneakyStrike() : base("Sneaky Strike", 3, 3)
            {

            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                if(Uses > 0)
                {
                    // Sneaky strike scales with dexterity and deals piercing damage
                    int damage = ((int)entity.getStatCheckBonus("Dexterity") * 3) * (int)enemy.getResistances()["Pierce"];
                    Uses--;
                    return damage;
                }
                return 0;
            }

        }



    }
}
