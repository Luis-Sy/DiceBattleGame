using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.Items;
using DiceBattleGame.GameData.Skills;
using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceBattleGame
{
    //this class manages the flow of the turns between 2 characters
    internal class TurnManager
    {
        //this holds refrences to the player and enemy characters
        private List<Character>? playerParty = new List<Character>();
        private List<Character>? enemyParty = new List<Character>();

        //to keep track of whose turn it is and if the battle has ended
        //private bool playerTurn;

        //turn state         
        private bool battleOver = false;
        private int turnIndex = 0;
        int shownHP;


        // list of all characters in battle
        private List<Character> turnOrder = new List<Character>();

        //public IReadOnlyList<Character> GetPlayerParty() => playerParty;
        //public IReadOnlyList<Character> GetEnemyParty() => enemyParty;


        //NEW- exposes who currently owns the turn

        public Character GetCurrentCharacter()
        {
            return turnOrder[turnIndex];
        }

        //public void AdvanceTurnIndex()
        //{
        //    if (turnOrder == null || turnOrder.Count == 0)
        //        return;

        //    // Move to next
        //    turnIndex = (turnIndex + 1) % turnOrder.Count;

        //    // Skip dead characters so we don't land on invalid turns
        //    int safety = turnOrder.Count + 5;
        //    while (safety-- > 0 && !turnOrder[turnIndex].isAlive())
        //    {
        //        turnIndex = (turnIndex + 1) % turnOrder.Count;
        //    }
        //}
        public void AdvanceTurnIndex()
        {
            int safety = 0;

            do
            {
                turnIndex++;

                if (turnIndex >= turnOrder.Count)
                    turnIndex = 0;

                safety++;

                // evita loop infinito si todos están muertos
                if (safety > turnOrder.Count)
                    break;

            } while (turnOrder[turnIndex].getHealth() <= 0);
        }







        // NEW — helper to get all alive characters
        public List<Character> GetAliveCharacters()
        {
            return turnOrder.Where(c => c.getHealth() > 0).ToList();
        }

        //reference to the textbox where the battle log is displayed
        private TextBox? logOutput;

        //connecting the form´s textbox to the manager
        public void SetOutputBox(TextBox textBox)
        {
            logOutput = textBox;
        }

        //helper method to write messages into the log box 
        private void Log(string message)
        {
            if (logOutput != null)
            {
                logOutput.AppendText(message + Environment.NewLine);
            }
        }

        public List<Character>? GetPlayerParty()
        {
            return playerParty;
        }

        public List<Character>? GetEnemyParty()
        {
            return enemyParty;
        }

        /*public void restoreCharacters(Character player, Character enemy) //this worked, but I didnt realize it was working, DO NOT ENABLE - J
        {
            enemy.restoreHp();
            player.restoreHp();
        }*/

        /*  ️OLD STARTBATTLE FOR 2 CHARACTERS ONLY
        public void StartBattle(Character playerChar, Character enemyChar)
        {
            this.player = playerChar;
            this.enemy = enemyChar;
            //playerChar.restoreHp();
            //enemyChar.restoreHp(); STACKOVERFLOW HERE DO NOT ENABLE
            this.battleOver = false;
            //roll d20 to see who starts
            D20 d20 = new D20();
            int playerRoll = d20.Roll();
            int enemyRoll = d20.Roll();


            Log($"Player rolled {playerRoll}, enemy rolled {enemyRoll}");
            Log($"Player HP: {player.getHealth()}, Enemy HP: {enemy.getHealth()}");
            Log($"Player AC: {player.getArmoclass()}, Enemy AC: {enemy.getArmoclass()}");


            playerTurn = playerRoll > enemyRoll;
            if (playerTurn)
            {
                Log($"Player {player.getName()} goes first, against enemy {enemy.getName()}.");
                PerformAttack(player, enemy);
                playerTurn = false;
            }
            else
            {
                Log($"Enemy {enemy.getName()} goes first, against player {player.getName()}.");
                PerformAttack(enemy, player);
                playerTurn = true;
            }
        }
*/
        // Starting a new battle now requires two lists of characters, one for player characters, one for enemies
        public void StartBattle(List<Character> playerCharacters, List<Character> enemyCharacters)
        {
            playerParty = playerCharacters;
            enemyParty = enemyCharacters;

            // assign all fighters
            turnOrder = playerCharacters.Concat(enemyParty).ToList();

            // remove any dead characters just in case
            turnOrder = turnOrder.Where(c => c.isAlive()).ToList();

            battleOver = false;
            turnIndex = 0;


            // roll initiative for each character
            List<(Character c, int roll)> rolls = new List<(Character c, int roll)>();
            D20 d20 = new D20();

            foreach (var c in turnOrder)
                rolls.Add((c, d20.Roll()));

            // sort by initiative (highest roll goes first) and rebuild turnOrder
            turnOrder = rolls
                .OrderByDescending(r => r.roll)
                .Select(r => r.c)
                .ToList();



            // log the order (use the sorted rolls for correct roll values)
            Log("=== TURN ORDER ESTABLISHED ===");
            foreach (var entry in rolls.OrderByDescending(r => r.roll))
                Log($"{entry.c.getName()} rolled {entry.roll} initiative.");
            Log("===============================");
        }


        // NEW -----
        public void NextTurn()
        {
            if (battleOver || turnOrder.Count == 0)
                return;

            // Remove dead characters
            turnOrder = turnOrder.Where(c => c.isAlive()).ToList();

            if (turnOrder.Count == 0)
            {
                Log("Everyone has died. Battle over.");
                battleOver = true;
                return;
            }

            // Keep turnIndex safe
            if (turnIndex >= turnOrder.Count)
                turnIndex = 0;

            Character current = turnOrder[turnIndex];

            // If current is dead, skip
            if (!current.isAlive())
            {
                turnIndex++;
                if (turnIndex >= turnOrder.Count)
                    turnIndex = 0;
                return;
            }

            // PLAYER TURN
            if (current.getCharacterType() == "Player")
            {
                //Log($"It is {current.getName()}'s turn (PLAYER).");

                Character? target = turnOrder
                    .FirstOrDefault(c => c.isAlive() && c.getCharacterType() != "Player");

                if (target == null)
                {
                    Log("No enemies left.");
                    battleOver = true;
                    return;
                }


            }
            // ENEMY TURN
            else
            {
                //Log($"It is {current.getName()}'s turn (ENEMY).");

                // enemy selects target based on its behavior
                Character? target = current.enemySelectTarget(playerParty!);


                if (target == null)
                {
                    Log("All players have fallen.");
                    battleOver = true;
                    return;
                }

                // enemy then acts using its defined behavior
                string enemyAction = current.enemyTakeAction();

                if (enemyAction == "Attack")
                {
                    PerformAttack(current, target);
                }
                else if (enemyAction == "Skill")
                {

                    Skill skill = current.enemyUseSkill();
                    // check for targeting
                    if (skill.TargetType == "Enemy")
                    {
                        performSkill(current, target, skill);
                    }
                    else if (skill.TargetType == "Self")
                    {
                        performSkill(current, skill);

                    }
                    else if (enemyAction == "Item")
                    {
                        // to be implemented
                    }
                    else
                    {
                        Log($"{current.getName()} does nothing.");
                    }

                }

                // Check if the battle is over AFTER attack
                if (CheckBattleOver())
                    return;

                //I commented this to handle the turn with the button on battleform
                // Move to next character
                //turnIndex++;
                //if (turnIndex >= turnOrder.Count)
                //    turnIndex = 0;
            }
        }


        // NEW !!! ADDED HELPER
        private bool CheckBattleOver()
        {
            bool anyPlayers = turnOrder.Any(c => c.isAlive() && c.getCharacterType() == "Player");
            bool anyEnemies = turnOrder.Any(c => c.isAlive() && c.getCharacterType() != "Player");

            if (!anyPlayers)
            {
                Log("All players have been defeated.");
                battleOver = true;
                return true;
            }

            if (!anyEnemies)
            {
                Log("All enemies have been defeated.");
                battleOver = true;
                // calculate rewards from battle and distribute to the player
                calculateRewards();
                return true;
            }

            return false;
        }


        // methods below for handling actions during battle
        private void PerformAttack(Character attacker, Character defender)
        {
            D20 d20 = new D20();
            int roll = d20.Roll();
            int ac = defender.getArmoclass();
            string attackerName = attacker.getName();
            string defenderName = defender.getName();
            Log($"It is {attacker.getName()}'s turn ({attacker.getCharacterType().ToUpper()}).");

            if (roll >= ac)
            {
                int damage = attacker.attack();
                string dmgType = attacker.getWeaponType();
                int appliedDamage = defender.takeDamage(damage, dmgType);

                Log($"{attackerName} hits {defenderName} for {appliedDamage} damage! (roll {roll} vs AC{ac});");
                
                shownHP = Math.Max(0, defender.getHealth());
                Log($"{defenderName}'s health is now: {shownHP}");
            }
            else
            {
                Log($"{attackerName} missed! (Roll{roll} vs AC{ac})");
            }
        }

        // skill usage with a target
        public void performSkill(Character user, Character target, Skill skill)
        {
            int damage = skill.UseSkill(user, target);
            target.takeDamage(damage, "Skill"); // damage already calculated in skill usage, pass on the damage
            Log($"{user.getName()} uses {skill.Name} on {target.getName()} for {damage} damage.");
        }

        // skill usage without a target
        public void performSkill(Character user, Skill skill)
        {
            int effectiveness = skill.UseSkill(user);
            // bandaid solution to catch all skills
            Log($"{user.getName()} uses {skill.Name} (Effectiveness: {effectiveness}).");
        }

        // ============================================
        //// PLAYER ACTION — SKILL

        public void PlayerUseSkill(Skill skill, Character? target)
        {
            
            if (battleOver)
                return;

            Character current = GetCurrentCharacter();

            
            if (current.getCharacterType() != "Player")
                return;


            if (skill.Uses <= 0)
            {
                Log($"{skill.Name} has no uses left.\n");
                return;
            }



            Log($"It is {current.getName()}'s turn (PLAYER).\n");

            int result = 0;

            if (target != null)
            {
                result = skill.UseSkill(current, target);

                if (result > 0)
                {


                    target.takeDamage(result, "Skill");

                    Log($"{current.getName()} uses {skill.Name} on {target.getName()} for {result} damage.\n");
                    Log($"{target.getName()}'s health is now: {target.getHealth()}\n");
                }
                else
                {

                    Log($"{current.getName()} uses {skill.Name}.\n");
                }
            }
            else
            {
                skill.UseSkill(current);
                Log($"{current.getName()} uses {skill.Name}.\n");



            }

            
            skill.Uses--;

            if (CheckBattleOver())
                return;

            AdvanceTurnIndex();
        }



        public void useItem(Character user, Character target, Item item)
        {
            // Placeholder for item usage logic
            // items require a target to use on and an item object, typically pulled from an inventory

            if (user.getCharacterType() == "Player")
            {
                user.useItem(item, target);
                // remove from the player's inventory in the CampaignManager
                GameManager.Campaign.GetPlayerInventory().Remove(item);
            }
            else
            {
                user.useItem(item, target);
                // remove the item from the enemy's inventory
                user.getInventory().Remove(item);
            }

            // messages for item usage should probably be handled inside the item class itself
            if (target == null || user == target)
            {
                Log($"{user.getName()} uses {item.Name}.\n");
            }
            else
            {
                Log($"{user.getName()} uses {item.Name} on {target.getName()}.\n");
            }
        }

        private void calculateRewards()
        {
            int goldEarned = 0;
            int expEarned = 0;

            Random random = new Random();

            // calculate total gold and exp based on defeated enemies
            foreach (var enemy in enemyParty!)
            {
                // common enemies grant 3-5 gold and 1 exp
                if (enemy.getCharacterType() == "Enemy")
                {
                    goldEarned += random.Next(2, 6);
                    expEarned += 1;
                }
                // elite enemies grant 5-10 gold and 3 exp
                if (enemy.getCharacterType() == "Elite Enemy")
                {
                    goldEarned += random.Next(5, 11);
                    expEarned += 3;
                }
            }

            Log($"\nYou earned {goldEarned} gold and {expEarned} experience points!");
            // add gold to the campaign state
            GameManager.Campaign.ChangeGold(goldEarned);
            // distribute exp to all player characters
            foreach (var playerChar in playerParty!)
            {
                playerChar.gainExp(expEarned);
            }
        }
    }

}
