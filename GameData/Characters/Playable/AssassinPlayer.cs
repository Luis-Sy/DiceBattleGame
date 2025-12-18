using DiceBattleGame.GameData.System;
using static DiceBattleGame.GameData.Skills.PlayerSkills;

namespace DiceBattleGame.GameData.Characters.Playable
{
    internal class AssassinPlayer : Character
    {
        public AssassinPlayer() : base()
        {
            type = "Player";
            name = "Assassin";
            statGrowths = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)
            {
                {"Vigor", -3},
                {"Constitution", -1},
                {"Strength", -2},
                {"Dexterity", 5},
                {"Intellect", 3},
                {"Faith", -2}
            };
            initializeStats();
            damageResistances = new Dictionary<string, double>(StringComparer.OrdinalIgnoreCase)
            {
                { "Slash", 2.0 },
                { "Pierce", 0.5 },
                { "Blunt", 1.5 },
                { "Magic", 1.0 },
                { "Radiant", 1.5 },
                { "Arcane", 1.0 },
                { "Psychic", 0.5 }
            };
            armorClass = 12;
            weapon = new Custom("Daggers", "Twin Daggers", "Pierce", new diceBag(7, 2));

            initializeSkills();
        }

        private void initializeSkills()
        {
            skills.Add(new PreciseStrike());
        }
    }
}
