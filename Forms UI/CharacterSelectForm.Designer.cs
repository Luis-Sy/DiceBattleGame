namespace DiceBattleGame
{
    partial class CharacterSelectForm
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
            pic_charactherPortrait = new PictureBox();
            btn_StartMenuForm = new Button();
            lbl_characterName = new Label();
            label1 = new Label();
            cmb_PlayerSelector = new ComboBox();
            btn_Next = new Button();
            tbl_Stats = new TableLayoutPanel();
            lbl_Vigor = new Label();
            lbl_VigorTitle = new Label();
            lbl_ConstitutionTitle = new Label();
            lbl_Constitution = new Label();
            lbl_StrengthTitle = new Label();
            lbl_Strength = new Label();
            lbl_DexterityTitle = new Label();
            lbl_Dexterity = new Label();
            lbl_IntellectTitle = new Label();
            lbl_Intellect = new Label();
            lbl_FaithTitle = new Label();
            lbl_Faith = new Label();
            seedTextBox = new TextBox();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pic_charactherPortrait).BeginInit();
            tbl_Stats.SuspendLayout();
            SuspendLayout();
            // 
            // pic_charactherPortrait
            // 
            pic_charactherPortrait.BorderStyle = BorderStyle.FixedSingle;
            pic_charactherPortrait.Location = new Point(75, 112);
            pic_charactherPortrait.Margin = new Padding(2);
            pic_charactherPortrait.Name = "pic_charactherPortrait";
            pic_charactherPortrait.Size = new Size(201, 201);
            pic_charactherPortrait.SizeMode = PictureBoxSizeMode.Zoom;
            pic_charactherPortrait.TabIndex = 0;
            pic_charactherPortrait.TabStop = false;
            // 
            // btn_StartMenuForm
            // 
            btn_StartMenuForm.Location = new Point(27, 20);
            btn_StartMenuForm.Margin = new Padding(2);
            btn_StartMenuForm.Name = "btn_StartMenuForm";
            btn_StartMenuForm.Size = new Size(115, 27);
            btn_StartMenuForm.TabIndex = 3;
            btn_StartMenuForm.Text = "Start Menu";
            btn_StartMenuForm.UseVisualStyleBackColor = true;
            btn_StartMenuForm.Click += btn_StartMenuForm_Click;
            // 
            // lbl_characterName
            // 
            lbl_characterName.AutoSize = true;
            lbl_characterName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_characterName.Location = new Point(95, 73);
            lbl_characterName.Margin = new Padding(2, 0, 2, 0);
            lbl_characterName.Name = "lbl_characterName";
            lbl_characterName.Size = new Size(117, 20);
            lbl_characterName.TabIndex = 4;
            lbl_characterName.Text = "character name";
            lbl_characterName.Click += lbl_characterName_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(339, 73);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(155, 20);
            label1.TabIndex = 5;
            label1.Text = "Select your character";
            // 
            // cmb_PlayerSelector
            // 
            cmb_PlayerSelector.FormattingEnabled = true;
            cmb_PlayerSelector.Location = new Point(339, 112);
            cmb_PlayerSelector.Margin = new Padding(2);
            cmb_PlayerSelector.Name = "cmb_PlayerSelector";
            cmb_PlayerSelector.Size = new Size(143, 28);
            cmb_PlayerSelector.TabIndex = 6;
            // 
            // btn_Next
            // 
            btn_Next.Location = new Point(408, 367);
            btn_Next.Margin = new Padding(2);
            btn_Next.Name = "btn_Next";
            btn_Next.Size = new Size(87, 27);
            btn_Next.TabIndex = 7;
            btn_Next.Text = "Next";
            btn_Next.UseVisualStyleBackColor = true;
            btn_Next.Click += btn_Next_Click;
            // 
            // tbl_Stats
            // 
            tbl_Stats.AutoSize = true;
            tbl_Stats.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tbl_Stats.ColumnCount = 2;
            tbl_Stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Stats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Stats.Controls.Add(lbl_Vigor, 1, 0);
            tbl_Stats.Controls.Add(lbl_VigorTitle, 0, 0);
            tbl_Stats.Controls.Add(lbl_ConstitutionTitle, 0, 1);
            tbl_Stats.Controls.Add(lbl_Constitution, 1, 1);
            tbl_Stats.Controls.Add(lbl_StrengthTitle, 0, 2);
            tbl_Stats.Controls.Add(lbl_Strength, 1, 2);
            tbl_Stats.Controls.Add(lbl_DexterityTitle, 0, 3);
            tbl_Stats.Controls.Add(lbl_Dexterity, 1, 3);
            tbl_Stats.Controls.Add(lbl_IntellectTitle, 0, 4);
            tbl_Stats.Controls.Add(lbl_Intellect, 1, 4);
            tbl_Stats.Controls.Add(lbl_FaithTitle, 0, 5);
            tbl_Stats.Controls.Add(lbl_Faith, 1, 5);
            tbl_Stats.Location = new Point(339, 156);
            tbl_Stats.Margin = new Padding(2);
            tbl_Stats.Name = "tbl_Stats";
            tbl_Stats.RowCount = 6;
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666718F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.Size = new Size(233, 156);
            tbl_Stats.TabIndex = 8;
            tbl_Stats.TabStop = true;
            tbl_Stats.Paint += tbl_Stats_Paint;
            // 
            // lbl_Vigor
            // 
            lbl_Vigor.AutoSize = true;
            lbl_Vigor.Location = new Point(119, 1);
            lbl_Vigor.Margin = new Padding(2, 0, 2, 0);
            lbl_Vigor.Name = "lbl_Vigor";
            lbl_Vigor.Size = new Size(45, 20);
            lbl_Vigor.TabIndex = 1;
            lbl_Vigor.Text = "Vigor";
            lbl_Vigor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_VigorTitle
            // 
            lbl_VigorTitle.AutoSize = true;
            lbl_VigorTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_VigorTitle.Location = new Point(3, 1);
            lbl_VigorTitle.Margin = new Padding(2, 0, 2, 0);
            lbl_VigorTitle.Name = "lbl_VigorTitle";
            lbl_VigorTitle.Size = new Size(52, 20);
            lbl_VigorTitle.TabIndex = 0;
            lbl_VigorTitle.Text = "Vigor:";
            lbl_VigorTitle.TextAlign = ContentAlignment.MiddleLeft;
            lbl_VigorTitle.Click += label2_Click;
            // 
            // lbl_ConstitutionTitle
            // 
            lbl_ConstitutionTitle.AutoSize = true;
            lbl_ConstitutionTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ConstitutionTitle.Location = new Point(3, 26);
            lbl_ConstitutionTitle.Margin = new Padding(2, 0, 2, 0);
            lbl_ConstitutionTitle.Name = "lbl_ConstitutionTitle";
            lbl_ConstitutionTitle.Size = new Size(100, 20);
            lbl_ConstitutionTitle.TabIndex = 2;
            lbl_ConstitutionTitle.Text = "Constitution:";
            lbl_ConstitutionTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Constitution
            // 
            lbl_Constitution.AutoSize = true;
            lbl_Constitution.Location = new Point(119, 26);
            lbl_Constitution.Margin = new Padding(2, 0, 2, 0);
            lbl_Constitution.Name = "lbl_Constitution";
            lbl_Constitution.Size = new Size(89, 20);
            lbl_Constitution.TabIndex = 3;
            lbl_Constitution.Text = "Constitution";
            lbl_Constitution.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_StrengthTitle
            // 
            lbl_StrengthTitle.AutoSize = true;
            lbl_StrengthTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_StrengthTitle.Location = new Point(3, 51);
            lbl_StrengthTitle.Margin = new Padding(2, 0, 2, 0);
            lbl_StrengthTitle.Name = "lbl_StrengthTitle";
            lbl_StrengthTitle.Size = new Size(74, 20);
            lbl_StrengthTitle.TabIndex = 4;
            lbl_StrengthTitle.Text = "Strength:";
            lbl_StrengthTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Strength
            // 
            lbl_Strength.AutoSize = true;
            lbl_Strength.Location = new Point(119, 51);
            lbl_Strength.Margin = new Padding(2, 0, 2, 0);
            lbl_Strength.Name = "lbl_Strength";
            lbl_Strength.Size = new Size(65, 20);
            lbl_Strength.TabIndex = 5;
            lbl_Strength.Text = "Strength";
            lbl_Strength.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_DexterityTitle
            // 
            lbl_DexterityTitle.AutoSize = true;
            lbl_DexterityTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_DexterityTitle.Location = new Point(3, 76);
            lbl_DexterityTitle.Margin = new Padding(2, 0, 2, 0);
            lbl_DexterityTitle.Name = "lbl_DexterityTitle";
            lbl_DexterityTitle.Size = new Size(78, 20);
            lbl_DexterityTitle.TabIndex = 6;
            lbl_DexterityTitle.Text = "Dexterity:";
            lbl_DexterityTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Dexterity
            // 
            lbl_Dexterity.AutoSize = true;
            lbl_Dexterity.Location = new Point(119, 76);
            lbl_Dexterity.Margin = new Padding(2, 0, 2, 0);
            lbl_Dexterity.Name = "lbl_Dexterity";
            lbl_Dexterity.Size = new Size(69, 20);
            lbl_Dexterity.TabIndex = 7;
            lbl_Dexterity.Text = "Dexterity";
            lbl_Dexterity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_IntellectTitle
            // 
            lbl_IntellectTitle.AutoSize = true;
            lbl_IntellectTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_IntellectTitle.Location = new Point(3, 101);
            lbl_IntellectTitle.Margin = new Padding(2, 0, 2, 0);
            lbl_IntellectTitle.Name = "lbl_IntellectTitle";
            lbl_IntellectTitle.Size = new Size(70, 20);
            lbl_IntellectTitle.TabIndex = 8;
            lbl_IntellectTitle.Text = "Intellect:";
            lbl_IntellectTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Intellect
            // 
            lbl_Intellect.AutoSize = true;
            lbl_Intellect.Location = new Point(119, 101);
            lbl_Intellect.Margin = new Padding(2, 0, 2, 0);
            lbl_Intellect.Name = "lbl_Intellect";
            lbl_Intellect.Size = new Size(62, 20);
            lbl_Intellect.TabIndex = 9;
            lbl_Intellect.Text = "Intellect";
            lbl_Intellect.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_FaithTitle
            // 
            lbl_FaithTitle.AutoSize = true;
            lbl_FaithTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_FaithTitle.Location = new Point(3, 126);
            lbl_FaithTitle.Margin = new Padding(2, 0, 2, 0);
            lbl_FaithTitle.Name = "lbl_FaithTitle";
            lbl_FaithTitle.Size = new Size(48, 20);
            lbl_FaithTitle.TabIndex = 10;
            lbl_FaithTitle.Text = "Faith:";
            lbl_FaithTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Faith
            // 
            lbl_Faith.AutoSize = true;
            lbl_Faith.Location = new Point(119, 126);
            lbl_Faith.Margin = new Padding(2, 0, 2, 0);
            lbl_Faith.Name = "lbl_Faith";
            lbl_Faith.Size = new Size(40, 20);
            lbl_Faith.TabIndex = 11;
            lbl_Faith.Text = "Faith";
            lbl_Faith.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // seedTextBox
            // 
            seedTextBox.Location = new Point(152, 367);
            seedTextBox.MaxLength = 16;
            seedTextBox.Name = "seedTextBox";
            seedTextBox.PlaceholderText = "Leave blank for a random seed";
            seedTextBox.Size = new Size(238, 27);
            seedTextBox.TabIndex = 9;
            seedTextBox.KeyPress += seedTextBox_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(96, 370);
            label2.Name = "label2";
            label2.Size = new Size(45, 20);
            label2.TabIndex = 10;
            label2.Text = "Seed:";
            // 
            // CharacterSelectForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(655, 449);
            Controls.Add(label2);
            Controls.Add(seedTextBox);
            Controls.Add(tbl_Stats);
            Controls.Add(btn_Next);
            Controls.Add(cmb_PlayerSelector);
            Controls.Add(label1);
            Controls.Add(lbl_characterName);
            Controls.Add(btn_StartMenuForm);
            Controls.Add(pic_charactherPortrait);
            Margin = new Padding(2);
            Name = "CharacterSelectForm";
            Text = "CharacterSelectForm";
            ((System.ComponentModel.ISupportInitialize)pic_charactherPortrait).EndInit();
            tbl_Stats.ResumeLayout(false);
            tbl_Stats.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pic_charactherPortrait;
        private Button btn_StartMenuForm;
        private Label lbl_characterName;
        private Label label1;
        private ComboBox cmb_PlayerSelector;
        private Button btn_Next;
        private Label lbl_VigorTitle;
        private Label lbl_Vigor;
        public TableLayoutPanel tbl_Stats;
        private Label lbl_ConstitutionTitle;
        private Label lbl_Constitution;
        private Label lbl_StrengthTitle;
        private Label lbl_Strength;
        private Label lbl_DexterityTitle;
        private Label lbl_Dexterity;
        private Label lbl_IntellectTitle;
        private Label lbl_Intellect;
        private Label lbl_FaithTitle;
        private Label lbl_Faith;
        private TextBox seedTextBox;
        private Label label2;
    }
}