
namespace DiceBattleGame.Forms_UI
{
    partial class BattleForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txt_TextBox = new TextBox();
            btn_NextTurn = new Button();
            btn_BackMap = new Button();
            pnl_PlayerParty = new Panel();
            pnl_CharacterTemplatePlayer = new Panel();
            pb_Player = new ProgressBar();
            lbl_HpPlayer = new Label();
            lbl_PlayerName = new Label();
            pnl_EnemyParty = new Panel();
            pnl_CharacterTemplateEnemy = new Panel();
            pb_Enemy = new ProgressBar();
            lbl_HpEnemy = new Label();
            lbl_EnemyName = new Label();
            pnl_Actions = new Panel();
            btn_Item = new Button();
            btn_Skill = new Button();
            btn_Attack = new Button();
            lbl_Turn = new Label();
            pnl_PlayerParty.SuspendLayout();
            pnl_CharacterTemplatePlayer.SuspendLayout();
            pnl_EnemyParty.SuspendLayout();
            pnl_CharacterTemplateEnemy.SuspendLayout();
            pnl_Actions.SuspendLayout();
            SuspendLayout();
            // 
            // txt_TextBox
            // 
            txt_TextBox.Location = new Point(271, 155);
            txt_TextBox.Margin = new Padding(2);
            txt_TextBox.Multiline = true;
            txt_TextBox.Name = "txt_TextBox";
            txt_TextBox.ScrollBars = ScrollBars.Vertical;
            txt_TextBox.Size = new Size(267, 249);
            txt_TextBox.TabIndex = 12;
            // 
            // btn_NextTurn
            // 
            btn_NextTurn.Location = new Point(622, 373);
            btn_NextTurn.Margin = new Padding(2);
            btn_NextTurn.Name = "btn_NextTurn";
            btn_NextTurn.Size = new Size(76, 31);
            btn_NextTurn.TabIndex = 13;
            btn_NextTurn.Text = "Next turn";
            btn_NextTurn.UseVisualStyleBackColor = true;
            btn_NextTurn.Click += btn_NextTurn_Click;
            // 
            // btn_BackMap
            // 
            btn_BackMap.Location = new Point(101, 373);
            btn_BackMap.Name = "btn_BackMap";
            btn_BackMap.Size = new Size(93, 31);
            btn_BackMap.TabIndex = 14;
            btn_BackMap.Text = "Back to map";
            btn_BackMap.UseVisualStyleBackColor = true;
            btn_BackMap.Click += btn_BackMap_Click;
            // 
            // pnl_PlayerParty
            // 
            pnl_PlayerParty.AutoScroll = true;
            pnl_PlayerParty.BorderStyle = BorderStyle.FixedSingle;
            pnl_PlayerParty.Controls.Add(pnl_CharacterTemplateEnemy);
            pnl_PlayerParty.Location = new Point(34, 21);
            pnl_PlayerParty.Name = "pnl_PlayerParty";
            pnl_PlayerParty.Size = new Size(210, 312);
            pnl_PlayerParty.TabIndex = 17;
            // 
            // pnl_CharacterTemplatePlayer
            // 
            pnl_CharacterTemplatePlayer.BorderStyle = BorderStyle.FixedSingle;
            pnl_CharacterTemplatePlayer.Controls.Add(pb_Player);
            pnl_CharacterTemplatePlayer.Controls.Add(lbl_HpPlayer);
            pnl_CharacterTemplatePlayer.Controls.Add(lbl_PlayerName);
            pnl_CharacterTemplatePlayer.Location = new Point(4, 3);
            pnl_CharacterTemplatePlayer.Name = "pnl_CharacterTemplatePlayer";
            pnl_CharacterTemplatePlayer.Size = new Size(200, 74);
            pnl_CharacterTemplatePlayer.TabIndex = 0;
            pnl_CharacterTemplatePlayer.Visible = false;
            // 
            // pb_Player
            // 
            pb_Player.Location = new Point(11, 43);
            pb_Player.Name = "pb_Player";
            pb_Player.Size = new Size(137, 23);
            pb_Player.TabIndex = 2;
            // 
            // lbl_HpPlayer
            // 
            lbl_HpPlayer.AutoSize = true;
            lbl_HpPlayer.Location = new Point(11, 25);
            lbl_HpPlayer.Name = "lbl_HpPlayer";
            lbl_HpPlayer.Size = new Size(26, 15);
            lbl_HpPlayer.TabIndex = 1;
            lbl_HpPlayer.Text = "HP:";
            // 
            // lbl_PlayerName
            // 
            lbl_PlayerName.AutoSize = true;
            lbl_PlayerName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_PlayerName.Location = new Point(62, 7);
            lbl_PlayerName.Name = "lbl_PlayerName";
            lbl_PlayerName.Size = new Size(75, 15);
            lbl_PlayerName.TabIndex = 0;
            lbl_PlayerName.Text = "Player name";
            // 
            // pnl_EnemyParty
            // 
            pnl_EnemyParty.AutoScroll = true;
            pnl_EnemyParty.BorderStyle = BorderStyle.FixedSingle;
            pnl_EnemyParty.Controls.Add(pnl_CharacterTemplatePlayer);
            pnl_EnemyParty.Location = new Point(565, 21);
            pnl_EnemyParty.Name = "pnl_EnemyParty";
            pnl_EnemyParty.Size = new Size(210, 308);
            pnl_EnemyParty.TabIndex = 18;
            // 
            // pnl_CharacterTemplateEnemy
            // 
            pnl_CharacterTemplateEnemy.BorderStyle = BorderStyle.FixedSingle;
            pnl_CharacterTemplateEnemy.Controls.Add(pb_Enemy);
            pnl_CharacterTemplateEnemy.Controls.Add(lbl_HpEnemy);
            pnl_CharacterTemplateEnemy.Controls.Add(lbl_EnemyName);
            pnl_CharacterTemplateEnemy.Location = new Point(3, 3);
            pnl_CharacterTemplateEnemy.Name = "pnl_CharacterTemplateEnemy";
            pnl_CharacterTemplateEnemy.Size = new Size(200, 74);
            pnl_CharacterTemplateEnemy.TabIndex = 3;
            pnl_CharacterTemplateEnemy.Visible = false;
            // 
            // pb_Enemy
            // 
            pb_Enemy.Location = new Point(11, 39);
            pb_Enemy.Name = "pb_Enemy";
            pb_Enemy.Size = new Size(137, 23);
            pb_Enemy.TabIndex = 2;
            // 
            // lbl_HpEnemy
            // 
            lbl_HpEnemy.AutoSize = true;
            lbl_HpEnemy.Location = new Point(11, 21);
            lbl_HpEnemy.Name = "lbl_HpEnemy";
            lbl_HpEnemy.Size = new Size(26, 15);
            lbl_HpEnemy.TabIndex = 1;
            lbl_HpEnemy.Text = "HP:";
            // 
            // lbl_EnemyName
            // 
            lbl_EnemyName.AutoSize = true;
            lbl_EnemyName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_EnemyName.Location = new Point(62, 9);
            lbl_EnemyName.Name = "lbl_EnemyName";
            lbl_EnemyName.Size = new Size(75, 15);
            lbl_EnemyName.TabIndex = 0;
            lbl_EnemyName.Text = "Player name";
            // 
            // pnl_Actions
            // 
            pnl_Actions.BorderStyle = BorderStyle.FixedSingle;
            pnl_Actions.Controls.Add(btn_Item);
            pnl_Actions.Controls.Add(btn_Skill);
            pnl_Actions.Controls.Add(btn_Attack);
            pnl_Actions.Location = new Point(344, 51);
            pnl_Actions.Name = "pnl_Actions";
            pnl_Actions.Size = new Size(101, 99);
            pnl_Actions.TabIndex = 19;
            // 
            // btn_Item
            // 
            btn_Item.Location = new Point(3, 61);
            btn_Item.Name = "btn_Item";
            btn_Item.Size = new Size(93, 23);
            btn_Item.TabIndex = 2;
            btn_Item.Text = "Item";
            btn_Item.UseVisualStyleBackColor = true;
            // 
            // btn_Skill
            // 
            btn_Skill.Location = new Point(3, 32);
            btn_Skill.Name = "btn_Skill";
            btn_Skill.Size = new Size(93, 23);
            btn_Skill.TabIndex = 1;
            btn_Skill.Text = "Skill";
            btn_Skill.UseVisualStyleBackColor = true;
            // 
            // btn_Attack
            // 
            btn_Attack.Location = new Point(3, 3);
            btn_Attack.Name = "btn_Attack";
            btn_Attack.Size = new Size(93, 23);
            btn_Attack.TabIndex = 0;
            btn_Attack.Text = "Attack";
            btn_Attack.UseVisualStyleBackColor = true;
            btn_Attack.Click += btn_Attack_Click;
            // 
            // lbl_Turn
            // 
            lbl_Turn.AutoSize = true;
            lbl_Turn.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Turn.Location = new Point(348, 21);
            lbl_Turn.Name = "lbl_Turn";
            lbl_Turn.Size = new Size(84, 15);
            lbl_Turn.TabIndex = 20;
            lbl_Turn.Text = "TURN:PLAYER";
            // 
            // BattleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbl_Turn);
            Controls.Add(pnl_Actions);
            Controls.Add(pnl_EnemyParty);
            Controls.Add(pnl_PlayerParty);
            Controls.Add(btn_BackMap);
            Controls.Add(btn_NextTurn);
            Controls.Add(txt_TextBox);
            Name = "BattleForm";
            Text = "BattleForm";
            pnl_PlayerParty.ResumeLayout(false);
            pnl_CharacterTemplatePlayer.ResumeLayout(false);
            pnl_CharacterTemplatePlayer.PerformLayout();
            pnl_EnemyParty.ResumeLayout(false);
            pnl_CharacterTemplateEnemy.ResumeLayout(false);
            pnl_CharacterTemplateEnemy.PerformLayout();
            pnl_Actions.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txt_TextBox;
        private Button btn_NextTurn;
        private Button btn_BackMap;
        private Panel pnl_PlayerParty;
        private Panel pnl_EnemyParty;
        private Panel pnl_Actions;
        private Button btn_Item;
        private Button btn_Skill;
        private Button btn_Attack;
        private Label lbl_Turn;
        private Panel pnl_CharacterTemplatePlayer;
        private ProgressBar pb_Player;
        private Label lbl_HpPlayer;
        private Label lbl_PlayerName;
        private Panel pnl_CharacterTemplateEnemy;
        private ProgressBar pb_Enemy;
        private Label lbl_HpEnemy;
        private Label lbl_EnemyName;
    }
}