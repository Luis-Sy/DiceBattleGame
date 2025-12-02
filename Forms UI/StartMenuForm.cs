using System;
using System.Windows.Forms;

namespace DiceBattleGame
{
    public partial class StartMenuForm : Form
    {
        public StartMenuForm()
        {
            InitializeComponent();
            
        }

        private void btn_StartGame_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(new CharacterSelectForm());
        }
    }
}
