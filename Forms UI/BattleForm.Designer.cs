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
            lbl_PlayerName = new Label();
            lbl_EnemyPlayer = new Label();
            label3 = new Label();
            label4 = new Label();
            statusBar1 = new StatusBar();
            statusBar2 = new StatusBar();
            txt_TextBox = new TextBox();
            btn_NextTurn = new Button();
            btn_BackMap = new Button();
            PlayerHealtNumber = new Label();
            EnemyHealtNumber = new Label();
            SuspendLayout();
            // 
            // lbl_PlayerName
            // 
            lbl_PlayerName.AutoSize = true;
            lbl_PlayerName.Location = new Point(134, 100);
            lbl_PlayerName.Margin = new Padding(5, 0, 5, 0);
            lbl_PlayerName.Name = "lbl_PlayerName";
            lbl_PlayerName.Size = new Size(83, 30);
            lbl_PlayerName.TabIndex = 0;
            lbl_PlayerName.Text = "Player \\";
            // 
            // lbl_EnemyPlayer
            // 
            lbl_EnemyPlayer.AutoSize = true;
            lbl_EnemyPlayer.Location = new Point(890, 94);
            lbl_EnemyPlayer.Margin = new Padding(5, 0, 5, 0);
            lbl_EnemyPlayer.Name = "lbl_EnemyPlayer";
            lbl_EnemyPlayer.Size = new Size(75, 30);
            lbl_EnemyPlayer.TabIndex = 1;
            lbl_EnemyPlayer.Text = "Enemy";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(134, 158);
            label3.Margin = new Padding(5, 0, 5, 0);
            label3.Name = "label3";
            label3.Size = new Size(136, 30);
            label3.TabIndex = 2;
            label3.Text = "Player Health";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(890, 158);
            label4.Margin = new Padding(5, 0, 5, 0);
            label4.Name = "label4";
            label4.Size = new Size(142, 30);
            label4.TabIndex = 3;
            label4.Text = "Enemy Health";
            // 
            // statusBar1
            // 
            statusBar1.BackColor = SystemColors.ButtonShadow;
            statusBar1.Location = new Point(134, 210);
            statusBar1.Margin = new Padding(5, 4, 5, 4);
            statusBar1.MaximumSize = new Size(262, 32);
            statusBar1.Name = "statusBar1";
            statusBar1.Size = new Size(262, 32);
            statusBar1.TabIndex = 10;
            // 
            // statusBar2
            // 
            statusBar2.BackColor = SystemColors.ButtonShadow;
            statusBar2.Location = new Point(890, 210);
            statusBar2.Margin = new Padding(5, 4, 5, 4);
            statusBar2.MaximumSize = new Size(262, 32);
            statusBar2.Name = "statusBar2";
            statusBar2.Size = new Size(262, 32);
            statusBar2.TabIndex = 11;
            // 
            // txt_TextBox
            // 
            txt_TextBox.Location = new Point(261, 342);
            txt_TextBox.Margin = new Padding(3, 4, 3, 4);
            txt_TextBox.Multiline = true;
            txt_TextBox.Name = "txt_TextBox";
            txt_TextBox.ScrollBars = ScrollBars.Vertical;
            txt_TextBox.Size = new Size(765, 352);
            txt_TextBox.TabIndex = 12;
            // 
            // btn_NextTurn
            // 
            btn_NextTurn.Location = new Point(898, 772);
            btn_NextTurn.Margin = new Padding(3, 4, 3, 4);
            btn_NextTurn.Name = "btn_NextTurn";
            btn_NextTurn.Size = new Size(130, 62);
            btn_NextTurn.TabIndex = 13;
            btn_NextTurn.Text = "Next turn";
            btn_NextTurn.UseVisualStyleBackColor = true;
            btn_NextTurn.Click += btn_NextTurn_Click;
            // 
            // btn_BackMap
            // 
            btn_BackMap.Location = new Point(259, 772);
            btn_BackMap.Margin = new Padding(5, 6, 5, 6);
            btn_BackMap.Name = "btn_BackMap";
            btn_BackMap.Size = new Size(159, 62);
            btn_BackMap.TabIndex = 14;
            btn_BackMap.Text = "Back to map";
            btn_BackMap.UseVisualStyleBackColor = true;
            btn_BackMap.Click += btn_BackMap_Click;
            // 
            // PlayerHealtNumber
            // 
            PlayerHealtNumber.AutoSize = true;
            PlayerHealtNumber.Location = new Point(134, 259);
            PlayerHealtNumber.Name = "PlayerHealtNumber";
            PlayerHealtNumber.Size = new Size(130, 30);
            PlayerHealtNumber.TabIndex = 15;
            PlayerHealtNumber.Text = "PlayerHealth";
            // 
            // EnemyHealtNumber
            // 
            EnemyHealtNumber.AutoSize = true;
            EnemyHealtNumber.Location = new Point(890, 259);
            EnemyHealtNumber.Name = "EnemyHealtNumber";
            EnemyHealtNumber.Size = new Size(136, 30);
            EnemyHealtNumber.TabIndex = 16;
            EnemyHealtNumber.Text = "EnemyHealth";
            // 
            // BattleForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1371, 900);
            Controls.Add(EnemyHealtNumber);
            Controls.Add(PlayerHealtNumber);
            Controls.Add(btn_BackMap);
            Controls.Add(btn_NextTurn);
            Controls.Add(txt_TextBox);
            Controls.Add(statusBar2);
            Controls.Add(statusBar1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lbl_EnemyPlayer);
            Controls.Add(lbl_PlayerName);
            Margin = new Padding(5, 6, 5, 6);
            Name = "BattleForm";
            Text = "BattleForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_PlayerName;
        private Label lbl_EnemyPlayer;
        private Label label3;
        private Label label4;
        private StatusBar statusBar1;
        private StatusBar statusBar2;
        private TextBox txt_TextBox;
        private Button btn_NextTurn;
        private Button btn_BackMap;
        private Label PlayerHealtNumber;
        private Label EnemyHealtNumber;
    }
}