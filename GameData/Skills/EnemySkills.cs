using DiceBattleGame.GameData.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceBattleGame.GameData.Skills
{
    // class encompassing all enemy skills

    /*
     * stuff here for copilot autocomplete
     Damage types:
        {"Slash", 1.0},
        {"Pierce", 1.0},
        {"Blunt", 1.0},
        {"Magic", 1.0 },
        {"Radiant", 1.0 },
        {"Arcane", 1.0 },
        {"Psychic", 1.0 }
    stats:
        {"Vigor", 10}, // determines max health (Vigor * 2 = health)
        {"Constitution", 10}, // factors in damage mitigation and resistances later
        {"Strength", 10}, 
        {"Dexterity", 10},
        {"Intellect", 10},
        {"Faith", 10}
     
     */
    internal class EnemySkills
    {

        // Common Enemy Skills

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
                    // Heavy smash does Blunt plus extra 5 flat damage
                    int damage = (int)((entity.attack() + 5) * enemy.getResistances()["Blunt"]); 
                    Uses--;
                    return damage;
                }
                return 0;
            }
        }

        // used by Goblins, Skeletons, Bandits, and Mercenaries
        public class SneakyStrike : Skill
        {

            internal SneakyStrike() : base("Sneaky Strike", 3, 3)
            {
            }

            internal override int UseSkill(Character entity, Character enemy)
            {
                if(Uses > 0)
                {
                    // Sneaky strike scales with Dexterity and deals Pierce damage
                    int damage = (int)((entity.getStatCheckBonus("Dexterity") * 2) * enemy.getResistances()["Pierce"]);
                    Uses--;
                    return damage;
                }
                return 0;
            }

        }

        // used by Bandits and Mercenaries
        public class SwiftSlice : Skill
        {
            internal SwiftSlice() : base("Swift Slice", 2, 2)
            {
            }
            internal override int UseSkill(Character entity, Character enemy)
            {
                if(Uses > 0)
                {
                    // Swift Slice scales with Dexterity and deals Slash damage
                    int damage = (int)((entity.getStatCheckBonus("Dexterity") * 2) * enemy.getResistances()["Slash"]);
                    Uses--;
                    return damage;
                }
                return 0;
            }
        }

        // used by Zombies
        public class Bite : Skill
        {
            internal Bite() : base("Bite", 2, 2)
            {
            }
            internal override int UseSkill(Character entity, Character enemy)
            {
                if(Uses > 0)
                {
                    // Bite does Pierce damage plus extra 3 flat damage
                    int damage = (int)(entity.getStatCheckBonus("Strength") * enemy.getResistances()["Pierce"]);
                    Uses--;
                    return damage;
                }
                return 0;
            }
        }

        // used by Slimes
        public class AcidSpray : Skill
        {
            internal AcidSpray() : base("Acid Spray", 2, 2)
            {
            }
            internal override int UseSkill(Character entity, Character enemy)
            {
                if(Uses > 0)
                {
                    // Acid Spray does 4 flat Arcane damage
                    int damage = (int)(4 * enemy.getResistances()["Arcane"]);
                    Uses--;
                    return damage;
                }
                return 0;
            }
        }

        // Elite Enemy Skills

        // used by Cultists and Cultist Leaders
        public class FireBolt : Skill
        {
            internal FireBolt() : base("Fire Bolt", 3, 3)
            {
            }
            internal override int UseSkill(Character entity, Character enemy)
            {
                if(Uses > 0)
                {
                    // Fire Bolt does 4 flat Magic damage
                    int damage = (int)(4 * enemy.getResistances()["Magic"]);
                    Uses--;
                    return damage;
                }
                return 0;
            }
        }

    }
}
