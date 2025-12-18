namespace DiceBattleGame.Forms_UI
{
    partial class CreditsForm
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
            richTextBox1 = new RichTextBox();
            btn_StartMenuForm = new Button();
            SuspendLayout();
            // 
            // richTextBox1
            // 
            richTextBox1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBox1.Location = new Point(71, 27);
            richTextBox1.Margin = new Padding(2, 2, 2, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(397, 243);
            richTextBox1.TabIndex = 0;
            richTextBox1.Text = "Created by:\n\n*Carlos Alvarez (UI Design and Programming)\n*Junaid Matyas-Hussain (Item & Skill Design)\n*Luis Sy (Game Design, General Programming)\n*Nicole Ricare (Battle System & Items)";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // btn_StartMenuForm
            // 
            btn_StartMenuForm.Location = new Point(204, 306);
            btn_StartMenuForm.Margin = new Padding(2, 2, 2, 2);
            btn_StartMenuForm.Name = "btn_StartMenuForm";
            btn_StartMenuForm.Size = new Size(119, 27);
            btn_StartMenuForm.TabIndex = 1;
            btn_StartMenuForm.Text = "Return";
            btn_StartMenuForm.UseVisualStyleBackColor = true;
            btn_StartMenuForm.Click += btn_StartMenuForm_Click;
            // 
            // CreditsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(544, 398);
            Controls.Add(btn_StartMenuForm);
            Controls.Add(richTextBox1);
            Margin = new Padding(2, 2, 2, 2);
            Name = "CreditsForm";
            Text = "CreditsForm";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox richTextBox1;
        private Button btn_StartMenuForm;
    }
}