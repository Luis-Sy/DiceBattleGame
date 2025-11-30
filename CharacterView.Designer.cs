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
            nameLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            nameLbl.Location = new Point(46, 9);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(64, 28);
            nameLbl.TabIndex = 0;
            nameLbl.Text = "name";
            // 
            // typeLbl
            // 
            typeLbl.AutoSize = true;
            typeLbl.Location = new Point(46, 41);
            typeLbl.Name = "typeLbl";
            typeLbl.Size = new Size(58, 20);
            typeLbl.TabIndex = 1;
            typeLbl.Text = "typeLbl";
            // 
            // levelLbl
            // 
            levelLbl.AutoSize = true;
            levelLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            levelLbl.Location = new Point(186, 33);
            levelLbl.Name = "levelLbl";
            levelLbl.Size = new Size(57, 28);
            levelLbl.TabIndex = 4;
            levelLbl.Text = "level";
            // 
            // healthLbl
            // 
            healthLbl.AutoSize = true;
            healthLbl.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            healthLbl.Location = new Point(318, 33);
            healthLbl.Name = "healthLbl";
            healthLbl.Size = new Size(72, 28);
            healthLbl.TabIndex = 5;
            healthLbl.Text = "health";
            // 
            // statBox
            // 
            statBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            statBox.FormattingEnabled = true;
            statBox.ItemHeight = 28;
            statBox.Location = new Point(46, 106);
            statBox.Name = "statBox";
            statBox.Size = new Size(266, 284);
            statBox.TabIndex = 6;
            // 
            // statGrowthBox
            // 
            statGrowthBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            statGrowthBox.FormattingEnabled = true;
            statGrowthBox.ItemHeight = 28;
            statGrowthBox.Location = new Point(318, 106);
            statGrowthBox.Name = "statGrowthBox";
            statGrowthBox.Size = new Size(242, 284);
            statGrowthBox.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(149, 67);
            label1.Name = "label1";
            label1.Size = new Size(59, 28);
            label1.TabIndex = 8;
            label1.Text = "Stats";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(347, 67);
            label2.Name = "label2";
            label2.Size = new Size(179, 28);
            label2.TabIndex = 9;
            label2.Text = "Growth Modifiers";
            // 
            // CharacterView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(608, 406);
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