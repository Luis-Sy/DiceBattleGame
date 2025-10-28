namespace DiceBattleGame
{
    using System.Diagnostics;
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // test for dicebag
            Dice dice = new diceBag(5, 4);
            Trace.WriteLine(dice.Roll());

            // testing characters and weapons
            Character player1 = new Knight();
            Character player2 = new Duelist();

            int damage = player1.attack();

            Trace.WriteLine($"Knight attacking Duelist");
            Trace.WriteLine($"Knight rolled: {damage}");
            player2.takeDamage(damage, "slash");
            Trace.WriteLine($"Duelist now has {player2.getHealth()}");


        }
    }
}