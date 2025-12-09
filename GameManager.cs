using System;
using System.Windows.Forms;
using DiceBattleGame.GameData.System;
using DiceBattleGame.GameData.Characters;
using DiceBattleGame.Forms_UI;

namespace DiceBattleGame
{
    internal static class GameManager
    {
        private static Form? currentForm;

        //This is the state of the game
        public static CampaignManager? Campaign { get; private set; }

        //selected player before creating the campaingManager
        public static Character? SelectedCharacter { get;  set; }

        public static MapForm? MapInstance { get; set; }

        // Sets the starting form when the application launches.
        public static Form GetStartupForm()
        {
            currentForm = new StartMenuForm();
            return currentForm;
        }

        public static void StartCampaign()
        {
            if (SelectedCharacter == null)

                throw new Exception("No characther selected before starting campaign");

            Campaign = new CampaignManager(SelectedCharacter);
        }


        // Switches from the current form to the next form.        
        public static void SwitchTo(Form nextForm)
        {
            if (currentForm != null)
            {
                currentForm.Hide();
            }

            currentForm = nextForm;
            currentForm.Show();
        }
    }
}

