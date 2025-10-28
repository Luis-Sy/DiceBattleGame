namespace DiceBattleGame
{
    public partial class Form1 : Form
    {
        Weapon knife = new Debug("shoot", "debug", "ouchy");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DiceRollerbtn_Click(object sender, EventArgs e)
        {
            int damage = knife.Attack();
            string damageDisplay = damage.ToString();

            RollResults.Text = damageDisplay;
        }

        private void RollResults_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}