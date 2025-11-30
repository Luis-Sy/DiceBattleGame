using DiceBattleGame.Data.Characters;
using DiceBattleGame.Data.Characters.Playable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace DiceBattleGame
{
    public partial class CharacterView : Form
    {
        public CharacterView()
        {
            InitializeComponent();

            Character character = new RangerPlayer();

            character.setLevel(1);

            nameLbl.Text = character.getName();
            typeLbl.Text = character.getCharacterType();
            levelLbl.Text = "Level: " + character.getLevel().ToString();
            healthLbl.Text = "Health: " + character.getHealth().ToString();

            foreach (var stat in character.getStats())
            {
                statBox.Items.Add(stat.Key + ": " + stat.Value);
            }

            foreach (var growth in character.getStatGrowths())
            {
                if (growth.Value > 0)
                {
                    statGrowthBox.Items.Add(growth.Key + ": +" + growth.Value.ToString());
                }
                else
                {
                    statGrowthBox.Items.Add(growth.Key + ": " + growth.Value.ToString());
                }
                
            }

        }
    }
}
