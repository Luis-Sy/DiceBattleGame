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
        private Character? player = null;
        private Character? enemy = null;
        //to keep track of whose turn it is and if the battle has ended
        private bool playerTurn;
        private bool battleOver;

        int shownHP;


        // !!! NEW — list of all characters in battle
        private List<Character> turnOrder = new List<Character>();

        // !!! NEW — index pointing to whose turn it is
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

        public Character? GetPlayer()
        {
            return player;
        }

        public Character? GetEnemy()
        {
            return enemy;
        }

        /*public void restoreCharacters(Character player, Character enemy) //this worked, but I didnt realize it was working, DO NOT ENABLE - J
        {
            enemy.restoreHp();
            player.restoreHp();
        }*/


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

            // NEW STARTBATTLE FOR MULTI-CHARACTER SUPPORT
public void StartBattle(List<Character> characters)
        {
            // assign all fighters
            turnOrder = characters.Where(c => c != null).ToList();

            // remove any dead characters just in case
            turnOrder = turnOrder.Where(c => c.getHealth() > 0).ToList();

            battleOver = false;

            // roll initiative for each character
            Dictionary<Character, int> rolls = new Dictionary<Character, int>();
            D20 d20 = new D20();

            foreach (var c in turnOrder)
                rolls[c] = d20.Roll();

            // sort by initiative (highest roll goes first)
            turnOrder = turnOrder
                .OrderByDescending(c => rolls[c])
                .ToList();

            turnIndex = 0;

            // log the order
            Log("=== TURN ORDER ESTABLISHED ===");
            foreach (var c in turnOrder)
                Log($"{c.getName()} rolled {rolls[c]} initiative.");

            Log("===============================");
        }

        //if (playerRoll > enemyRoll)
        //{
        //    playerTurn = true;
        //    Console.WriteLine("Player goes first");
        //}
        //else
        //{
        //    playerTurn = false;
        //    Console.WriteLine("Enemy goes first");
        //}

        ////whoever starts gets to attack immediatly
        //if (playerTurn)
        //{
        //    int damage = player.attack();
        //    string dmgType = player.getWeaponType();
        //    Log($"Player {player.getName()} attacks for {damage} damage");
        //    enemy.takeDamage(damage, dmgType);
        //    shownHP = Math.Max(0, enemy.getHealth());//to not show negative health
        //    Log($"Enemy {enemy.getName()} Health is now: {shownHP}");
        //    //after attack switch turn
        //    playerTurn = false;
        //}
        //else
        //{
        //    int damage = enemy.attack();
        //    string dmgType = enemy.getWeaponType();
        //    Log($"Enemy {enemy.getName()} attacks for {damage} damage");
        //    player.takeDamage(damage, dmgType);
        //    shownHP = Math.Max(0, player.getHealth());//to not show negative health
        //    Log($"Player {player.getName()} Health is now: {shownHP}");

        //    playerTurn = true;
        //}


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
            if (current.isPlayer())
            {
                Log($"It is {current.getName()}'s turn (PLAYER).");

                Character? target = turnOrder
                    .FirstOrDefault(c => c.isAlive() && !c.isPlayer());

                if (target == null)
                {
                    Log("No enemies left.");
                    battleOver = true;
                    return;
                }

                PerformAttack(current, target);
            }
            // ENEMY TURN
            else
            {
                Log($"It is {current.getName()}'s turn (ENEMY).");

                Character? target = turnOrder
                    .FirstOrDefault(c => c.isAlive() && c.isPlayer());

                if (target == null)
                {
                    Log("All players have fallen.");
                    battleOver = true;
                    return;
                }

                PerformAttack(current, target);
            }

            // Check if the battle is over AFTER attack
            if (CheckBattleOver())
                return;

            // Move to next character
            turnIndex++;
            if (turnIndex >= turnOrder.Count)
                turnIndex = 0;
        }


            //if (playerTurn)
            //{
            //    int damage = player.attack();
            //    string dmgType = player.getWeaponType();
            //    Log($"Player {player.getName()} attacks for {damage} damage");
            //    enemy.takeDamage(damage, dmgType);
            //    shownHP = Math.Max(0, enemy.getHealth());//to not show negative health
            //    Log($"Enemy {enemy.getName()} Health is now: {shownHP}");

            //    //check if the health is 0:
            //    if (enemy.getHealth() <= 0)
            //    {
            //        Log("Enemy has been defeated");
            //        battleOver = true;
            //        return;
            //    }
            //    //If not, turn finished
            //    playerTurn = false;
            //}
            //else
            //{
            //    int damage = enemy.attack();
            //    string dmgType = enemy.getWeaponType();
            //    Log($"Enemy {enemy.getName()} attacks for {damage} damage");
            //    player.takeDamage(damage,dmgType);
            //    shownHP = Math.Max(0, player.getHealth());//to not show negative health
            //    Log($"Player {player.getName()} Health is now: {shownHP}");

            //    if (player.getHealth() <= 0)
            //    {
            //        Log("Player has been defeated");
            //        battleOver = true;
            //        return;
            //    }
            //    //if not player turn
            //    playerTurn = true;

            //}
        

        // NEW !!! ADDED HELPER
        private bool CheckBattleOver()
        {
            bool anyPlayers = turnOrder.Any(c => c.isAlive() && c.isPlayer());
            bool anyEnemies = turnOrder.Any(c => c.isAlive() && !c.isPlayer());

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

        private void PerformAttack(Character attacker, Character defender)
        {
            D20 d20 = new D20();
            int roll = d20.Roll();
            int ac = defender.getArmoclass();
            string attackerName = attacker.getName();
            string deffenderName = defender.getName();

            if (roll >= ac)
            {
                int damage = attacker.attack();
                string dmgType = attacker.getWeaponType();
                Log($"{attackerName} hits {deffenderName} for {damage} damage! (roll {roll} vs AC{ac});");
                defender.takeDamage(damage, dmgType);
                shownHP = Math.Max(0, defender.getHealth());
                Log($"{deffenderName}'s health is now: {shownHP}");
            }
            else
            {
                Log($"{attackerName} missed! (Roll{roll} vs AC{ac})");
            }
        }
    }

}