using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.Items;
using DiceBattleGame.GameData.MapEvents.CombatEncounters;
using DiceBattleGame.GameData.Skills;
using DiceBattleGame.GameData.System;
using Microsoft.VisualBasic.Logging;
using System.Text;

namespace DiceBattleGame.Forms_UI
{
    public partial class BattleForm : Form
    {
        //manges turn logic and combat flow
        private TurnManager turnManager;

        private CampaignManager campaing;


        //list holding player and enemy characters
        private List<Character> playerParty;
        private List<Character> enemyParty;

        //currently selected enemy for player attacks
        private Character? selectedEnemy = null;

        private Character? currentPlayerHighlighted = null;


        //battle state flags
        private bool battleEnded = false;
        public bool playerWon { get; set; } = false;

        //init the battle form with player and encounter data
        public BattleForm(List<Character> party, CombatEncounter encounter, CampaignManager campaignManager)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10);
            this.Text = "Battle";

            this.campaing = campaignManager;
            playerParty = party;
            enemyParty = encounter.GetEventData<List<Character>>()!;

            foreach (var e in enemyParty)
                e.restoreHp();


            pnl_Skills.Visible = true;
            pnl_Items.Visible = true;


            StyleButtons();
            StartBattle();
        }

        // --------------------------------
        // INIT

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

                SelectCurrentPlayer(current);
                BuildSkillPanel(current);
                pnl_Skills.Visible = true;

                pnl_Items.Visible = true;
                btn_Skill_Click(null, null);
                LoadItemPanel();


            }
            else
            {
                lbl_Turn.Text = "TURN: ENEMY";
                btn_Attack.Enabled = false;
                btn_Skill.Enabled = false;
                foreach (Panel p in flp_PlayerParty.Controls.OfType<Panel>())
                    p.BackColor = pnl_CharacterTemplatePlayer.BackColor;
            }

            //check if battle is over
            if (AreAllEnemiesDead())
            {
                EndBattleVictory();
                return;
            }
        }
        private void BuildSkillPanel(Character player)
        {
            pnl_Skills.Controls.Clear();

            int y = 5;

            foreach (Skill skill in player.getSkills())
            {
                Button btn = new Button
                {
                    Text = $"{skill.Name} ({skill.Uses}/{skill.DefaultUses})",
                    Width = pnl_Skills.Width - 15,
                    Height = 30,
                    Left = 5,
                    Top = y,
                    Enabled = skill.Uses > 0,
                    Tag = skill
                };

                btn.Click += SkillButton_Click;
                pnl_Skills.Controls.Add(btn);
                y += 30;
            }
        }

        private void SkillButton_Click(object sender, EventArgs e)
        {
            if (sender is not Button btn)
                return;

            Skill skill = (Skill)btn.Tag;

            // ejecutar skill (TurnManager controla todo)
            turnManager.PlayerUseSkill(skill, selectedEnemy);

            // refrescar UI
            UpdateAllHP();
            HandleTurnStart();
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

            //check if battle is over
            if (AreAllEnemiesDead())
            {
                EndBattleVictory();
                return;
            }

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
        //--------------------------------------
        //SKILL
        private void btn_Skill_Click(object sender, EventArgs e)
        {
            Character current = turnManager.GetCurrentCharacter();

            //execute skill (turnmanager handles the logic)
            if (current.getCharacterType() != "Player")
                return;

            pnl_Skills.Controls.Clear();
            pnl_Skills.Visible = true;

            var skills = current.getSkills();

            if (skills.Count == 0)
            {
                Label lbl = new Label
                {
                    Text = "No skills available.",
                    AutoSize = true,
                    Left = 5,
                    Top = 5
                };
                pnl_Skills.Controls.Add(lbl);
                return;
            }

            int y = 5;

            foreach (Skill skill in skills)
            {
                Button btn = new Button
                {
                    Text = $"{skill.Name} ({skill.Uses}/{skill.DefaultUses})",
                    Width = pnl_Skills.Width - 15,
                    Height = 25,
                    Left = 5,
                    Top = y,
                    Enabled = skill.Uses > 0,
                    Tag = skill
                };

                btn.Click += (s, ev) =>
                {
                    Skill selectedSkill = (Skill)((Button)s).Tag;

                    if (selectedSkill.Uses <= 0)
                    {
                        MessageBox.Show("That skill has no uses left.");
                        return;
                    }

                    turnManager.PlayerUseSkill(selectedSkill, selectedEnemy);

                    UpdateAllHP();
                    HandleTurnStart();
                };

                pnl_Skills.Controls.Add(btn);
                y += 30;
            }
        }

        //------------------------------------------------
        // ITEM

        //private void btn_Item_Click(object sender, EventArgs e)
        //{
        //    // EXACTAMENTE igual que Skills
        //    Character current = turnManager.GetCurrentCharacter();

        //    // solo permitir en turno del jugador
        //    if (current.getCharacterType() != "Player")
        //        return;

        //    pnl_Items.Controls.Clear();
        //    pnl_Items.Visible = true;

        //    var inventory = GameManager.Campaign.GetPlayerInventory();

        //    if (inventory.Count == 0)
        //    {
        //        MessageBox.Show("No items available.");
        //        return;
        //    }

        //    // agrupar por tipo para mostrar cantidad
        //    var groupedItems = inventory
        //        .GroupBy(i => i.GetType())
        //        .Select(g => new
        //        {
        //            ItemType = g.Key,
        //            Count = g.Count(),
        //            SampleItem = g.First()
        //        });

        //    int y = 5;

        //    foreach (var group in groupedItems)
        //    {
        //        Button btn = new Button
        //        {
        //            Text = $"{group.SampleItem.Name} (x{group.Count})",
        //            Width = pnl_Items.Width - 10,
        //            Height = 25,
        //            Left = 5,
        //            Top = y,
        //            Enabled = true
        //        };

        //        btn.Click += (s, ev) =>
        //        {
        //            // usar UNA instancia del item
        //            Item itemToUse = inventory.FirstOrDefault(i => i.GetType() == group.ItemType);

        //            if (itemToUse == null)
        //            {
        //                MessageBox.Show("You don't have this item anymore.");
        //                pnl_Items.Controls.Clear();
        //                btn_Item_Click(null, null);
        //                return;
        //            }

        //            itemToUse.Use(current);
        //            inventory.Remove(itemToUse);

        //            txt_TextBox.AppendText(
        //                $"{current.getName()} used {itemToUse.Name}.\r\n"
        //            );

        //            UpdateAllHP();
        //            HandleTurnStart();

        //            // consumir turno
        //            turnManager.AdvanceTurnIndex();
        //        };

        //        pnl_Items.Controls.Add(btn);
        //        y += 30;
        //    }
        //}

        private void btn_Item_Click(object sender, EventArgs e)
        {
            Character current = turnManager.GetCurrentCharacter();

            if (current.getCharacterType() != "Player")
                return;

            pnl_Items.Visible = true;

            LoadItemPanel();
        }
        private void LoadItemPanel()
        {
            pnl_Items.Controls.Clear();

            var inventory = GameManager.Campaign.GetPlayerInventory();

            if (inventory.Count == 0)
            {
                Label lbl = new Label
                {
                    Text = "No items available.",
                    AutoSize = true,
                    Left = 5,
                    Top = 5
                };
                pnl_Items.Controls.Add(lbl);
                return;
            }

            var groupedItems = inventory
                .GroupBy(i => i.GetType())
                .Select(g => new
                {
                    ItemType = g.Key,
                    Count = g.Count(),
                    SampleItem = g.First()
                });

            int y = 5;

            foreach (var group in groupedItems)
            {
                Button btn = new Button
                {
                    Text = $"{group.SampleItem.Name} ({group.Count})",
                    Width = pnl_Items.Width - 10,
                    Height = 25,
                    Left = 5,
                    Top = y
                };

                btn.Click += (s, e) =>
                {
                    Character current = turnManager.GetCurrentCharacter();


                    Item itemToUse = inventory.First(i => i.GetType() == group.ItemType);

                    itemToUse.Use(current);
                    inventory.Remove(itemToUse);

                    txt_TextBox.AppendText(
                        $"{current.getName()} used {itemToUse.Name}.\n"
                    );

                    UpdateAllHP();
                    LoadItemPanel();

                    turnManager.AdvanceTurnIndex();
                    HandleTurnStart();
                };

                pnl_Items.Controls.Add(btn);
                y += 30;
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

                //check if the player lost
                if (playerParty.All(p => !p.isAlive()))
                {
                    EndBattleDefeat();
                }

                //enemy acts once then control is return
                turnManager.AdvanceTurnIndex();
                HandleTurnStart();
            }
        }


        private bool AreAllEnemiesDead()
        {
            return enemyParty.All(e => !e.isAlive());
        }

        private void EndBattleVictory()
        {
            battleEnded = true;
            playerWon = true;

            lbl_Turn.Text = "VICTORY";
            btn_Attack.Enabled = false;
            btn_Skill.Enabled = false;
            btn_Item.Enabled = false;
            btn_NextTurn.Enabled = false;

            txt_TextBox.AppendText("\nAll enemies defeated!\n");
            // calculate rewards from battle and distribute to the player
            turnManager.calculateRewards();
        }

        private void EndBattleDefeat()
        {
            battleEnded = true;
            playerWon = false;

            lbl_Turn.Text = "DEFEAT";
            btn_Attack.Enabled = false;
            btn_Skill.Enabled = false;
            btn_Item.Enabled = false;
            btn_NextTurn.Enabled = false;

            txt_TextBox.AppendText("\nYou have been defeated...\n");
        }

        private void btn_BackMap_Click(object sender, EventArgs e)
        {
            if (!battleEnded)
            {
                MessageBox.Show("You must finish the battle first");
                return;
            }

            campaing.ResolveCombat(playerWon);
            this.Close();
            //GameManager.SwitchTo(new MapForm());
        }



        //-----------------------------------
        // UI / HP

        private void UpdateAllHP()
        {
            UpdatePartyHP(flp_PlayerParty);
            UpdatePartyHP(flp_EnemyParty);
        }

        //accepts control so it works with flowlayoutpanel
        private void UpdatePartyHP(Control container)
        {
            foreach (Panel card in container.Controls.OfType<Panel>())
            {
                Character c = (Character)card.Tag;

                ProgressBar bar = card.Controls.OfType<ProgressBar>().FirstOrDefault();
                Label lblHP = card.Controls.OfType<Label>().FirstOrDefault(l => l.Name.Contains("Hp"));

                if (bar != null)
                {
                    bar.Maximum = c.getMaxHealth();
                    bar.Value = Math.Max(0, Math.Min(c.getHealth(), c.getMaxHealth()));
                }
                if (lblHP != null)
                {
                    lblHP.Text = $"HP:{c.getHealth()}/{c.getMaxHealth()}";
                }
                if (!c.isAlive())
                {
                    card.Enabled = false;
                    card.BackColor = Color.LightGray;
                }


            }
        }


        // ============================
        // PANELS
        //build characters cards for players and enemy parties but first clear them
        private void BuildPartyPanels()
        {
            flp_PlayerParty.Controls.Clear();
            flp_EnemyParty.Controls.Clear();

            foreach (var p in playerParty)
                flp_PlayerParty.Controls.Add(CreatePlayerCardFromTemplate(p));

            foreach (var e in enemyParty)
                flp_EnemyParty.Controls.Add(CreateEnemyCardFromTemplate(e));
        }

        private Panel CreatePlayerCardFromTemplate(Character c)
        {
            Panel card = new Panel
            {
                Width = pnl_CharacterTemplatePlayer.Width,
                Height = pnl_CharacterTemplatePlayer.Height,
                BorderStyle = pnl_CharacterTemplatePlayer.BorderStyle,
                BackColor = pnl_CharacterTemplatePlayer.BackColor,
                Margin = new Padding(5),
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

            // LEVEL
            Label tplLevel = pnl_CharacterTemplatePlayer.Controls.Find("lbl_PlayerLevel", true).First() as Label;
            Label lblLevel = new Label
            {
                Name = "lbl_PlayerLevel",
                Text = $"Level {c.getLevel()}",
                Location = tplLevel.Location,
                AutoSize = tplLevel.AutoSize,
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
            ProgressBar hpBar = new ProgressBar();
            hpBar.Name = "pb_Player";
            hpBar.Location = tplBar.Location;
            hpBar.Size = tplBar.Size;
            hpBar.Maximum = Math.Max(1, c.getMaxHealth());
            hpBar.Value = Math.Clamp(c.getHealth(), 0, hpBar.Maximum);

            card.Controls.Add(lblName);
            card.Controls.Add(lblLevel);
            card.Controls.Add(lblHP);
            card.Controls.Add(hpBar);
            


            return card;
        }

        private Panel CreateEnemyCardFromTemplate(Character e)
        {
            Panel card = new Panel
            {
                Width = pnl_CharacterTemplateEnemy.Width,
                Height = pnl_CharacterTemplateEnemy.Height,
                BorderStyle = pnl_CharacterTemplateEnemy.BorderStyle,
                BackColor = pnl_CharacterTemplateEnemy.BackColor,
                Margin = new Padding(5),
                Tag = e
            };

            // NAME
            Label tplName = pnl_CharacterTemplateEnemy.Controls.Find("lbl_EnemyName", true).First() as Label;
            Label lblName = new Label
            {
                Name = "lbl_EnemyName",
                Text = e.getName(),
                Location = tplName.Location,
                AutoSize = tplName.AutoSize,
                Font = tplName.Font
            };

            // LEVEL
            Label tplLevel = pnl_CharacterTemplateEnemy.Controls.Find("lbl_EnemyLevel", true).First() as Label;
            Label lblLevel = new Label
            {
                Name = "lbl_EnemyLevel",
                Text = $"Level {e.getLevel()}",
                Location = tplLevel.Location,
                AutoSize = tplLevel.AutoSize,
                Font = tplName.Font
            };

            // HP TEXT
            Label tplHP = pnl_CharacterTemplateEnemy.Controls.Find("lbl_HpEnemy", true).First() as Label;
            Label lblHP = new Label
            {
                Name = "lbl_HpEnemy",
                Text = $"HP: {e.getHealth()} / {e.getMaxHealth()}",
                Location = tplHP.Location,
                AutoSize = tplHP.AutoSize,
                Font = tplHP.Font
            };

            // HP BAR
            ProgressBar tplBar = pnl_CharacterTemplateEnemy.Controls.Find("pb_Enemy", true).First() as ProgressBar;
            ProgressBar hpBar = new ProgressBar();
            hpBar.Name = "pb_Enemy";
            hpBar.Location = tplBar.Location;
            hpBar.Size = tplBar.Size;
            hpBar.Maximum = Math.Max(1, e.getMaxHealth());
            hpBar.Value = Math.Clamp(e.getHealth(), 0, hpBar.Maximum);

            card.Controls.Add(lblName);
            card.Controls.Add(lblLevel);
            card.Controls.Add(lblHP);
            card.Controls.Add(hpBar);
            

            card.Cursor = Cursors.Hand;
            card.Click += (s, e) => SelectEnemy(card);

            foreach (Control c in card.Controls)
                c.Click += (s, e) => SelectEnemy(card);

            return card;
        }


        private void SelectEnemy(Panel panel)
        {
            Character enemy = (Character)panel.Tag;
            if (!enemy.isAlive()) return;

            foreach (Panel p in flp_EnemyParty.Controls.OfType<Panel>())
                p.BackColor = pnl_CharacterTemplateEnemy.BackColor;

            panel.BackColor = Color.LightCoral;
            selectedEnemy = enemy;
        }
        private void SelectCurrentPlayer(Character player)
        {
            if (player == null || !player.isAlive())
                return;

            foreach (Panel p in flp_PlayerParty.Controls.OfType<Panel>())
                p.BackColor = pnl_CharacterTemplatePlayer.BackColor;


            Panel? playerPanel = flp_PlayerParty.Controls
                .OfType<Panel>()
                .FirstOrDefault(p => p.Tag == player);

            if (playerPanel == null)
                return;

    
            playerPanel.BackColor = Color.LightGreen;
            currentPlayerHighlighted = player;
        }

    }
}

