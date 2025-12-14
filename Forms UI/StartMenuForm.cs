using DiceBattleGame.Forms_UI;
using System;
using System.Reflection.Emit;
using System.Windows.Forms;

namespace DiceBattleGame
{
    public partial class StartMenuForm : Form
    {
        public StartMenuForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10);

            this.Text = "Main Menu";


            StyleButtons();
        }
        private void StyleButtons()
        {
            StyleButton(btn_StartGame, Color.FromArgb(76, 175, 80)); //green
            StyleButton(btn_InstructionsForm, Color.FromArgb(74, 144, 226)); // Blue
            StyleButton(btn_CreditsForm, Color.FromArgb(120, 120, 120));//gray
        }
        private void StyleButton(Button btn, Color backColor)
        {
            btn.BackColor = backColor;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(new CharacterSelectForm());
        }

        private void btn_CreditsForm_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(new CreditsForm());
        }

        private void btn_InstructionsForm_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(new InstructionsForm());
        }
    }
}
