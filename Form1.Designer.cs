namespace DiceBattleGame
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        
        private System.Windows.Forms.ComboBox weaponPicker;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Label lblCurrentWeapon;
        private System.Windows.Forms.Button btnAttack;
        private System.Windows.Forms.Label lblDamage;
        private System.Windows.Forms.Label lblDamageType;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.weaponPicker = new System.Windows.Forms.ComboBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.lblCurrentWeapon = new System.Windows.Forms.Label();
            this.btnAttack = new System.Windows.Forms.Button();
            this.lblDamage = new System.Windows.Forms.Label();
            this.lblDamageType = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // weaponPicker
            // 
            this.weaponPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.weaponPicker.FormattingEnabled = true;
            this.weaponPicker.Location = new System.Drawing.Point(24, 24);
            this.weaponPicker.Name = "weaponPicker";
            this.weaponPicker.Size = new System.Drawing.Size(200, 23);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(240, 24);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(120, 23);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "Select Weapon";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // lblCurrentWeapon
            // 
            this.lblCurrentWeapon.AutoSize = true;
            this.lblCurrentWeapon.Location = new System.Drawing.Point(24, 60);
            this.lblCurrentWeapon.Name = "lblCurrentWeapon";
            this.lblCurrentWeapon.Size = new System.Drawing.Size(103, 15);
            this.lblCurrentWeapon.TabIndex = 2;
            this.lblCurrentWeapon.Text = "Current: (none)";
            // 
            // btnAttack
            // 
            this.btnAttack.Location = new System.Drawing.Point(24, 92);
            this.btnAttack.Name = "btnAttack";
            this.btnAttack.Size = new System.Drawing.Size(120, 23);
            this.btnAttack.TabIndex = 3;
            this.btnAttack.Text = "Attack!";
            this.btnAttack.UseVisualStyleBackColor = true;
            this.btnAttack.Click += new System.EventHandler(this.btnAttack_Click);
            // 
            // lblDamage
            // 
            this.lblDamage.AutoSize = true;
            this.lblDamage.Location = new System.Drawing.Point(24, 130);
            this.lblDamage.Name = "lblDamage";
            this.lblDamage.Size = new System.Drawing.Size(72, 15);
            this.lblDamage.TabIndex = 4;
            this.lblDamage.Text = "Damage: 0";
            // 
            // lblDamageType
            // 
            this.lblDamageType.AutoSize = true;
            this.lblDamageType.Location = new System.Drawing.Point(150, 130);
            this.lblDamageType.Name = "lblDamageType";
            this.lblDamageType.Size = new System.Drawing.Size(43, 15);
            this.lblDamageType.TabIndex = 5;
            this.lblDamageType.Text = "Type: -";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 180);
            this.Controls.Add(this.lblDamageType);
            this.Controls.Add(this.lblDamage);
            this.Controls.Add(this.btnAttack);
            this.Controls.Add(this.lblCurrentWeapon);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.weaponPicker);
            this.Name = "Form1";
            this.Text = "Dice Battle – Weapons";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}
