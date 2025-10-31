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
            txt_TextBox = new System.Windows.Forms.TextBox();
            btn_StartBattle = new System.Windows.Forms.Button();
            btn_NextTurn = new System.Windows.Forms.Button();
            lbl_selectPlayer = new System.Windows.Forms.Label();
            cmb_PlayerSelector = new System.Windows.Forms.ComboBox();
            cmb_EnemySelector = new System.Windows.Forms.ComboBox();
            lbl_selectEnemy = new System.Windows.Forms.Label();
            cmb_WeaponSelector = new System.Windows.Forms.ComboBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            cmb_EnemyWeaponSelector = new System.Windows.Forms.ComboBox();
            SuspendLayout();
            // 
            // txt_TextBox
            // 
            txt_TextBox.Location = new System.Drawing.Point(199, 273);
            txt_TextBox.Multiline = true;
            txt_TextBox.Name = "txt_TextBox";
            txt_TextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txt_TextBox.Size = new System.Drawing.Size(766, 352);
            txt_TextBox.TabIndex = 0;
            txt_TextBox.TextChanged += txt_TextBox_TextChanged;
            // 
            // btn_StartBattle
            // 
            btn_StartBattle.Location = new System.Drawing.Point(327, 662);
            btn_StartBattle.Name = "btn_StartBattle";
            btn_StartBattle.Size = new System.Drawing.Size(131, 40);
            btn_StartBattle.TabIndex = 1;
            btn_StartBattle.Text = "Start Battle";
            btn_StartBattle.UseVisualStyleBackColor = true;
            btn_StartBattle.Click += btn_StartBattle_Click;
            // 
            // btn_NextTurn
            // 
            btn_NextTurn.Location = new System.Drawing.Point(689, 662);
            btn_NextTurn.Name = "btn_NextTurn";
            btn_NextTurn.Size = new System.Drawing.Size(131, 40);
            btn_NextTurn.TabIndex = 2;
            btn_NextTurn.Text = "Next turn";
            btn_NextTurn.UseVisualStyleBackColor = true;
            btn_NextTurn.Click += btn_NextTurn_Click;
            // 
            // lbl_selectPlayer
            // 
            lbl_selectPlayer.AutoSize = true;
            lbl_selectPlayer.Location = new System.Drawing.Point(199, 66);
            lbl_selectPlayer.Name = "lbl_selectPlayer";
            lbl_selectPlayer.Size = new System.Drawing.Size(130, 30);
            lbl_selectPlayer.TabIndex = 3;
            lbl_selectPlayer.Text = "Select player";
            // 
            // cmb_PlayerSelector
            // 
            cmb_PlayerSelector.FormattingEnabled = true;
            cmb_PlayerSelector.Location = new System.Drawing.Point(199, 109);
            cmb_PlayerSelector.Name = "cmb_PlayerSelector";
            cmb_PlayerSelector.Size = new System.Drawing.Size(212, 38);
            cmb_PlayerSelector.TabIndex = 4;
            // 
            // cmb_EnemySelector
            // 
            cmb_EnemySelector.FormattingEnabled = true;
            cmb_EnemySelector.Location = new System.Drawing.Point(753, 109);
            cmb_EnemySelector.Name = "cmb_EnemySelector";
            cmb_EnemySelector.Size = new System.Drawing.Size(212, 38);
            cmb_EnemySelector.TabIndex = 5;
            // 
            // lbl_selectEnemy
            // 
            lbl_selectEnemy.AutoSize = true;
            lbl_selectEnemy.Location = new System.Drawing.Point(753, 66);
            lbl_selectEnemy.Name = "lbl_selectEnemy";
            lbl_selectEnemy.Size = new System.Drawing.Size(136, 30);
            lbl_selectEnemy.TabIndex = 6;
            lbl_selectEnemy.Text = "Select Enemy";
            // 
            // cmb_WeaponSelector
            // 
            cmb_WeaponSelector.FormattingEnabled = true;
            cmb_WeaponSelector.Location = new System.Drawing.Point(199, 201);
            cmb_WeaponSelector.Name = "cmb_WeaponSelector";
            cmb_WeaponSelector.Size = new System.Drawing.Size(212, 38);
            cmb_WeaponSelector.TabIndex = 7;
            cmb_WeaponSelector.SelectedIndexChanged += cmb_WeaponSelector_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(199, 159);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(168, 30);
            label1.TabIndex = 8;
            label1.Text = "Weapon selector";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(753, 159);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(168, 30);
            label2.TabIndex = 9;
            label2.Text = "Weapon selector";
            // 
            // cmb_EnemyWeaponSelector
            // 
            cmb_EnemyWeaponSelector.FormattingEnabled = true;
            cmb_EnemyWeaponSelector.Location = new System.Drawing.Point(753, 201);
            cmb_EnemyWeaponSelector.Name = "cmb_EnemyWeaponSelector";
            cmb_EnemyWeaponSelector.Size = new System.Drawing.Size(212, 38);
            cmb_EnemyWeaponSelector.TabIndex = 10;
            cmb_EnemyWeaponSelector.SelectedIndexChanged += cmb_EnemyWeaponSelector_SelectedIndexChanged;
            // 
            // Form2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1212, 768);
            Controls.Add(cmb_EnemyWeaponSelector);
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
        private System.Windows.Forms.ComboBox cmb_EnemyWeaponSelector;
    }
}