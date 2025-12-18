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
            label5 = new Label();
            label4 = new Label();
            label2 = new Label();
            lbl_BattleColor = new Label();
            lbl_ShopColor = new Label();
            lbl_RestColor = new Label();
            lbl_Strength = new Label();
            lbl_BossColor = new Label();
            lbl_Dexterity = new Label();
            lbl_Constitution = new Label();
            label3 = new Label();
            label1 = new Label();
            btn_PreviousNode = new Button();
            lbl_Gold = new Label();
            ((System.ComponentModel.ISupportInitialize)pic_Map).BeginInit();
            tbl_Stats.SuspendLayout();
            SuspendLayout();
            // 
            // btn_StartMenuForm
            // 
            btn_StartMenuForm.Location = new Point(25, 15);
            btn_StartMenuForm.Margin = new Padding(2, 3, 2, 3);
            btn_StartMenuForm.Name = "btn_StartMenuForm";
            btn_StartMenuForm.Size = new Size(87, 27);
            btn_StartMenuForm.TabIndex = 4;
            btn_StartMenuForm.Text = "Start Menu";
            btn_StartMenuForm.UseVisualStyleBackColor = true;
            btn_StartMenuForm.Click += btn_StartMenuForm_Click;
            // 
            // btn_Back
            // 
            btn_Back.Location = new Point(157, 15);
            btn_Back.Margin = new Padding(2, 3, 2, 3);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(87, 27);
            btn_Back.TabIndex = 5;
            btn_Back.Text = "Back";
            btn_Back.UseVisualStyleBackColor = true;
            btn_Back.Click += btn_Back_Click;
            // 
            // pic_Map
            // 
            pic_Map.BackColor = SystemColors.Info;
            pic_Map.BorderStyle = BorderStyle.FixedSingle;
            pic_Map.Location = new Point(46, 91);
            pic_Map.Margin = new Padding(2, 3, 2, 3);
            pic_Map.Name = "pic_Map";
            pic_Map.Size = new Size(548, 207);
            pic_Map.TabIndex = 6;
            pic_Map.TabStop = false;
            pic_Map.Paint += pic_Map_Paint;
            // 
            // btn_Continue
            // 
            btn_Continue.Location = new Point(415, 348);
            btn_Continue.Margin = new Padding(2, 3, 2, 3);
            btn_Continue.Name = "btn_Continue";
            btn_Continue.Size = new Size(87, 27);
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
            tbl_Stats.Controls.Add(label5, 1, 5);
            tbl_Stats.Controls.Add(label4, 0, 5);
            tbl_Stats.Controls.Add(label2, 0, 4);
            tbl_Stats.Controls.Add(lbl_BattleColor, 0, 0);
            tbl_Stats.Controls.Add(lbl_ShopColor, 0, 1);
            tbl_Stats.Controls.Add(lbl_RestColor, 0, 2);
            tbl_Stats.Controls.Add(lbl_Strength, 1, 2);
            tbl_Stats.Controls.Add(lbl_BossColor, 0, 3);
            tbl_Stats.Controls.Add(lbl_Dexterity, 1, 3);
            tbl_Stats.Controls.Add(lbl_Constitution, 1, 1);
            tbl_Stats.Controls.Add(label3, 1, 4);
            tbl_Stats.Controls.Add(label1, 1, 0);
            tbl_Stats.Location = new Point(625, 108);
            tbl_Stats.Margin = new Padding(2, 3, 2, 3);
            tbl_Stats.Name = "tbl_Stats";
            tbl_Stats.RowCount = 6;
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666718F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tbl_Stats.Size = new Size(275, 135);
            tbl_Stats.TabIndex = 9;
            tbl_Stats.TabStop = true;
            tbl_Stats.Paint += tbl_Stats_Paint;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.LightGray;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = Color.LightGray;
            label5.Location = new Point(140, 114);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(130, 20);
            label5.TabIndex = 12;
            label5.Text = "DontLookHereOk";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(3, 114);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 11;
            label4.Text = "Rest";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(3, 93);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(44, 20);
            label2.TabIndex = 9;
            label2.Text = "Shop";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_BattleColor
            // 
            lbl_BattleColor.AutoSize = true;
            lbl_BattleColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_BattleColor.Location = new Point(3, 1);
            lbl_BattleColor.Margin = new Padding(2, 0, 2, 0);
            lbl_BattleColor.Name = "lbl_BattleColor";
            lbl_BattleColor.Size = new Size(51, 20);
            lbl_BattleColor.TabIndex = 0;
            lbl_BattleColor.Text = "Battle";
            lbl_BattleColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_ShopColor
            // 
            lbl_ShopColor.AutoSize = true;
            lbl_ShopColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ShopColor.Location = new Point(3, 24);
            lbl_ShopColor.Margin = new Padding(2, 0, 2, 0);
            lbl_ShopColor.Name = "lbl_ShopColor";
            lbl_ShopColor.Size = new Size(85, 20);
            lbl_ShopColor.TabIndex = 2;
            lbl_ShopColor.Text = "Elite Battle";
            lbl_ShopColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_RestColor
            // 
            lbl_RestColor.AutoSize = true;
            lbl_RestColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_RestColor.Location = new Point(3, 47);
            lbl_RestColor.Margin = new Padding(2, 0, 2, 0);
            lbl_RestColor.Name = "lbl_RestColor";
            lbl_RestColor.Size = new Size(40, 20);
            lbl_RestColor.TabIndex = 4;
            lbl_RestColor.Text = "Rest";
            lbl_RestColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Strength
            // 
            lbl_Strength.AutoSize = true;
            lbl_Strength.BackColor = Color.FromArgb(192, 255, 255);
            lbl_Strength.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Strength.ForeColor = Color.FromArgb(192, 255, 255);
            lbl_Strength.Location = new Point(140, 47);
            lbl_Strength.Margin = new Padding(2, 0, 2, 0);
            lbl_Strength.Name = "lbl_Strength";
            lbl_Strength.Size = new Size(130, 20);
            lbl_Strength.TabIndex = 5;
            lbl_Strength.Text = "DontLookHereOk";
            lbl_Strength.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_BossColor
            // 
            lbl_BossColor.AutoSize = true;
            lbl_BossColor.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_BossColor.Location = new Point(3, 70);
            lbl_BossColor.Margin = new Padding(2, 0, 2, 0);
            lbl_BossColor.Name = "lbl_BossColor";
            lbl_BossColor.Size = new Size(42, 20);
            lbl_BossColor.TabIndex = 6;
            lbl_BossColor.Text = "Boss";
            lbl_BossColor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Dexterity
            // 
            lbl_Dexterity.AutoSize = true;
            lbl_Dexterity.BackColor = Color.Purple;
            lbl_Dexterity.BorderStyle = BorderStyle.FixedSingle;
            lbl_Dexterity.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Dexterity.ForeColor = Color.Purple;
            lbl_Dexterity.Location = new Point(140, 70);
            lbl_Dexterity.Margin = new Padding(2, 0, 2, 0);
            lbl_Dexterity.Name = "lbl_Dexterity";
            lbl_Dexterity.Size = new Size(132, 22);
            lbl_Dexterity.TabIndex = 7;
            lbl_Dexterity.Text = "DontLookHereOk";
            lbl_Dexterity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_Constitution
            // 
            lbl_Constitution.AutoSize = true;
            lbl_Constitution.BackColor = Color.DarkRed;
            lbl_Constitution.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Constitution.ForeColor = Color.DarkRed;
            lbl_Constitution.Location = new Point(140, 24);
            lbl_Constitution.Margin = new Padding(2, 0, 2, 0);
            lbl_Constitution.Name = "lbl_Constitution";
            lbl_Constitution.Size = new Size(130, 20);
            lbl_Constitution.TabIndex = 3;
            lbl_Constitution.Text = "DontLookHereOk";
            lbl_Constitution.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.LightGreen;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.LightGreen;
            label3.Location = new Point(140, 93);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(130, 20);
            label3.TabIndex = 10;
            label3.Text = "DontLookHereOk";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Orange;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Orange;
            label1.Location = new Point(140, 1);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(130, 20);
            label1.TabIndex = 8;
            label1.Text = "DontLookHereOk";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_PreviousNode
            // 
            btn_PreviousNode.Location = new Point(94, 348);
            btn_PreviousNode.Margin = new Padding(2, 3, 2, 3);
            btn_PreviousNode.Name = "btn_PreviousNode";
            btn_PreviousNode.Size = new Size(115, 27);
            btn_PreviousNode.TabIndex = 10;
            btn_PreviousNode.Text = "Previous Node";
            btn_PreviousNode.UseVisualStyleBackColor = true;
            btn_PreviousNode.Click += btn_PreviousNode_Click;
            // 
            // lbl_Gold
            // 
            lbl_Gold.AutoSize = true;
            lbl_Gold.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Gold.Location = new Point(298, 15);
            lbl_Gold.Name = "lbl_Gold";
            lbl_Gold.Size = new Size(93, 41);
            lbl_Gold.TabIndex = 11;
            lbl_Gold.Text = "Gold:";
            // 
            // MapForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 752);
            Controls.Add(lbl_Gold);
            Controls.Add(btn_PreviousNode);
            Controls.Add(tbl_Stats);
            Controls.Add(btn_Continue);
            Controls.Add(pic_Map);
            Controls.Add(btn_Back);
            Controls.Add(btn_StartMenuForm);
            Margin = new Padding(2, 3, 2, 3);
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
        private Label label5;
        private Label label4;
        private Label label2;
        private Label label3;
        private Label lbl_Gold;
    }
}