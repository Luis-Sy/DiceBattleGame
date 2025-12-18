namespace DiceBattleGame.Forms_UI
{
    partial class MapForm
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
            btn_StartMenuForm = new Button();
            btn_Back = new Button();
            pic_Map = new PictureBox();
            btn_Continue = new Button();
            tbl_Stats = new TableLayoutPanel();
            lbl_BattleColor = new Label();
            lbl_ShopColor = new Label();
            lbl_RestColor = new Label();
            lbl_Strength = new Label();
            lbl_BossColor = new Label();
            lbl_Dexterity = new Label();
            lbl_Constitution = new Label();
            label1 = new Label();
            btn_PreviousNode = new Button();
            ((System.ComponentModel.ISupportInitialize)pic_Map).BeginInit();
            tbl_Stats.SuspendLayout();
            SuspendLayout();
            // 
            // btn_StartMenuForm
            // 
            btn_StartMenuForm.Location = new Point(22, 11);
            btn_StartMenuForm.Margin = new Padding(2);
            btn_StartMenuForm.Name = "btn_StartMenuForm";
            btn_StartMenuForm.Size = new Size(76, 20);
            btn_StartMenuForm.TabIndex = 4;
            btn_StartMenuForm.Text = "Start Menu";
            btn_StartMenuForm.UseVisualStyleBackColor = true;
            btn_StartMenuForm.Click += btn_StartMenuForm_Click;
            // 
            // btn_Back
            // 
            btn_Back.Location = new Point(137, 11);
            btn_Back.Margin = new Padding(2);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(76, 20);
            btn_Back.TabIndex = 5;
            btn_Back.Text = "Back";
            btn_Back.UseVisualStyleBackColor = true;
            btn_Back.Click += btn_Back_Click;
            // 
            // pic_Map
            // 
            pic_Map.BackColor = SystemColors.Info;
            pic_Map.BorderStyle = BorderStyle.FixedSingle;
            pic_Map.Location = new Point(40, 68);
            pic_Map.Margin = new Padding(2);
            pic_Map.Name = "pic_Map";
            pic_Map.Size = new Size(480, 156);
            pic_Map.TabIndex = 6;
            pic_Map.TabStop = false;
            pic_Map.Paint += pic_Map_Paint;
            // 
            // btn_Continue
            // 
            btn_Continue.Location = new Point(363, 261);
            btn_Continue.Margin = new Padding(2);
            btn_Continue.Name = "btn_Continue";
            btn_Continue.Size = new Size(76, 20);
            btn_Continue.TabIndex = 7;
            btn_Continue.Text = "Next Node";
            btn_Continue.UseVisualStyleBackColor = true;
            btn_Continue.Click += btn_Continue_Click;
            // 
            // tbl_Stats
            // 
            tbl_Stats.AutoSize = true;
            tbl_Stats.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tbl_Stats.ColumnCount = 2;
            tbl_Stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Stats.Controls.Add(lbl_BattleColor, 0, 0);
            tbl_Stats.Controls.Add(lbl_ShopColor, 0, 1);
            tbl_Stats.Controls.Add(lbl_RestColor, 0, 2);
            tbl_Stats.Controls.Add(lbl_Strength, 1, 2);
            tbl_Stats.Controls.Add(lbl_BossColor, 0, 3);
            tbl_Stats.Controls.Add(lbl_Dexterity, 1, 3);
            tbl_Stats.Controls.Add(lbl_Constitution, 1, 1);
            tbl_Stats.Controls.Add(label1, 1, 0);
            tbl_Stats.Location = new Point(687, 95);
            tbl_Stats.Margin = new Padding(2);
            tbl_Stats.Name = "tbl_Stats";
            tbl_Stats.RowCount = 4;
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666718F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.Size = new Size(127, 117);
            tbl_Stats.TabIndex = 9;
            tbl_Stats.TabStop = true;
            // 
            // lbl_BattleColor
            // 
            lbl_BattleColor.AutoSize = true;
            lbl_BattleColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_BattleColor.Location = new Point(3, 1);
            lbl_BattleColor.Margin = new Padding(2, 0, 2, 0);
            lbl_BattleColor.Name = "lbl_BattleColor";
            lbl_BattleColor.Size = new Size(41, 15);
            lbl_BattleColor.TabIndex = 0;
            lbl_BattleColor.Text = "Battle";
            lbl_BattleColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_ShopColor
            // 
            lbl_ShopColor.AutoSize = true;
            lbl_ShopColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ShopColor.Location = new Point(3, 30);
            lbl_ShopColor.Margin = new Padding(2, 0, 2, 0);
            lbl_ShopColor.Name = "lbl_ShopColor";
            lbl_ShopColor.Size = new Size(35, 15);
            lbl_ShopColor.TabIndex = 2;
            lbl_ShopColor.Text = "Shop";
            lbl_ShopColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_RestColor
            // 
            lbl_RestColor.AutoSize = true;
            lbl_RestColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_RestColor.Location = new Point(3, 59);
            lbl_RestColor.Margin = new Padding(2, 0, 2, 0);
            lbl_RestColor.Name = "lbl_RestColor";
            lbl_RestColor.Size = new Size(32, 15);
            lbl_RestColor.TabIndex = 4;
            lbl_RestColor.Text = "Rest";
            lbl_RestColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Strength
            // 
            lbl_Strength.AutoSize = true;
            lbl_Strength.BackColor = Color.FromArgb(192, 255, 255);
            lbl_Strength.ForeColor = Color.FromArgb(192, 255, 255);
            lbl_Strength.Location = new Point(66, 59);
            lbl_Strength.Margin = new Padding(2, 0, 2, 0);
            lbl_Strength.Name = "lbl_Strength";
            lbl_Strength.Size = new Size(57, 15);
            lbl_Strength.TabIndex = 5;
            lbl_Strength.Text = "LightBlue";
            lbl_Strength.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_BossColor
            // 
            lbl_BossColor.AutoSize = true;
            lbl_BossColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_BossColor.Location = new Point(3, 88);
            lbl_BossColor.Margin = new Padding(2, 0, 2, 0);
            lbl_BossColor.Name = "lbl_BossColor";
            lbl_BossColor.Size = new Size(32, 15);
            lbl_BossColor.TabIndex = 6;
            lbl_BossColor.Text = "Boss";
            lbl_BossColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Dexterity
            // 
            lbl_Dexterity.AutoSize = true;
            lbl_Dexterity.BackColor = Color.Maroon;
            lbl_Dexterity.BorderStyle = BorderStyle.FixedSingle;
            lbl_Dexterity.ForeColor = Color.Maroon;
            lbl_Dexterity.Location = new Point(66, 88);
            lbl_Dexterity.Margin = new Padding(2, 0, 2, 0);
            lbl_Dexterity.Name = "lbl_Dexterity";
            lbl_Dexterity.Size = new Size(56, 17);
            lbl_Dexterity.TabIndex = 7;
            lbl_Dexterity.Text = "Dexterity";
            lbl_Dexterity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Constitution
            // 
            lbl_Constitution.AutoSize = true;
            lbl_Constitution.BackColor = Color.FromArgb(255, 192, 255);
            lbl_Constitution.ForeColor = Color.FromArgb(255, 192, 255);
            lbl_Constitution.Location = new Point(66, 30);
            lbl_Constitution.Margin = new Padding(2, 0, 2, 0);
            lbl_Constitution.Name = "lbl_Constitution";
            lbl_Constitution.Size = new Size(57, 15);
            lbl_Constitution.TabIndex = 3;
            lbl_Constitution.Text = "LightPink";
            lbl_Constitution.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Silver;
            label1.ForeColor = Color.Silver;
            label1.Location = new Point(66, 1);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(58, 15);
            label1.TabIndex = 8;
            label1.Text = "LightGray";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_PreviousNode
            // 
            btn_PreviousNode.Location = new Point(82, 261);
            btn_PreviousNode.Margin = new Padding(2);
            btn_PreviousNode.Name = "btn_PreviousNode";
            btn_PreviousNode.Size = new Size(101, 20);
            btn_PreviousNode.TabIndex = 10;
            btn_PreviousNode.Text = "Previous Node";
            btn_PreviousNode.UseVisualStyleBackColor = true;
            btn_PreviousNode.Click += btn_PreviousNode_Click;
            // 
            // MapForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1016, 564);
            Controls.Add(btn_PreviousNode);
            Controls.Add(tbl_Stats);
            Controls.Add(btn_Continue);
            Controls.Add(pic_Map);
            Controls.Add(btn_Back);
            Controls.Add(btn_StartMenuForm);
            Margin = new Padding(2);
            Name = "MapForm";
            Text = "MapForm";
            ((System.ComponentModel.ISupportInitialize)pic_Map).EndInit();
            tbl_Stats.ResumeLayout(false);
            tbl_Stats.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_StartMenuForm;
        private Button btn_Back;
        private PictureBox pic_Map;
        private Button btn_Continue;
        public TableLayoutPanel tbl_Stats;
        private Label lbl_BattleColor;
        private Label lbl_ShopColor;
        private Label lbl_RestColor;
        private Label lbl_Strength;
        private Label lbl_BossColor;
        private Label lbl_Dexterity;
        private Label lbl_Constitution;
        private Label label1;
        private Button btn_PreviousNode;
    }
}