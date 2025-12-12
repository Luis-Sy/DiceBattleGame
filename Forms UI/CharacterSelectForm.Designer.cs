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
            ((System.ComponentModel.ISupportInitialize)pic_charactherPortrait).BeginInit();
            tbl_Stats.SuspendLayout();
            SuspendLayout();
            // 
            // pic_charactherPortrait
            // 
            pic_charactherPortrait.BorderStyle = BorderStyle.FixedSingle;
            pic_charactherPortrait.Location = new Point(112, 168);
            pic_charactherPortrait.Name = "pic_charactherPortrait";
            pic_charactherPortrait.Size = new Size(300, 300);
            pic_charactherPortrait.SizeMode = PictureBoxSizeMode.Zoom;
            pic_charactherPortrait.TabIndex = 0;
            pic_charactherPortrait.TabStop = false;
            // 
            // btn_StartMenuForm
            // 
            btn_StartMenuForm.Location = new Point(40, 30);
            btn_StartMenuForm.Name = "btn_StartMenuForm";
            btn_StartMenuForm.Size = new Size(131, 40);
            btn_StartMenuForm.TabIndex = 3;
            btn_StartMenuForm.Text = "Start Menu";
            btn_StartMenuForm.UseVisualStyleBackColor = true;
            btn_StartMenuForm.Click += btn_StartMenuForm_Click;
            // 
            // lbl_characterName
            // 
            lbl_characterName.AutoSize = true;
            lbl_characterName.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_characterName.Location = new Point(142, 109);
            lbl_characterName.Name = "lbl_characterName";
            lbl_characterName.Size = new Size(163, 30);
            lbl_characterName.TabIndex = 4;
            lbl_characterName.Text = "character name";
            lbl_characterName.Click += lbl_characterName_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(508, 109);
            label1.Name = "label1";
            label1.Size = new Size(218, 30);
            label1.TabIndex = 5;
            label1.Text = "Select your character";
            // 
            // cmb_PlayerSelector
            // 
            cmb_PlayerSelector.FormattingEnabled = true;
            cmb_PlayerSelector.Location = new Point(508, 168);
            cmb_PlayerSelector.Name = "cmb_PlayerSelector";
            cmb_PlayerSelector.Size = new Size(212, 38);
            cmb_PlayerSelector.TabIndex = 6;
            // 
            // btn_Next
            // 
            btn_Next.Location = new Point(612, 550);
            btn_Next.Name = "btn_Next";
            btn_Next.Size = new Size(131, 40);
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
            tbl_Stats.Location = new Point(508, 234);
            tbl_Stats.Name = "tbl_Stats";
            tbl_Stats.RowCount = 6;
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666718F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6666679F));
            tbl_Stats.Size = new Size(350, 234);
            tbl_Stats.TabIndex = 8;
            tbl_Stats.TabStop = true;
            tbl_Stats.Paint += tbl_Stats_Paint;
            // 
            // lbl_Vigor
            // 
            lbl_Vigor.AutoSize = true;
            lbl_Vigor.Location = new Point(178, 1);
            lbl_Vigor.Name = "lbl_Vigor";
            lbl_Vigor.Size = new Size(62, 30);
            lbl_Vigor.TabIndex = 1;
            lbl_Vigor.Text = "Vigor";
            lbl_Vigor.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_VigorTitle
            // 
            lbl_VigorTitle.AutoSize = true;
            lbl_VigorTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_VigorTitle.Location = new Point(4, 1);
            lbl_VigorTitle.Name = "lbl_VigorTitle";
            lbl_VigorTitle.Size = new Size(74, 30);
            lbl_VigorTitle.TabIndex = 0;
            lbl_VigorTitle.Text = "Vigor:";
            lbl_VigorTitle.TextAlign = ContentAlignment.MiddleLeft;
            lbl_VigorTitle.Click += label2_Click;
            // 
            // lbl_ConstitutionTitle
            // 
            lbl_ConstitutionTitle.AutoSize = true;
            lbl_ConstitutionTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ConstitutionTitle.Location = new Point(4, 39);
            lbl_ConstitutionTitle.Name = "lbl_ConstitutionTitle";
            lbl_ConstitutionTitle.Size = new Size(142, 30);
            lbl_ConstitutionTitle.TabIndex = 2;
            lbl_ConstitutionTitle.Text = "Constitution:";
            lbl_ConstitutionTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Constitution
            // 
            lbl_Constitution.AutoSize = true;
            lbl_Constitution.Location = new Point(178, 39);
            lbl_Constitution.Name = "lbl_Constitution";
            lbl_Constitution.Size = new Size(126, 30);
            lbl_Constitution.TabIndex = 3;
            lbl_Constitution.Text = "Constitution";
            lbl_Constitution.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_StrengthTitle
            // 
            lbl_StrengthTitle.AutoSize = true;
            lbl_StrengthTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_StrengthTitle.Location = new Point(4, 77);
            lbl_StrengthTitle.Name = "lbl_StrengthTitle";
            lbl_StrengthTitle.Size = new Size(104, 30);
            lbl_StrengthTitle.TabIndex = 4;
            lbl_StrengthTitle.Text = "Strength:";
            lbl_StrengthTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Strength
            // 
            lbl_Strength.AutoSize = true;
            lbl_Strength.Location = new Point(178, 77);
            lbl_Strength.Name = "lbl_Strength";
            lbl_Strength.Size = new Size(91, 30);
            lbl_Strength.TabIndex = 5;
            lbl_Strength.Text = "Strength";
            lbl_Strength.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_DexterityTitle
            // 
            lbl_DexterityTitle.AutoSize = true;
            lbl_DexterityTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_DexterityTitle.Location = new Point(4, 115);
            lbl_DexterityTitle.Name = "lbl_DexterityTitle";
            lbl_DexterityTitle.Size = new Size(109, 30);
            lbl_DexterityTitle.TabIndex = 6;
            lbl_DexterityTitle.Text = "Dexterity:";
            lbl_DexterityTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Dexterity
            // 
            lbl_Dexterity.AutoSize = true;
            lbl_Dexterity.Location = new Point(178, 115);
            lbl_Dexterity.Name = "lbl_Dexterity";
            lbl_Dexterity.Size = new Size(96, 30);
            lbl_Dexterity.TabIndex = 7;
            lbl_Dexterity.Text = "Dexterity";
            lbl_Dexterity.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_IntellectTitle
            // 
            lbl_IntellectTitle.AutoSize = true;
            lbl_IntellectTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_IntellectTitle.Location = new Point(4, 153);
            lbl_IntellectTitle.Name = "lbl_IntellectTitle";
            lbl_IntellectTitle.Size = new Size(99, 30);
            lbl_IntellectTitle.TabIndex = 8;
            lbl_IntellectTitle.Text = "Intellect:";
            lbl_IntellectTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Intellect
            // 
            lbl_Intellect.AutoSize = true;
            lbl_Intellect.Location = new Point(178, 153);
            lbl_Intellect.Name = "lbl_Intellect";
            lbl_Intellect.Size = new Size(87, 30);
            lbl_Intellect.TabIndex = 9;
            lbl_Intellect.Text = "Intellect";
            lbl_Intellect.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lbl_FaithTitle
            // 
            lbl_FaithTitle.AutoSize = true;
            lbl_FaithTitle.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_FaithTitle.Location = new Point(4, 191);
            lbl_FaithTitle.Name = "lbl_FaithTitle";
            lbl_FaithTitle.Size = new Size(67, 30);
            lbl_FaithTitle.TabIndex = 10;
            lbl_FaithTitle.Text = "Faith:";
            lbl_FaithTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbl_Faith
            // 
            lbl_Faith.AutoSize = true;
            lbl_Faith.Location = new Point(178, 191);
            lbl_Faith.Name = "lbl_Faith";
            lbl_Faith.Size = new Size(57, 30);
            lbl_Faith.TabIndex = 11;
            lbl_Faith.Text = "Faith";
            lbl_Faith.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // CharacterSelectForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 673);
            Controls.Add(tbl_Stats);
            Controls.Add(btn_Next);
            Controls.Add(cmb_PlayerSelector);
            Controls.Add(label1);
            Controls.Add(lbl_characterName);
            Controls.Add(btn_StartMenuForm);
            Controls.Add(pic_charactherPortrait);
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
    }
}