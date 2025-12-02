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
            SuspendLayout();
            // 
            // btn_StartGame
            // 
            btn_StartGame.Location = new Point(331, 307);
            btn_StartGame.Name = "btn_StartGame";
            btn_StartGame.Size = new Size(131, 40);
            btn_StartGame.TabIndex = 0;
            btn_StartGame.Text = "Start game";
            btn_StartGame.UseVisualStyleBackColor = true;
            btn_StartGame.Click += btn_StartGame_Click;
            // 
            // StartMenuForm
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btn_StartGame);
            Name = "StartMenuForm";
            Text = "StartMenuForm";
            ResumeLayout(false);
        }

        #endregion

        private Button btn_StartGame;
    }
}