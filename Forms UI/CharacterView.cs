using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.Characters.Enemies.Common;
using DiceBattleGame.GameData.Characters.Enemies.Elite;
using DiceBattleGame.GameData.Characters.Playable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Text = "Characters";


            // change this to test different characters
            Character character = new Samurai();
            Character character2 = new Samurai();

            // change this to see how a character's stats grow
            character.setLevel(1);
            character.initializeStats();

            // how to access and modify the stats
            character.getStats()["Strength"] += 5;
            // works with stat growths too
            character2.getStatGrowths()["Strength"] += 5;

            character.getResistances()["Slash"] = 1.6;
            Trace.WriteLine(character.getResistances()["Slash"]);

            character2.setLevel(5);
            character2.initializeStats();

            nameLbl.Text = character2.getName();
            typeLbl.Text = character2.getCharacterType();
            levelLbl.Text = "Level: " + character2.getLevel().ToString();
            healthLbl.Text = "Health: " + character2.getHealth().ToString();


            // display stats
            foreach (var stat in character2.getStats())
            {
                statBox.Items.Add(stat.Key + ": " + stat.Value);
            }

            // display stat growths
            foreach (var growth in character2.getStatGrowths())
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
