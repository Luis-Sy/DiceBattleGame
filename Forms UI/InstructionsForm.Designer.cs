namespace DiceBattleGame.Forms_UI
{
    partial class InstructionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstructionsForm));
            btn_StartMenuForm = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // btn_StartMenuForm
            // 
            btn_StartMenuForm.Location = new Point(215, 229);
            btn_StartMenuForm.Margin = new Padding(2, 2, 2, 2);
            btn_StartMenuForm.Name = "btn_StartMenuForm";
            btn_StartMenuForm.Size = new Size(113, 27);
            btn_StartMenuForm.TabIndex = 2;
            btn_StartMenuForm.Text = "Start Menu";
            btn_StartMenuForm.UseVisualStyleBackColor = true;
            btn_StartMenuForm.Click += btn_StartMenuForm_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(11, 11);
            richTextBox1.Margin = new Padding(2, 2, 2, 2);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(511, 197);
            richTextBox1.TabIndex = 3;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // InstructionsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 300);
            Controls.Add(richTextBox1);
            Controls.Add(btn_StartMenuForm);
            Margin = new Padding(2, 2, 2, 2);
            Name = "InstructionsForm";
            Text = "InstructionsForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_StartMenuForm;
        private RichTextBox richTextBox1;
    }
}