using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.MapEvents.CombatEncounters;
using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace DiceBattleGame.Forms_UI
{
    public partial class BattleForm : Form
    {
        private TurnManager turnManager;
        private Character player;
        private Character enemy;
        private CombatEncounter encounter;

        public BattleForm(Character player, CombatEncounter encounter)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10);
            this.Text = "Battle";

            // Assign player
            this.player = player;
            this.encounter = encounter;

            //extract enemy from encounter data
            List<Character> enemies = encounter.GetEventData<List<Character>>();
            if (enemies == null || enemies.Count == 0)
            {
                MessageBox.Show("error:no enemies found");
                GameManager.SwitchTo(new MapForm());
                return;
            }

            enemy = enemies[0];
            //player.restoreHp();
            enemy.restoreHp();

            InitializeUI();
            StyleButtons();
            StartBattle();
        }
        private void StyleButtons()
        {
            StyleButton(btn_NextTurn, Color.FromArgb(76, 175, 80)); //green
            StyleButton(btn_BackMap, Color.FromArgb(120, 120, 120));//gray
        }
        private void StyleButton(Button btn, Color backColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

        }

        private void InitializeUI()
        {
            lbl_PlayerName.Text = player.getName();
            lbl_EnemyPlayer.Text = enemy.getName();

            statusBar1.maxValue = player.getMaxHealth();
            statusBar2.maxValue = enemy.getMaxHealth();

            statusBar1.currentValue = player.getHealth();
            statusBar2.currentValue = enemy.getHealth();

            //health is reaching negative value so I'm fixing it in character
            PlayerHealtNumber.Text = $"{player.getHealth()}/{player.getMaxHealth()}";
            EnemyHealtNumber.Text = $"{enemy.getHealth()}/{enemy.getMaxHealth()}";
        }

        private void UpdateStatusBars()
        {
            statusBar1.SetCurrentValue(player.getHealth());
            statusBar2.SetCurrentValue(enemy.getHealth());

            PlayerHealtNumber.Text = $"{player.getHealth()}/{player.getMaxHealth()}";
            EnemyHealtNumber.Text = $"{enemy.getHealth()}/{enemy.getMaxHealth()}";
        }

        private void StartBattle()
        {
            turnManager = new TurnManager();
            turnManager.SetOutputBox(txt_TextBox);

            turnManager.StartBattle(player, enemy);

            UpdateStatusBars();
        }

        private void btn_NextTurn_Click(object sender, EventArgs e)
        {
            turnManager.NextTurn();
            UpdateStatusBars();

            if (enemy.getHealth() <= 0)
            {
                txt_TextBox.AppendText("\nEnemy defeated\n");
                Endbattle();
            }
            else if (player.getHealth() <= 0)
            {
                txt_TextBox.AppendText("\nYou were defeated");
                GameManager.PlayerIsDead = true;
                turnManager.ForceEndBattle();
                Endbattle();
                
            }
        }

        private void Endbattle()
        {
            btn_NextTurn.Enabled = false;
            Timer timer = new Timer();
            timer.Interval = 1500;
            timer.Tick += (s, ev) =>
            {
                timer.Stop();
                if(GameManager.PlayerIsDead)
                {
                    MessageBox.Show("Game over");
                    GameManager.SwitchTo(new StartMenuForm());
                }
                else
                {
                    GameManager.SwitchTo(new MapForm());
                }
                    
            };
            timer.Start();
        }

        private void btn_BackMap_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(new MapForm());
        }
    }
}
