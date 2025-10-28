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

            Trace.WriteLine($"Knight attacking Duelist with HP: {player2.getHealth()}");
            Trace.WriteLine($"Knight rolled: {damage} with damage type: Slash");
            player2.takeDamage(damage, "slash"); // need a way to get damage type from weapon
            Trace.WriteLine($"Duelist has 2.0x Slash resistance (slash damage taken is doubled)");
            Trace.WriteLine($"Duelist now has {player2.getHealth()} HP");


        }
    }
}