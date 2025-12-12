namespace DiceBattleGame
{
    partial class Form2
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
            btn_StartBattle = new Button();
            btn_NextTurn = new Button();
            lbl_selectPlayer = new Label();
            cmb_PlayerSelector = new ComboBox();
            cmb_EnemySelector = new ComboBox();
            lbl_selectEnemy = new Label();
            cmb_WeaponSelector = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            statusBar1 = new StatusBar();
            statusBar2 = new StatusBar();
            enemy_health_debug = new TextBox();
            enemy_health_debugbtn = new Button();
            player_health_debug = new TextBox();
            player_health_debugbtn = new Button();
            SuspendLayout();
            // 
            // txt_TextBox
            // 
            txt_TextBox.Location = new Point(116, 202);
            txt_TextBox.Margin = new Padding(2);
            txt_TextBox.Multiline = true;
            txt_TextBox.Name = "txt_TextBox";
            txt_TextBox.ScrollBars = ScrollBars.Vertical;
            txt_TextBox.Size = new Size(448, 178);
            txt_TextBox.TabIndex = 0;
            txt_TextBox.TextChanged += txt_TextBox_TextChanged;
            // 
            // btn_StartBattle
            // 
            btn_StartBattle.Location = new Point(191, 397);
            btn_StartBattle.Margin = new Padding(2);
            btn_StartBattle.Name = "btn_StartBattle";
            btn_StartBattle.Size = new Size(76, 20);
            btn_StartBattle.TabIndex = 1;
            btn_StartBattle.Text = "Start Battle";
            btn_StartBattle.UseVisualStyleBackColor = true;
            btn_StartBattle.Click += btn_StartBattle_Click;
            // 
            // btn_NextTurn
            // 
            btn_NextTurn.Location = new Point(402, 397);
            btn_NextTurn.Margin = new Padding(2);
            btn_NextTurn.Name = "btn_NextTurn";
            btn_NextTurn.Size = new Size(76, 20);
            btn_NextTurn.TabIndex = 2;
            btn_NextTurn.Text = "Next turn";
            btn_NextTurn.UseVisualStyleBackColor = true;
            btn_NextTurn.Click += btn_NextTurn_Click;
            // 
            // lbl_selectPlayer
            // 
            lbl_selectPlayer.AutoSize = true;
            lbl_selectPlayer.Location = new Point(152, 33);
            lbl_selectPlayer.Margin = new Padding(2, 0, 2, 0);
            lbl_selectPlayer.Name = "lbl_selectPlayer";
            lbl_selectPlayer.Size = new Size(73, 15);
            lbl_selectPlayer.TabIndex = 3;
            lbl_selectPlayer.Text = "Select player";
            // 
            // cmb_PlayerSelector
            // 
            cmb_PlayerSelector.FormattingEnabled = true;
            cmb_PlayerSelector.Location = new Point(152, 55);
            cmb_PlayerSelector.Margin = new Padding(2);
            cmb_PlayerSelector.Name = "cmb_PlayerSelector";
            cmb_PlayerSelector.Size = new Size(126, 23);
            cmb_PlayerSelector.TabIndex = 4;
            // 
            // cmb_EnemySelector
            // 
            cmb_EnemySelector.FormattingEnabled = true;
            cmb_EnemySelector.Location = new Point(439, 55);
            cmb_EnemySelector.Margin = new Padding(2);
            cmb_EnemySelector.Name = "cmb_EnemySelector";
            cmb_EnemySelector.Size = new Size(126, 23);
            cmb_EnemySelector.TabIndex = 5;
            // 
            // lbl_selectEnemy
            // 
            lbl_selectEnemy.AutoSize = true;
            lbl_selectEnemy.Location = new Point(439, 33);
            lbl_selectEnemy.Margin = new Padding(2, 0, 2, 0);
            lbl_selectEnemy.Name = "lbl_selectEnemy";
            lbl_selectEnemy.Size = new Size(77, 15);
            lbl_selectEnemy.TabIndex = 6;
            lbl_selectEnemy.Text = "Select Enemy";
            // 
            // cmb_WeaponSelector
            // 
            cmb_WeaponSelector.FormattingEnabled = true;
            cmb_WeaponSelector.Location = new Point(152, 100);
            cmb_WeaponSelector.Margin = new Padding(2);
            cmb_WeaponSelector.Name = "cmb_WeaponSelector";
            cmb_WeaponSelector.Size = new Size(126, 23);
            cmb_WeaponSelector.TabIndex = 7;
            cmb_WeaponSelector.SelectedIndexChanged += cmb_WeaponSelector_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(152, 80);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(95, 15);
            label1.TabIndex = 8;
            label1.Text = "Weapon selector";
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(59, 11);
            label2.TabIndex = 0;
            // 
            // statusBar1
            // 
            statusBar1.BackColor = SystemColors.ButtonShadow;
            statusBar1.Location = new Point(152, 146);
            statusBar1.Margin = new Padding(3, 2, 3, 2);
            statusBar1.MaximumSize = new Size(153, 16);
            statusBar1.Name = "statusBar1";
            statusBar1.Size = new Size(153, 16);
            statusBar1.TabIndex = 9;
            // 
            // statusBar2
            // 
            statusBar2.BackColor = SystemColors.ButtonShadow;
            statusBar2.Location = new Point(415, 146);
            statusBar2.Margin = new Padding(3, 2, 3, 2);
            statusBar2.MaximumSize = new Size(153, 16);
            statusBar2.Name = "statusBar2";
            statusBar2.Size = new Size(153, 16);
            statusBar2.TabIndex = 10;
            // 
            // enemy_health_debug
            // 
            enemy_health_debug.Location = new Point(595, 55);
            enemy_health_debug.Name = "enemy_health_debug";
            enemy_health_debug.Size = new Size(100, 23);
            enemy_health_debug.TabIndex = 11;
            enemy_health_debug.TextChanged += enemy_health_debug_TextChanged;
            // 
            // enemy_health_debugbtn
            // 
            enemy_health_debugbtn.Location = new Point(562, 100);
            enemy_health_debugbtn.Name = "enemy_health_debugbtn";
            enemy_health_debugbtn.Size = new Size(133, 23);
            enemy_health_debugbtn.TabIndex = 12;
            enemy_health_debugbtn.Text = "Set enemy hp (debug)";
            enemy_health_debugbtn.UseVisualStyleBackColor = true;
            enemy_health_debugbtn.Click += enemy_health_debugbtn_Click;
            // 
            // player_health_debug
            // 
            player_health_debug.Location = new Point(0, 55);
            player_health_debug.Name = "player_health_debug";
            player_health_debug.Size = new Size(100, 23);
            player_health_debug.TabIndex = 13;
            // 
            // player_health_debugbtn
            // 
            player_health_debugbtn.Location = new Point(0, 99);
            player_health_debugbtn.Name = "player_health_debugbtn";
            player_health_debugbtn.Size = new Size(131, 23);
            player_health_debugbtn.TabIndex = 14;
            player_health_debugbtn.Text = "Set player hp (debug)";
            player_health_debugbtn.TextAlign = ContentAlignment.MiddleLeft;
            player_health_debugbtn.UseVisualStyleBackColor = true;
            player_health_debugbtn.Click += player_health_debugbtn_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 434);
            Controls.Add(player_health_debugbtn);
            Controls.Add(player_health_debug);
            Controls.Add(enemy_health_debugbtn);
            Controls.Add(enemy_health_debug);
            Controls.Add(statusBar2);
            Controls.Add(statusBar1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cmb_WeaponSelector);
            Controls.Add(lbl_selectEnemy);
            Controls.Add(cmb_EnemySelector);
            Controls.Add(cmb_PlayerSelector);
            Controls.Add(lbl_selectPlayer);
            Controls.Add(btn_NextTurn);
            Controls.Add(btn_StartBattle);
            Controls.Add(txt_TextBox);
            Margin = new Padding(2);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txt_TextBox;
        private System.Windows.Forms.Button btn_StartBattle;
        private System.Windows.Forms.Button btn_NextTurn;
        private System.Windows.Forms.Label lbl_selectPlayer;
        private System.Windows.Forms.ComboBox cmb_PlayerSelector;
        private System.Windows.Forms.ComboBox cmb_EnemySelector;
        private System.Windows.Forms.Label lbl_selectEnemy;
        private System.Windows.Forms.ComboBox cmb_WeaponSelector;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private StatusBar statusBar1;
        private StatusBar statusBar2;
        private TextBox enemy_health_debug;
        private Button enemy_health_debugbtn;
        private TextBox player_health_debug;
        private Button player_health_debugbtn;
    }
}