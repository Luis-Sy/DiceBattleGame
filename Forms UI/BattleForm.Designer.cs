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
            SuspendLayout();
            // 
            // lbl_PlayerName
            // 
            lbl_PlayerName.AutoSize = true;
            lbl_PlayerName.Location = new Point(78, 50);
            lbl_PlayerName.Name = "lbl_PlayerName";
            lbl_PlayerName.Size = new Size(47, 15);
            lbl_PlayerName.TabIndex = 0;
            lbl_PlayerName.Text = "Player \\";
            // 
            // lbl_EnemyPlayer
            // 
            lbl_EnemyPlayer.AutoSize = true;
            lbl_EnemyPlayer.Location = new Point(519, 47);
            lbl_EnemyPlayer.Name = "lbl_EnemyPlayer";
            lbl_EnemyPlayer.Size = new Size(43, 15);
            lbl_EnemyPlayer.TabIndex = 1;
            lbl_EnemyPlayer.Text = "Enemy";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(78, 79);
            label3.Name = "label3";
            label3.Size = new Size(77, 15);
            label3.TabIndex = 2;
            label3.Text = "Player Health";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(519, 79);
            label4.Name = "label4";
            label4.Size = new Size(81, 15);
            label4.TabIndex = 3;
            label4.Text = "Enemy Health";
            // 
            // statusBar1
            // 
            statusBar1.BackColor = SystemColors.ButtonShadow;
            statusBar1.Location = new Point(78, 105);
            statusBar1.Margin = new Padding(3, 2, 3, 2);
            statusBar1.MaximumSize = new Size(153, 16);
            statusBar1.Name = "statusBar1";
            statusBar1.Size = new Size(153, 16);
            statusBar1.TabIndex = 10;
            // 
            // statusBar2
            // 
            statusBar2.BackColor = SystemColors.ButtonShadow;
            statusBar2.Location = new Point(519, 105);
            statusBar2.Margin = new Padding(3, 2, 3, 2);
            statusBar2.MaximumSize = new Size(153, 16);
            statusBar2.Name = "statusBar2";
            statusBar2.Size = new Size(153, 16);
            statusBar2.TabIndex = 11;
            // 
            // txt_TextBox
            // 
            txt_TextBox.Location = new Point(152, 171);
            txt_TextBox.Margin = new Padding(2);
            txt_TextBox.Multiline = true;
            txt_TextBox.Name = "txt_TextBox";
            txt_TextBox.ScrollBars = ScrollBars.Vertical;
            txt_TextBox.Size = new Size(448, 178);
            txt_TextBox.TabIndex = 12;
            // 
            // btn_NextTurn
            // 
            btn_NextTurn.Location = new Point(524, 386);
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
            btn_BackMap.Location = new Point(151, 386);
            btn_BackMap.Name = "btn_BackMap";
            btn_BackMap.Size = new Size(93, 31);
            btn_BackMap.TabIndex = 14;
            btn_BackMap.Text = "Back to map";
            btn_BackMap.UseVisualStyleBackColor = true;
            btn_BackMap.Click += btn_BackMap_Click;
            // 
            // BattleForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_BackMap);
            Controls.Add(btn_NextTurn);
            Controls.Add(txt_TextBox);
            Controls.Add(statusBar2);
            Controls.Add(statusBar1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lbl_EnemyPlayer);
            Controls.Add(lbl_PlayerName);
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
    }
}