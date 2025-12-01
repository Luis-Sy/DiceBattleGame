namespace DiceBattleGame
{
    using DiceBattleGame.Data.Characters;
    using DiceBattleGame.Data.Characters.Playable;
    using DiceBattleGame.Data.System;
    using DiceBattleGame.GameData.System;
    using System.Diagnostics;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // test code to view campaign and map generation
            CampaignManager cm = new CampaignManager(new KnightPlayer());

            cm.displayMapData();

        }
    }
}