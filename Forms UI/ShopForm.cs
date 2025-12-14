using DiceBattleGame.GameData.Items;
using DiceBattleGame.GameData.MapEvents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceBattleGame.Forms_UI
{
    public partial class ShopForm : Form
    {
        private Shop shopEvent;
        private List<Item> items;

        

        public ShopForm(Shop shopEvent)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10);
            this.Text = "Shop";

            this.shopEvent = shopEvent;
            items = shopEvent.GetEventData<List<Item>>();
            LoadShopItems();
            StyleButtons();
            lst_Items.SelectedIndexChanged += lst_Items_SelectedIndexChanged;
        }
        private void StyleButtons()
        {
            StyleButton(btn_BuyItem, Color.FromArgb(76, 175, 80)); //green
            StyleButton(btn_Back, Color.FromArgb(120, 120, 120));//gray
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
            //items = ItemDatabase.ShopItems;
            
            lst_Items.Items.Clear();
            foreach (var item in items)
            {
                lst_Items.Items.Add(item.Name);
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

    }
}
