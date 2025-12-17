using DiceBattleGame.GameData.Characters;

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
                if (Uses > 0)
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
                if (Uses > 0)
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
                if (Uses > 0)
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
                if (Uses > 0)
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
                if (Uses > 0)
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
                if (Uses > 0)
                {
                    // Fire Bolt does 4 flat Magic damage
                    int damage = (int)(4 * enemy.getResistances()["Magic"]);
                    Uses--;
                    return damage;
                }
                return 0;
            }
        }

        // used by Cultist Leaders
        public class FireStorm : Skill
        {
            internal FireStorm() : base("Fire Storm", 1, 1)
            {
            }
            internal override int UseSkill(Character entity, Character enemy)
            {
                if (Uses > 0)
                {
                    // Fire Storm scales off of Faith and does Magic damage
                    int damage = (int)(entity.getStatCheckBonus("Faith") * enemy.getResistances()["Magic"]);
                    Uses--;
                    return damage;
                }
                return 0;
            }
        }

        // used by the Elder Fragment and Elder God
        public class Scorn : Skill
        {
            internal Scorn() : base("Scorn", 2, 2)
            {
            }
            internal override int UseSkill(Character entity, Character enemy)
            {
                if (Uses > 0)
                {
                    // Scorn scales off of Intellect and does Psychic damage
                    int damage = (int)(entity.getStatCheckBonus("Intellect") * enemy.getResistances()["Psychic"]);
                    Uses--;
                    return damage;
                }
                return 0;
            }
        }

        // used by the Elder Fragment and Elder God
        public class Enlighten : Skill
        {
            internal Enlighten() : base("Enlighten", 1, 1)
            {
            }
            internal override int UseSkill(Character entity)
            {
                if (Uses > 0)
                {
                    // Enlighten heals self for Intellect * 2
                    int healAmount = entity.getStatCheckBonus("Intellect") * 2;
                    entity.changeHp(healAmount);
                    Uses--;
                    return healAmount;
                }
                return 0;
            }
        }

        // used by the Lich
        public class SoulSiphon : Skill
        {
            internal SoulSiphon() : base("Soul Siphon", 2, 2)
            {
            }
            internal override int UseSkill(Character entity, Character enemy)
            {
                if (Uses > 0)
                {
                    // Soul Siphon does Magic damage and heals self for half the damage dealt
                    int damage = (int)(entity.getStatCheckBonus("Intellect") * enemy.getResistances()["Magic"]);
                    int healAmount = damage / 2;
                    entity.changeHp(healAmount);
                    Uses--;
                    return damage;
                }
                return 0;
            }

        }

        // used by the MadSoldier and MadCommander
        public class FrenziedStrike : Skill
        {
            internal FrenziedStrike() : base("Frenzied Strike", 3, 3)
            {
            }
            internal override int UseSkill(Character entity, Character enemy)
            {
                if (Uses > 0)
                {
                    // Frenzy Strike scales with Strength and deals Slash damage
                    int damage = (int)((entity.getStatCheckBonus("Strength") * 2) * enemy.getResistances()["Slash"]);
                    Uses--;
                    return damage;
                }
                return 0;
            }

        }
    }
}
