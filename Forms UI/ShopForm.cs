using DiceBattleGame.GameData.Characters;
using DiceBattleGame.GameData.Items;
using DiceBattleGame.GameData.MapEvents;

namespace DiceBattleGame.Forms_UI
{
    public partial class ShopForm : Form
    {
        private Shop shop;
        private List<Item> items;
        private List<Character> recruits;


        public ShopForm(Shop shopEvent)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10);
            this.Text = "Shop";

            shop = shopEvent;
            items = shopEvent.GetEventData<List<Item>>();
            recruits = shopEvent.GetEventData<List<Character>>();

            lbl_Gold.Text = GameManager.Campaign.GetGold().ToString();
            LoadShopItems();
            StyleButtons();
            LoadRecruitableCharacters();
            lst_Items.SelectedIndex = 0;
            lst_Recruitable.SelectedIndex = 0;
        }



        private void StyleButtons()
        {
            StyleButton(btn_BuyItem, Color.FromArgb(76, 175, 80)); //green
            StyleButton(btn_Back, Color.FromArgb(120, 120, 120));//gray
            StyleButton(hireBtn, Color.FromArgb(76, 175, 80)); //green
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

        private void btn_Back_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(GameManager.MapInstance);
        }

        public void LoadShopItems()
        {

            lst_Items.Items.Clear();
            foreach (var item in items)
            {
                lst_Items.Items.Add(item.Name);
            }
            lst_Items.SelectedIndex = 0;
        }

        private void LoadRecruitableCharacters()
        {
            lst_Recruitable.Items.Clear();
            foreach (var recruit in recruits)
            {
                lst_Recruitable.Items.Add(recruit.getName());
            }
            lst_Recruitable.SelectedIndex = 0;
        }

        public bool tryPurchase(int price)
        {
            if (price > GameManager.Campaign.GetGold())
            {
                MessageBox.Show("You do not have enough gold to make this purchase.", "Insufficient Funds", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                GameManager.Campaign.ChangeGold(-price);
                lbl_Gold.Text = GameManager.Campaign.GetGold().ToString();
                return true;
            }
        }

        public void purchaseItem(Item item)
        {
            if (tryPurchase(item.Price))
            {
                GameManager.Campaign.GetPlayerInventory().Add(item);
                items.RemoveAt(lst_Items.SelectedIndex);
                MessageBox.Show($"You have purchased {item.Name}!", "Purchase Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        public void hirePartyMember(Character character)
        {
            // hiring has a fixed cost of 15 gold
            if (tryPurchase(15))
            {
                GameManager.Campaign.GetPlayerParty().Add(character);
                recruits.RemoveAt(lst_Recruitable.SelectedIndex);
                MessageBox.Show($"You have recruited {character.getName()}!", "Recruitment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lst_Items_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lst_Items.SelectedIndex;
            if (index < 0) return;

            Item selected = items[index];

            lbl_ItemName.Text = selected.Name;
            lbl_ItemDescription.Text = selected.Description;
            lbl_Price.Text = selected.Price.ToString();
        }

        private void lst_Recruitable_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = lst_Recruitable.SelectedIndex;
            if (index < 0) return;

            Character selected = shop.GetEventData<List<Character>>()[index];
            lst_StatView.Items.Clear();

            // display stats
            foreach (var stat in selected.getStats())
            {
                lst_StatView.Items.Add(stat.Key + ": " + stat.Value);
            }
        }

        private void btn_BuyItem_Click(object sender, EventArgs e)
        {
            purchaseItem(items[lst_Items.SelectedIndex]);
            LoadShopItems();
        }

        private void hireBtn_Click(object sender, EventArgs e)
        {
            hirePartyMember(recruits[lst_Recruitable.SelectedIndex]);
            LoadRecruitableCharacters();
        }
    }
}
