namespace DiceBattleGame.Forms_UI
{
    partial class ShopForm
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
            label1 = new Label();
            lst_Items = new ListBox();
            lbl_ItemName = new Label();
            lbl_ItemDescription = new Label();
            lbl_Price = new Label();
            btn_BuyItem = new Button();
            btn_Back = new Button();
            lbl_Gold = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(45, 29);
            label1.Name = "label1";
            label1.Size = new Size(64, 30);
            label1.TabIndex = 0;
            label1.Text = "Shop";
            // 
            // lst_Items
            // 
            lst_Items.FormattingEnabled = true;
            lst_Items.ItemHeight = 15;
            lst_Items.Location = new Point(45, 73);
            lst_Items.Name = "lst_Items";
            lst_Items.Size = new Size(180, 289);
            lst_Items.TabIndex = 1;
            // 
            // lbl_ItemName
            // 
            lbl_ItemName.AutoSize = true;
            lbl_ItemName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ItemName.Location = new Point(305, 73);
            lbl_ItemName.Name = "lbl_ItemName";
            lbl_ItemName.Size = new Size(91, 21);
            lbl_ItemName.TabIndex = 2;
            lbl_ItemName.Text = "ItemName";
            // 
            // lbl_ItemDescription
            // 
            lbl_ItemDescription.AutoSize = true;
            lbl_ItemDescription.Location = new Point(305, 123);
            lbl_ItemDescription.Name = "lbl_ItemDescription";
            lbl_ItemDescription.Size = new Size(81, 15);
            lbl_ItemDescription.TabIndex = 3;
            lbl_ItemDescription.Text = "Select an item";
            // 
            // lbl_Price
            // 
            lbl_Price.AutoSize = true;
            lbl_Price.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Price.Location = new Point(305, 295);
            lbl_Price.Name = "lbl_Price";
            lbl_Price.Size = new Size(107, 20);
            lbl_Price.TabIndex = 4;
            lbl_Price.Text = "Select an item";
            // 
            // btn_BuyItem
            // 
            btn_BuyItem.Location = new Point(305, 339);
            btn_BuyItem.Name = "btn_BuyItem";
            btn_BuyItem.Size = new Size(75, 23);
            btn_BuyItem.TabIndex = 5;
            btn_BuyItem.Text = "Buy";
            btn_BuyItem.UseVisualStyleBackColor = true;
            // 
            // btn_Back
            // 
            btn_Back.Location = new Point(568, 339);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(75, 23);
            btn_Back.TabIndex = 6;
            btn_Back.Text = "Back";
            btn_Back.UseVisualStyleBackColor = true;
            btn_Back.Click += btn_Back_Click;
            // 
            // lbl_Gold
            // 
            lbl_Gold.AutoSize = true;
            lbl_Gold.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Gold.Location = new Point(573, 73);
            lbl_Gold.Name = "lbl_Gold";
            lbl_Gold.Size = new Size(122, 21);
            lbl_Gold.TabIndex = 7;
            lbl_Gold.Text = "Gold Available";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(305, 262);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 8;
            label2.Text = "Price:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(517, 73);
            label3.Name = "label3";
            label3.Size = new Size(50, 21);
            label3.TabIndex = 9;
            label3.Text = "Gold:";
            // 
            // ShopForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lbl_Gold);
            Controls.Add(btn_Back);
            Controls.Add(btn_BuyItem);
            Controls.Add(lbl_Price);
            Controls.Add(lbl_ItemDescription);
            Controls.Add(lbl_ItemName);
            Controls.Add(lst_Items);
            Controls.Add(label1);
            Name = "ShopForm";
            Text = "ShopForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lst_Items;
        private Label lbl_ItemName;
        private Label lbl_ItemDescription;
        private Label lbl_Price;
        private Button btn_BuyItem;
        private Button btn_Back;
        private Label lbl_Gold;
        private Label label2;
        private Label label3;
    }
}