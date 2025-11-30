using DiceBattleGame.Data.Characters;
using DiceBattleGame.Data.Characters.Playable;
using DiceBattleGame.GameData.Characters.Enemies.Common;
using DiceBattleGame.GameData.Characters.Enemies.Elite;
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
        // this form is used to display character information for debuggin purposes
        public CharacterView()
        {
            InitializeComponent();

            // change this to test different characters
            Character character = new Goblin();

            // change this to see how a character's stats grow
            character.setLevel(1);
            character.initializeStats();

            nameLbl.Text = character.getName();
            typeLbl.Text = character.getCharacterType();
            levelLbl.Text = "Level: " + character.getLevel().ToString();
            healthLbl.Text = "Health: " + character.getHealth().ToString();


            // display stats
            foreach (var stat in character.getStats())
            {
                statBox.Items.Add(stat.Key + ": " + stat.Value);
            }

            // display stat growths
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
