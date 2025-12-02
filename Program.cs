using System;
using System.Windows.Forms;

namespace DiceBattleGame
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(GameManager.GetStartupForm());
        }
    }
}
