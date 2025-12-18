using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceBattleGame.Forms_UI
{
    public partial class InstructionsForm : Form
    {
        public InstructionsForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10);
            this.Text = "Instructions";
            StyleButtons();

        }
        private void StyleButtons()
        {
            
            StyleButton(btn_StartMenuForm, Color.FromArgb(120, 120, 120));//gray
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

        private void btn_StartMenuForm_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(new StartMenuForm());
        }

        private void InstructionsForm_Load(object sender, EventArgs e)
        {
            richTextBox1.ReadOnly = true;

            richTextBox1.Text =
                "HOW TO PLAY – DICE BATTLE GAME\r\n";
               
        }

    }

}
