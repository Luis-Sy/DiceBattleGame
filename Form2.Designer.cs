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
            SuspendLayout();
            // 
            // txt_TextBox
            // 
            txt_TextBox.Location = new Point(133, 270);
            txt_TextBox.Margin = new Padding(2);
            txt_TextBox.Multiline = true;
            txt_TextBox.Name = "txt_TextBox";
            txt_TextBox.ScrollBars = ScrollBars.Vertical;
            txt_TextBox.Size = new Size(512, 236);
            txt_TextBox.TabIndex = 0;
            txt_TextBox.TextChanged += txt_TextBox_TextChanged;
            // 
            // btn_StartBattle
            // 
            btn_StartBattle.Location = new Point(218, 529);
            btn_StartBattle.Margin = new Padding(2);
            btn_StartBattle.Name = "btn_StartBattle";
            btn_StartBattle.Size = new Size(87, 27);
            btn_StartBattle.TabIndex = 1;
            btn_StartBattle.Text = "Start Battle";
            btn_StartBattle.UseVisualStyleBackColor = true;
            btn_StartBattle.Click += btn_StartBattle_Click;
            // 
            // btn_NextTurn
            // 
            btn_NextTurn.Location = new Point(459, 529);
            btn_NextTurn.Margin = new Padding(2);
            btn_NextTurn.Name = "btn_NextTurn";
            btn_NextTurn.Size = new Size(87, 27);
            btn_NextTurn.TabIndex = 2;
            btn_NextTurn.Text = "Next turn";
            btn_NextTurn.UseVisualStyleBackColor = true;
            btn_NextTurn.Click += btn_NextTurn_Click;
            // 
            // lbl_selectPlayer
            // 
            lbl_selectPlayer.AutoSize = true;
            lbl_selectPlayer.Location = new Point(133, 44);
            lbl_selectPlayer.Margin = new Padding(2, 0, 2, 0);
            lbl_selectPlayer.Name = "lbl_selectPlayer";
            lbl_selectPlayer.Size = new Size(94, 20);
            lbl_selectPlayer.TabIndex = 3;
            lbl_selectPlayer.Text = "Select player";
            // 
            // cmb_PlayerSelector
            // 
            cmb_PlayerSelector.FormattingEnabled = true;
            cmb_PlayerSelector.Location = new Point(133, 73);
            cmb_PlayerSelector.Margin = new Padding(2);
            cmb_PlayerSelector.Name = "cmb_PlayerSelector";
            cmb_PlayerSelector.Size = new Size(143, 28);
            cmb_PlayerSelector.TabIndex = 4;
            // 
            // cmb_EnemySelector
            // 
            cmb_EnemySelector.FormattingEnabled = true;
            cmb_EnemySelector.Location = new Point(502, 73);
            cmb_EnemySelector.Margin = new Padding(2);
            cmb_EnemySelector.Name = "cmb_EnemySelector";
            cmb_EnemySelector.Size = new Size(143, 28);
            cmb_EnemySelector.TabIndex = 5;
            // 
            // lbl_selectEnemy
            // 
            lbl_selectEnemy.AutoSize = true;
            lbl_selectEnemy.Location = new Point(502, 44);
            lbl_selectEnemy.Margin = new Padding(2, 0, 2, 0);
            lbl_selectEnemy.Name = "lbl_selectEnemy";
            lbl_selectEnemy.Size = new Size(97, 20);
            lbl_selectEnemy.TabIndex = 6;
            lbl_selectEnemy.Text = "Select Enemy";
            // 
            // cmb_WeaponSelector
            // 
            cmb_WeaponSelector.FormattingEnabled = true;
            cmb_WeaponSelector.Location = new Point(133, 134);
            cmb_WeaponSelector.Margin = new Padding(2);
            cmb_WeaponSelector.Name = "cmb_WeaponSelector";
            cmb_WeaponSelector.Size = new Size(143, 28);
            cmb_WeaponSelector.TabIndex = 7;
            cmb_WeaponSelector.SelectedIndexChanged += cmb_WeaponSelector_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(133, 106);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 8;
            label1.Text = "Weapon selector";
            // 
            // label2
            // 
            label2.Location = new Point(0, 0);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 0;
            // 
            // statusBar1
            // 
            statusBar1.BackColor = SystemColors.ButtonShadow;
            statusBar1.Location = new Point(117, 194);
            statusBar1.Name = "statusBar1";
            statusBar1.Size = new Size(200, 30);
            statusBar1.TabIndex = 9;
            // 
            // statusBar2
            // 
            statusBar2.BackColor = SystemColors.ButtonShadow;
            statusBar2.Location = new Point(474, 194);
            statusBar2.Name = "statusBar2";
            statusBar2.Size = new Size(200, 30);
            statusBar2.TabIndex = 10;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(808, 578);
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
    }
}