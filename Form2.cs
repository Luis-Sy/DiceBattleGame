using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace DiceBattleGame
{
    public partial class Form2 : Form
    {
        //Manages battle logic between player and enemy
        private TurnManager? tm = null;

        //list for the dropdown for characters selectors
        private List<Character> playerOptions = new List<Character>();
        private List<Character> enemyOptions = new List<Character>();

        //Weapons systems for player and enemy
        private WeaponSystem playerWeapons = new WeaponSystem();
        private WeaponSystem enemyWeapons = new WeaponSystem();

        public Form2()
        {
            InitializeComponent();

            //populate character and weapon dropdowns
            PopulateSelectorsCharacters();
            PopulateSelectorsWeapons();


            //set default "placeholders" for the dropdowns
            cmb_PlayerSelector.SelectedIndex = 0;
            cmb_EnemySelector.SelectedIndex = 0;
            cmb_WeaponSelector.SelectedIndex = 0;
            
        }

        

        //add all available characters to player and enemy selectors
        private void PopulateSelectorsCharacters()
        {
            // add here more characters for the player in the future
            playerOptions = new List<Character>
            {
                new Knight(),
                new Duelist(),
                new Paladin(),
                new Cleric(),
                new Ranger(),
                new Berserker(),
                new Monk(),
                new Assassin(),
                new Heretic(),
                new Deprived(),
                new Tourist(),
                new Warden(),
                new Instructor(),
                new Awakened(),
                new Samurai(),
                new FallenNoble()
            };

            // add here more characters for the enemy in the future
            enemyOptions = new List<Character>
            {
                // Standard enemies
                new Goblin(),
                new HoboGoblin(),
                new Slime(),
                new Bandit(),
                new Mercenary(),
                new Orc(),
                new Skeleton(),
                new Zombie(),

                // Elite enemies
                new Cultist(),
                new CultistLeader(),
                new MadWarrior(),
                new MadCommander(),
                new Lich(),
                new Mimic(),
                new Werewolf(),
                new Vampire(),
                new WanderingSwordsman(),
                new ElderFragment()
            };

            //popilate dropdowns with character names
            cmb_PlayerSelector.Items.Clear();
            foreach (var c in playerOptions)
            {
                cmb_PlayerSelector.Items.Add(c.getName());

            }

            cmb_EnemySelector.Items.Clear();
            foreach (var e in enemyOptions)
            {
                cmb_EnemySelector.Items.Add(e.getName());
            }

            //defaults selections
            if (cmb_PlayerSelector.Items.Count > 0) cmb_PlayerSelector.SelectedIndex = 0;
            if (cmb_EnemySelector.Items.Count > 0) cmb_EnemySelector.SelectedIndex = 0;

        }

        //populates both players and enemy weapons dropdowns
        private void PopulateSelectorsWeapons()
        {
            cmb_WeaponSelector.Items.Clear();
            foreach (var name in playerWeapons.GetWeaponNames())
            {
                cmb_WeaponSelector.Items.Add(name);
            }
            
        }

        private Character BuildPlayerFromUI()
        {
            int idx = Math.Max(0, cmb_PlayerSelector.SelectedIndex);
            return playerOptions[idx];
        }
        private Character BuildEnemyFromUI()
        {
            int idx = Math.Max(0, cmb_EnemySelector.SelectedIndex);
            return enemyOptions[idx];
        }

        private void txt_TextBox_TextChanged(object sender, EventArgs e)
        {

        }


        private void btn_StartBattle_Click(object sender, EventArgs e)
        {
            txt_TextBox.Clear();

            //create the chosen character
            Character selectedPlayer = BuildPlayerFromUI();
            Character selectedEnemy = BuildEnemyFromUI();

            //Equip players weapon
            if (cmb_WeaponSelector.SelectedIndex >= 0)
            {
                playerWeapons.SelectByIndex(cmb_WeaponSelector.SelectedIndex);
                var chosen = playerWeapons.GetCurrentWeapon();
                selectedPlayer.equip(chosen);


            }

          
            //Start battle
            tm = new TurnManager();
            tm.SetOutputBox(txt_TextBox);

            // Bind status bars to health values of characters (they start at Max health)
            statusBar1.maxValue = selectedPlayer.getHealth();
            statusBar1.currentValue = selectedEnemy.getHealth();

            tm.StartBattle(selectedPlayer, selectedEnemy);
        }

        private void btn_NextTurn_Click(object sender, EventArgs e)
        {
            if (tm != null)
            {
                tm.NextTurn();
            }
        }

        private void cmb_WeaponSelector_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       

        
    }
}
