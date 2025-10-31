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

        
        public void StartBattle(Character playerChar, Character enemyChar)
        {
            this.player = playerChar;
            this.enemy = enemyChar;
            this.battleOver = false;

            //roll d20 to see who starts
            D20 d20 = new D20();
            int playerRoll = d20.Roll();
            int enemyRoll = d20.Roll();



            Log($"Player rolled {playerRoll}, enemy rolled {enemyRoll}");

            if (playerRoll > enemyRoll)
            {
                playerTurn = true;
                Console.WriteLine("Player goes first");
            }
            else
            {
                playerTurn = false;
                Console.WriteLine("Enemy goes first");
            }

            //whoever starts gets to attack immediatly
            if (playerTurn)
            {
                int damage = player.attack();
                string dmgType = player.GetWeaponType();
                Log($"Player {player.GetName()} attacks for {damage} damage");
                enemy.takeDamage(damage, dmgType);
                shownHP = Math.Max(0, enemy.getHealth());//to not show negative health
                Log($"Enemy {enemy.GetName()} Health is now: {shownHP}");
                //after attack switch turn
                playerTurn = false;
            }
            else
            {
                int damage = enemy.attack();
                string dmgType = enemy.GetWeaponType();
                Log($"Enemy {enemy.GetName()} attacks for {damage} damage");
                player.takeDamage(damage, dmgType);
                shownHP = Math.Max(0, player.getHealth());//to not show negative health
                Log($"Player {player.GetName()} Health is now: {shownHP}");

                playerTurn = true;
            }
        }

        //this method runs each new turn-- so player attacks if its their turn or enemy 
        public void NextTurn()
        {
            if (battleOver || player == null || enemy == null) return;

            //player turn attacks 
            if (playerTurn)
            {
                int damage = player.attack();
                string dmgType = player.GetWeaponType();
                Log($"Player {player.GetName()} attacks for {damage} damage");
                enemy.takeDamage(damage, dmgType);
                shownHP = Math.Max(0, enemy.getHealth());//to not show negative health
                Log($"Enemy {enemy.GetName()} Health is now: {shownHP}");

                //check if the health is 0:
                if (enemy.getHealth() <= 0)
                {
                    Log("Enemy has been defeated");
                    battleOver = true;
                    return;
                }
                //If not, turn finished
                playerTurn = false;
            }
            else
            {
                int damage = enemy.attack();
                string dmgType = enemy.GetWeaponType();
                Log($"Enemy {enemy.GetName()} attacks for {damage} damage");
                player.takeDamage(damage,dmgType);
                shownHP = Math.Max(0, player.getHealth());//to not show negative health
                Log($"Player {player.GetName()} Health is now: {shownHP}");

                if (player.getHealth() <= 0)
                {
                    Log("Player has been defeated");
                    battleOver = true;
                    return;
                }
                //if not player turn
                playerTurn = true;

            }
        }
    }


}