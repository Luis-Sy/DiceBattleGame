using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.MapEvents.CombatEncounters;
using DiceBattleGame.GameData.System;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace DiceBattleGame.Forms_UI
{
    public partial class BattleForm : Form
    {
        //manges turn logic and combat flow
        private TurnManager turnManager;
       

        //list holding player and enemy characters
        private List<Character> playerParty;
        private List<Character> enemyParty;

        //currently selected enemy for player attacks
        private Character? selectedEnemy = null;

        //init the battle form with player and encounter data
        public BattleForm(Character player, CombatEncounter encounter)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10);
            this.Text = "Battle";

            playerParty = new() { player };
            enemyParty = encounter.GetEventData<List<Character>>()!;

            foreach (var e in enemyParty)
                e.restoreHp();



            //InitializeUI();
            StyleButtons();
            StartBattle();
        }

        // --------------------------------
        // INIT
        
        //initialize labels, names and hp bars for players and enemies
        //private void InitializeUI()
        //{
        //    var player = playerParty[0];
        //    var enemy = enemyParty[0];


        //    lbl_EnemyPlayer.Text = enemy.getName();

        //    statusBar1.maxValue = player.getMaxHealth();
        //    statusBar2.maxValue = enemy.getMaxHealth();

        //    UpdateStatusBars();
        //}
        private void StyleButtons()
        {
            StyleButton(btn_Attack, Color.FromArgb(200, 80, 90));   // red
            StyleButton(btn_Skill, Color.FromArgb(80, 120, 200));  // blue
            StyleButton(btn_Item, Color.FromArgb(150, 150, 150));  // gray
            StyleButton(btn_NextTurn, Color.FromArgb(76, 175, 80)); // green
            StyleButton(btn_BackMap, Color.FromArgb(120, 120, 120)); // dark gray
        }

        private void StyleButton(Button btn, Color color)
        {
            btn.BackColor = color;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
        }


        private void StartBattle()
        {
            turnManager = new TurnManager();
            turnManager.SetOutputBox(txt_TextBox);
            turnManager.StartBattle(playerParty, enemyParty);

            BuildPartyPanels();
            UpdateAllHP();
            //UpdateStatusBars();

            btn_Attack.Enabled = false;
            HandleTurnStart();
        }

        //update ui elements depending on whose turn it is 
        private void HandleTurnStart()
        {
            Character current = turnManager.GetCurrentCharacter();

            if (current.getCharacterType() == "Player")
            {
                lbl_Turn.Text = "TURN: PLAYER";
                btn_Attack.Enabled = true;
            }
            else
            {
                lbl_Turn.Text = "TURN: ENEMY";
                btn_Attack.Enabled = false;
            }
        }

        //---------------------------------------------
        // ATTACK

        //handles player clicking the attack button
        private void btn_Attack_Click(object sender, EventArgs e)
        {
            Character current = turnManager.GetCurrentCharacter();
            //prevent attacking if it is not the players turn
            if (current.getCharacterType() != "Player")
                return;

            //ensure a valid enemy is selected
            if (selectedEnemy == null || !selectedEnemy.isAlive())
            {
                MessageBox.Show("Select a living enemy first");
                return;
            }

            ExecutePlayerAttack(current, selectedEnemy);

            //disable attck until next player turn
            btn_Attack.Enabled = false;

            UpdateAllHP();
            //UpdateStatusBars();

            //advance turn index only after player finish
            turnManager.AdvanceTurnIndex();
            HandleTurnStart();
        }

        //executes the attack logic for the player
        private void ExecutePlayerAttack(Character attacker, Character target)
        {
            D20 d20 = new D20();
            int roll = d20.Roll();
            int ac = target.getArmoclass();

            if (roll >= ac)
            {
                //this is to apply the real damage same as turnmanager code
                int rawDamage = attacker.attack();
                int appliedDamage = target.takeDamage(rawDamage, attacker.getWeaponType());


                txt_TextBox.AppendText(
                    $"{attacker.getName()} hits {target.getName()} for {appliedDamage} damage! " +
                    $"(roll {roll} vs AC {ac})\n"
                );

                txt_TextBox.AppendText(
                    $"{target.getName()}'s health is now: {Math.Max(0, target.getHealth())}\n"
                );
            }
            else
            {
                txt_TextBox.AppendText(
                    $"{attacker.getName()} missed! (roll {roll} vs AC {ac})\n"
                );
            }
        }


        //------------------------------------------------
        // NEXT
        

        //handles advancing the battle when the next button is pressed
        private void btn_NextTurn_Click(object sender, EventArgs e)
        {
            Character current = turnManager.GetCurrentCharacter();

            //prevent skipping the players turn before acting
            if (current.getCharacterType() == "Player" && btn_Attack.Enabled)
                return;

            //execute enemy turn when applicable
            if (current.getCharacterType() != "Player")
            {
                turnManager.NextTurn();
                UpdateAllHP();
                //UpdateStatusBars();

                //enemy acts once then control is return
                turnManager.AdvanceTurnIndex();
                HandleTurnStart();
            }
        }

        //-----------------------------------
        // UI / HP
        
        //private void UpdateStatusBars()
        //{
        //    var p = playerParty[0];
        //    var e = enemyParty[0];

        //    PlayerHealtNumber.Text = $"{p.getHealth()}/{p.getMaxHealth()}";
        //    EnemyHealtNumber.Text = $"{e.getHealth()}/{e.getMaxHealth()}";

        //    statusBar1.SetCurrentValue(p.getHealth());
        //    statusBar2.SetCurrentValue(e.getHealth());
        //}

        private void UpdateAllHP()
        {
            UpdatePartyHP(pnl_PlayerParty);
            UpdatePartyHP(pnl_EnemyParty);
        }

        
        private void UpdatePartyHP(Panel container)
        {
            foreach (Panel card in container.Controls.OfType<Panel>())
            {
                Character c = (Character)card.Tag;

                ProgressBar bar = card.Controls.Find("pb_Player", true).First() as ProgressBar;
                Label lblHP = card.Controls.Find("lbl_HpPlayer", true).First() as Label;

                bar.Maximum = c.getMaxHealth();
                bar.Value = Math.Max(0, Math.Min(c.getHealth(), c.getMaxHealth()));
                lblHP.Text = $"HP: {c.getHealth()} / {c.getMaxHealth()}";

                if (!c.isAlive())
                {
                    card.Enabled = false;
                    card.BackColor = Color.LightGray;
                }
            }
        }
        private void btn_BackMap_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(new MapForm());
        }

        // ============================
        // PANELS
        //build characters cards for players and enemy parties but first clear them
        private void BuildPartyPanels()
        {
            pnl_PlayerParty.Controls.Clear();
            pnl_EnemyParty.Controls.Clear();

            foreach (var p in playerParty)
                pnl_PlayerParty.Controls.Add(CreateCardFromTemplate(p, false));

            foreach (var e in enemyParty)
                pnl_EnemyParty.Controls.Add(CreateCardFromTemplate(e, true));
        }

        private Panel CreateCardFromTemplate(Character c, bool isEnemy)
        {
            Panel card = new Panel
            {
                Width= pnl_CharacterTemplatePlayer.Width,
                Height= pnl_CharacterTemplatePlayer.Height,
                BorderStyle = pnl_CharacterTemplatePlayer.BorderStyle,
                BackColor = pnl_CharacterTemplatePlayer.BackColor,
                Margin = pnl_CharacterTemplatePlayer.Margin,
                Padding = pnl_CharacterTemplatePlayer.Padding,
                Tag = c
            };

            // NAME
            Label tplName = pnl_CharacterTemplatePlayer.Controls.Find("lbl_PlayerName", true).First() as Label;
            Label lblName = new Label
            {
                Name = "lbl_PlayerName",
                Text = c.getName(),
                Location = tplName.Location,
                AutoSize = tplName.AutoSize,
                Font = tplName.Font
            };

            // HP TEXT
            Label tplHP = pnl_CharacterTemplatePlayer.Controls.Find("lbl_HpPlayer", true).First() as Label;
            Label lblHP = new Label
            {
                Name = "lbl_HpPlayer",
                Text = $"HP: {c.getHealth()} / {c.getMaxHealth()}",
                Location = tplHP.Location,
                AutoSize = tplHP.AutoSize,
                Font = tplHP.Font
            };

            // HP BAR
            ProgressBar tplBar = pnl_CharacterTemplatePlayer.Controls.Find("pb_Player", true).First() as ProgressBar;
            ProgressBar hpBar = new ProgressBar
            {
                Name = "pb_Player",
                Location = tplBar.Location,
                Size = tplBar.Size,
                Maximum = c.getMaxHealth(),
                Value = Math.Max(0, c.getHealth())
            };

            card.Controls.Add(lblName);
            card.Controls.Add(lblHP);
            card.Controls.Add(hpBar);

            if (isEnemy)
            {
                card.Cursor = Cursors.Hand;
                card.Click += (s, e) => SelectEnemy(card);

                foreach (Control ctrl in card.Controls)
                    ctrl.Click += (s, e) => SelectEnemy(card);
            }

            return card;
        }


        private void SelectEnemy(Panel panel)
        {
            Character enemy = (Character)panel.Tag;
            if (!enemy.isAlive()) return;

            foreach (Panel p in pnl_EnemyParty.Controls)
                p.BackColor = Color.White;

            panel.BackColor = Color.LightCoral;
            selectedEnemy = enemy;
        }
    }
}
