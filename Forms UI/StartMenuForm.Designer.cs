namespace DiceBattleGame
{
    partial class StartMenuForm
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
            btn_StartGame = new Button();
            btn_CreditsForm = new Button();
            btn_InstructionsForm = new Button();
            SuspendLayout();
            // 
            // btn_StartGame
            // 
            btn_StartGame.Location = new Point(323, 67);
            btn_StartGame.Name = "btn_StartGame";
            btn_StartGame.Size = new Size(131, 40);
            btn_StartGame.TabIndex = 0;
            btn_StartGame.Text = "Start game";
            btn_StartGame.UseVisualStyleBackColor = true;
            btn_StartGame.Click += btn_StartGame_Click;
            // 
            // btn_CreditsForm
            // 
            btn_CreditsForm.Location = new Point(323, 227);
            btn_CreditsForm.Name = "btn_CreditsForm";
            btn_CreditsForm.Size = new Size(131, 40);
            btn_CreditsForm.TabIndex = 1;
            btn_CreditsForm.Text = "Credits";
            btn_CreditsForm.UseVisualStyleBackColor = true;
            btn_CreditsForm.Click += btn_CreditsForm_Click;
            // 
            // btn_InstructionsForm
            // 
            btn_InstructionsForm.Location = new Point(323, 145);
            btn_InstructionsForm.Name = "btn_InstructionsForm";
            btn_InstructionsForm.Size = new Size(131, 40);
            btn_InstructionsForm.TabIndex = 2;
            btn_InstructionsForm.Text = "Instructions";
            btn_InstructionsForm.UseVisualStyleBackColor = true;
            btn_InstructionsForm.Click += btn_InstructionsForm_Click;
            // 
            // StartMenuForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_InstructionsForm);
            Controls.Add(btn_CreditsForm);
            Controls.Add(btn_StartGame);
            Name = "StartMenuForm";
            Text = "StartMenuForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_StartGame;
        private Button btn_CreditsForm;
        private Button btn_InstructionsForm;
    }
}