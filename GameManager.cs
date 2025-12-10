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
        //saves the player's current position on the map
        public static int CurrentMapNodeIndex { get; set; } = 0;

        public static MapForm? MapInstance { get; set; }

        //to finalize the game when the player dies
        public static bool PlayerIsDead { get; set; } = false;

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
            CurrentMapNodeIndex = 0;
            PlayerIsDead = false;
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

