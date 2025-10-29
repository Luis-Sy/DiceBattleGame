using System;
using System.Windows.Forms;

namespace DiceBattleGame
{
    public partial class Form1 : Form
    {
        private WeaponSystem armory;

        public Form1()
        {
            InitializeComponent();
            InitializeWeaponsUi();
        }

        // Initialize and populate weapon dropdown
        private void InitializeWeaponsUi()
        {
            armory = new WeaponSystem();

            weaponPicker.Items.Clear();
            foreach (var name in armory.GetWeaponNames())
            {
                weaponPicker.Items.Add(name);
            }

            if (weaponPicker.Items.Count > 0)
                weaponPicker.SelectedIndex = 0;

            lblCurrentWeapon.Text = "Current: " + armory.CurrentName();
            lblDamage.Text = "Damage: 0";

            // ? added line: initialize the damage type label
            lblDamageType.Text = "Type: -";
        }

        // Select weapon button click
        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (weaponPicker.SelectedIndex < 0)
            {
                MessageBox.Show("Pick a weapon first.", "Heads up");
                return;
            }

            try
            {
                armory.SelectByIndex(weaponPicker.SelectedIndex);
                lblCurrentWeapon.Text = "Current: " + armory.CurrentName();

                // ? added line: show damage type when weapon selected
                lblDamageType.Text = "Type: " + armory.CurrentDamageType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Selection Error");
            }
        }

        // Attack button click
        private void btnAttack_Click(object sender, EventArgs e)
        {
            try
            {
                int dmg = armory.Attack();
                lblDamage.Text = "Damage: " + dmg;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Attack Error");
            }
        }
    }
}
