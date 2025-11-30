namespace DiceBattleGame
{
    partial class CharacterView
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
            nameLbl = new Label();
            typeLbl = new Label();
            levelLbl = new Label();
            healthLbl = new Label();
            statBox = new ListBox();
            statGrowthBox = new ListBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = true;
            nameLbl.Location = new Point(47, 59);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(46, 20);
            nameLbl.TabIndex = 0;
            nameLbl.Text = "name";
            // 
            // typeLbl
            // 
            typeLbl.AutoSize = true;
            typeLbl.Location = new Point(119, 59);
            typeLbl.Name = "typeLbl";
            typeLbl.Size = new Size(58, 20);
            typeLbl.TabIndex = 1;
            typeLbl.Text = "typeLbl";
            // 
            // levelLbl
            // 
            levelLbl.AutoSize = true;
            levelLbl.Location = new Point(202, 59);
            levelLbl.Name = "levelLbl";
            levelLbl.Size = new Size(40, 20);
            levelLbl.TabIndex = 4;
            levelLbl.Text = "level";
            // 
            // healthLbl
            // 
            healthLbl.AutoSize = true;
            healthLbl.Location = new Point(283, 59);
            healthLbl.Name = "healthLbl";
            healthLbl.Size = new Size(50, 20);
            healthLbl.TabIndex = 5;
            healthLbl.Text = "health";
            // 
            // statBox
            // 
            statBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            statBox.FormattingEnabled = true;
            statBox.ItemHeight = 28;
            statBox.Location = new Point(46, 135);
            statBox.Name = "statBox";
            statBox.Size = new Size(266, 284);
            statBox.TabIndex = 6;
            // 
            // statGrowthBox
            // 
            statGrowthBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            statGrowthBox.FormattingEnabled = true;
            statGrowthBox.ItemHeight = 28;
            statGrowthBox.Location = new Point(318, 135);
            statGrowthBox.Name = "statGrowthBox";
            statGrowthBox.Size = new Size(282, 284);
            statGrowthBox.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(142, 103);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 8;
            label1.Text = "Stats";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(384, 103);
            label2.Name = "label2";
            label2.Size = new Size(124, 20);
            label2.TabIndex = 9;
            label2.Text = "Growth Modifiers";
            // 
            // CharacterView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 449);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(statGrowthBox);
            Controls.Add(statBox);
            Controls.Add(healthLbl);
            Controls.Add(levelLbl);
            Controls.Add(typeLbl);
            Controls.Add(nameLbl);
            Name = "CharacterView";
            Text = "CharacterView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label nameLbl;
        private Label typeLbl;
        private Label levelLbl;
        private Label healthLbl;
        private ListBox statBox;
        private ListBox statGrowthBox;
        private Label label1;
        private Label label2;
    }
}