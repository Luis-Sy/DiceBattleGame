using DiceBattleGame.GameData.Characters;
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
        private List<Character>? playerParty = null;
        private List<Character>? enemyParty = null;
        //to keep track of whose turn it is and if the battle has ended
        private bool playerTurn;
        private bool battleOver;

        int shownHP;


        // list of all characters in battle
        private List<Character> turnOrder = new List<Character>();

        // index pointing to whose turn it is
        private int turnIndex = 0;

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
            // assign all fighters
            turnOrder = playerCharacters.Concat(enemyCharacters).ToList();

            // remove any dead characters just in case
            turnOrder = turnOrder.Where(c => c.getHealth() > 0).ToList();

            battleOver = false;

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

            turnIndex = 0;

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
                Log($"It is {current.getName()}'s turn (PLAYER).");

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
                Log($"It is {current.getName()}'s turn (ENEMY).");

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
                }else if (enemyAction == "Skill")
                {
                    // to be implemented
                }else if (enemyAction == "Item")
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

            // Move to next character
            turnIndex++;
            if (turnIndex >= turnOrder.Count)
                turnIndex = 0;
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

            if (roll >= ac)
            {
                int damage = attacker.attack();
                string dmgType = attacker.getWeaponType();
                Log($"{attackerName} hits {defenderName} for {damage} damage! (roll {roll} vs AC{ac});");
                defender.takeDamage(damage, dmgType);
                shownHP = Math.Max(0, defender.getHealth());
                Log($"{defenderName}'s health is now: {shownHP}");
            }
            else
            {
                Log($"{attackerName} missed! (Roll{roll} vs AC{ac})");
            }
        }

        private void performSkill(Character user, Character target, string skillName)
        {
            // Placeholder for skill logic
            Log($"{user.getName()} uses {skillName} on {target.getName()}.");
        }

        private void useItem(Character user, string itemName)
        {
            // Placeholder for item usage logic
            Log($"{user.getName()} uses {itemName}.");
        }
    }

}