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
            lbl_Price = new Label();
            btn_BuyItem = new Button();
            btn_Back = new Button();
            lbl_Gold = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            hireBtn = new Button();
            label6 = new Label();
            lst_Recruitable = new ListBox();
            lst_StatView = new ListBox();
            itemDescriptionBox = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(51, 9);
            label1.Name = "label1";
            label1.Size = new Size(82, 37);
            label1.TabIndex = 0;
            label1.Text = "Shop";
            // 
            // lst_Items
            // 
            lst_Items.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lst_Items.FormattingEnabled = true;
            lst_Items.ItemHeight = 28;
            lst_Items.Location = new Point(51, 97);
            lst_Items.Margin = new Padding(3, 4, 3, 4);
            lst_Items.Name = "lst_Items";
            lst_Items.Size = new Size(292, 200);
            lst_Items.TabIndex = 1;
            lst_Items.SelectedIndexChanged += lst_Items_SelectedIndexChanged;
            // 
            // lbl_ItemName
            // 
            lbl_ItemName.AutoSize = true;
            lbl_ItemName.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_ItemName.Location = new Point(349, 97);
            lbl_ItemName.Name = "lbl_ItemName";
            lbl_ItemName.Size = new Size(111, 28);
            lbl_ItemName.TabIndex = 2;
            lbl_ItemName.Text = "ItemName";
            // 
            // lbl_Price
            // 
            lbl_Price.AutoSize = true;
            lbl_Price.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Price.Location = new Point(416, 216);
            lbl_Price.Name = "lbl_Price";
            lbl_Price.Size = new Size(135, 25);
            lbl_Price.TabIndex = 4;
            lbl_Price.Text = "Select an item";
            // 
            // btn_BuyItem
            // 
            btn_BuyItem.Location = new Point(349, 266);
            btn_BuyItem.Margin = new Padding(3, 4, 3, 4);
            btn_BuyItem.Name = "btn_BuyItem";
            btn_BuyItem.Size = new Size(86, 31);
            btn_BuyItem.TabIndex = 5;
            btn_BuyItem.Text = "Buy Item";
            btn_BuyItem.UseVisualStyleBackColor = true;
            btn_BuyItem.Click += btn_BuyItem_Click;
            // 
            // btn_Back
            // 
            btn_Back.Location = new Point(655, 507);
            btn_Back.Margin = new Padding(3, 4, 3, 4);
            btn_Back.Name = "btn_Back";
            btn_Back.Size = new Size(86, 31);
            btn_Back.TabIndex = 6;
            btn_Back.Text = "Back";
            btn_Back.UseVisualStyleBackColor = true;
            btn_Back.Click += btn_Back_Click;
            // 
            // lbl_Gold
            // 
            lbl_Gold.AutoSize = true;
            lbl_Gold.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_Gold.Location = new Point(442, 8);
            lbl_Gold.Name = "lbl_Gold";
            lbl_Gold.Size = new Size(207, 38);
            lbl_Gold.TabIndex = 7;
            lbl_Gold.Text = "Gold Available";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(349, 216);
            label2.Name = "label2";
            label2.Size = new Size(61, 25);
            label2.TabIndex = 8;
            label2.Text = "Price:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(349, 8);
            label3.Name = "label3";
            label3.Size = new Size(87, 38);
            label3.TabIndex = 9;
            label3.Text = "Gold:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(51, 307);
            label4.Name = "label4";
            label4.Size = new Size(192, 28);
            label4.TabIndex = 11;
            label4.Text = "Characters for Hire";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(51, 65);
            label5.Name = "label5";
            label5.Size = new Size(143, 28);
            label5.TabIndex = 12;
            label5.Text = "Items for Sale";
            // 
            // hireBtn
            // 
            hireBtn.Location = new Point(476, 509);
            hireBtn.Name = "hireBtn";
            hireBtn.Size = new Size(94, 29);
            hireBtn.TabIndex = 13;
            hireBtn.Text = "Hire";
            hireBtn.UseVisualStyleBackColor = true;
            hireBtn.Click += hireBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(476, 338);
            label6.Name = "label6";
            label6.Size = new Size(235, 28);
            label6.TabIndex = 14;
            label6.Text = "Hiring costs 15 Gold each";
            // 
            // lst_Recruitable
            // 
            lst_Recruitable.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lst_Recruitable.FormattingEnabled = true;
            lst_Recruitable.ItemHeight = 28;
            lst_Recruitable.Location = new Point(51, 338);
            lst_Recruitable.Name = "lst_Recruitable";
            lst_Recruitable.Size = new Size(205, 200);
            lst_Recruitable.TabIndex = 15;
            lst_Recruitable.SelectedIndexChanged += lst_Recruitable_SelectedIndexChanged;
            // 
            // lst_StatView
            // 
            lst_StatView.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lst_StatView.FormattingEnabled = true;
            lst_StatView.ItemHeight = 28;
            lst_StatView.Location = new Point(262, 338);
            lst_StatView.Name = "lst_StatView";
            lst_StatView.Size = new Size(198, 200);
            lst_StatView.TabIndex = 16;
            // 
            // itemDescriptionBox
            // 
            itemDescriptionBox.Location = new Point(349, 128);
            itemDescriptionBox.Name = "itemDescriptionBox";
            itemDescriptionBox.ReadOnly = true;
            itemDescriptionBox.Size = new Size(405, 85);
            itemDescriptionBox.TabIndex = 17;
            itemDescriptionBox.Text = "Select an item to see details";
            // 
            // ShopForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(itemDescriptionBox);
            Controls.Add(lst_StatView);
            Controls.Add(lst_Recruitable);
            Controls.Add(label6);
            Controls.Add(hireBtn);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(lbl_Gold);
            Controls.Add(btn_Back);
            Controls.Add(btn_BuyItem);
            Controls.Add(lbl_Price);
            Controls.Add(lbl_ItemName);
            Controls.Add(lst_Items);
            Controls.Add(label1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "ShopForm";
            Text = "ShopForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox lst_Items;
        private Label lbl_ItemName;
        private Label lbl_Price;
        private Button btn_BuyItem;
        private Button btn_Back;
        private Label lbl_Gold;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button hireBtn;
        private Label label6;
        private ListBox lst_Recruitable;
        private ListBox lst_StatView;
        private RichTextBox itemDescriptionBox;
    }
}