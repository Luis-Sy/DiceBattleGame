using System;
using System.Windows.Forms;

namespace DiceBattleGame
{
    internal static class GameManager
    {
        private static Form? currentForm;

        // Sets the starting form when the application launches.
        public static Form GetStartupForm()
        {
            currentForm = new StartMenuForm();
            return currentForm;
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
