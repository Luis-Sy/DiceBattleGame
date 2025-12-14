using DiceBattleGame.GameData.Characters;
using DiceBattleGame.Forms_UI;
using System;
using System.Reflection;
using System.Windows.Forms;

namespace DiceBattleGame
{
    public partial class CharacterSelectForm : Form
    {
        private List<Character> availableCharacters = new List<Character>();
        public CharacterSelectForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10);
            this.Text = "Character";

            StyleButtons();
            LoadCharactersIntoDropdown();
        }
        private void StyleButtons()
        {
            StyleButton(btn_Next, Color.FromArgb(76, 175, 80)); //green
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
        private void LoadCharactersIntoDropdown()
        {
            var assembly = Assembly.GetExecutingAssembly();

            //find all classes in Playable namespace 
            var characterTypes = assembly
                .GetTypes().Where(t =>
                    t.IsClass && t.Namespace == "DiceBattleGame.GameData.Characters.Playable" && typeof(Character).IsAssignableFrom(t)
                );

            foreach (var type in characterTypes)
            {
                //create an instance of each character class
                Character c = (Character)Activator.CreateInstance(type)!;

                //add to list
                availableCharacters.Add(c);

                //add to the dropdown menu
                cmb_PlayerSelector.Items.Add(c.getName());
            }

            cmb_PlayerSelector.SelectedIndexChanged += cmb_PlayerSelector_SelectedIndexChanged;

            //select first item automaticaly
            if (cmb_PlayerSelector.Items.Count > 0)
            {
                cmb_PlayerSelector.SelectedIndex = 0;
                //to trigger the even manually otherwise the dropdown menu has selected the fist charc but doesn't charge the label name and the image
                cmb_PlayerSelector_SelectedIndexChanged(cmb_PlayerSelector, EventArgs.Empty);
            }





        }

        private void cmb_PlayerSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmb_PlayerSelector.SelectedIndex;
            if (index < 0 || index >= availableCharacters.Count) return;

            Character selected = availableCharacters[index];
            //to update the label with the character name
            lbl_characterName.Text = selected.getName();
            //display the image
            loadCharacterAvatar(selected.getName());

            //update stats in the table
            var stats = selected.getStats();
            lbl_Vigor.Text = stats["Vigor"].ToString();
            lbl_Constitution.Text = stats["Constitution"].ToString();
            lbl_Strength.Text = stats["Strength"].ToString();
            lbl_Dexterity.Text = stats["Dexterity"].ToString();
            lbl_Intellect.Text = stats["Intellect"].ToString();
            lbl_Faith.Text = stats["Faith"].ToString();



        }

        private void loadCharacterAvatar(string characterName)
        {
            //images path 
            string imgPath = Path.Combine("Assets", "Images", $"{characterName}.png");
            string imgPathPlaceholder = Path.Combine("Assets", "Images", "placeholder.png");
            if (File.Exists(imgPath))
            {
                pic_charactherPortrait.Image = Image.FromFile(imgPath);
            }
            else
            {
                pic_charactherPortrait.Image = Image.FromFile(imgPathPlaceholder);
            }
        }

        private void btn_StartMenuForm_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(new StartMenuForm());
        }

        private void lbl_characterName_Click(object sender, EventArgs e)
        {

        }

        private void btn_Next_Click(object sender, EventArgs e)
        {
            int index = cmb_PlayerSelector.SelectedIndex;

            GameManager.SelectedCharacter = availableCharacters[index];
            GameManager.StartCampaign();
            GameManager.MapInstance = new MapForm();
            GameManager.SwitchTo(GameManager.MapInstance);
        }

        private void tbl_Stats_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
