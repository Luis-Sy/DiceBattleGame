using DiceBattleGame.GameData.Items;
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
        private List<Item> items;

        public ShopForm()
        {
            InitializeComponent();
            LoadShopItems();
            lst_Items.SelectedIndexChanged += lst_Items_SelectedIndexChanged;
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(GameManager.MapInstance);
        }

        public void LoadShopItems()
        {
            items = ItemDatabase.ShopItems;
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
