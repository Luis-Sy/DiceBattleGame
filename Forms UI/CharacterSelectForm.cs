using System;
using System.Windows.Forms;

namespace DiceBattleGame
{
    public partial class CharacterSelectForm : Form
    {
        public CharacterSelectForm()
        {
            InitializeComponent();
            this.Text = "Choose Your Character";
            SetupUI();
        }
        private void SetupUI()
        {
            
            this.Width = 600;
            this.Height = 400;

            Button startButton = new Button();
            startButton.Text = "Start Game";
            startButton.Width = 200;
            startButton.Height = 50;
            startButton.Left = (this.ClientSize.Width - startButton.Width) / 2;
            startButton.Top = (this.ClientSize.Height - startButton.Height) / 2;

            startButton.Click += (s, e) =>
            {
                GameManager.SwitchTo(new StartMenuForm());
            };

            this.Controls.Add(startButton);
        }
    }
}
