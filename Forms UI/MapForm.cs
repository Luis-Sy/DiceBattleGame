using DiceBattleGame.GameData.MapEvents;
using DiceBattleGame.GameData.MapEvents.CombatEncounters;
using DiceBattleGame.GameData.System;
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
    public partial class MapForm : Form
    {


        //private enum NodeType
        //{
        //    Battle,
        //    Shop,
        //    Rest,
        //    Boss
        //}
        //private List<NodeType> nodeTypes = new List<NodeType>
        //{
        //    NodeType.Battle,
        //    NodeType.Battle,
        //    NodeType.Rest,
        //    NodeType.Shop,
        //    NodeType.Battle,
        //    NodeType.Battle,
        //    NodeType.Rest,
        //    NodeType.Boss
        //};

        private List<MapNode> nodes;
        //private int currentNodeIndex=0;
        private int currentNodeIndex = GameManager.CurrentMapNodeIndex;

        //-------------------
        public MapForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Font = new Font("Segoe UI", 10);
            this.Text = "Map";

            nodes = GameManager.Campaign.getMapNodes();
            StyleButtons();

            this.Shown += (s, e) =>
            {
                pic_Map.Invalidate();
                pic_Map.Refresh();
            };


        }
        private void StyleButtons()
        {
            StyleButton(btn_PreviousNode, Color.FromArgb(120, 120, 120));//gray
            StyleButton(btn_Back, Color.FromArgb(120, 120, 120));//gray
            StyleButton(btn_StartMenuForm, Color.FromArgb(120, 120, 120));//gray
            StyleButton(btn_Continue, Color.FromArgb(76, 175, 80)); //green

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

        private void btn_StartMenuForm_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(new StartMenuForm());
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(new CharacterSelectForm());
        }

        private Brush GetNodeColor(MapNode node)
        {
            string type = node.GetNodeType();

            return (type) switch
            {
                "Start" => Brushes.LightBlue,
                "Common Battle" => Brushes.Orange,
                "Elite Battle" => Brushes.DarkRed,
                "Boss Battle" => Brushes.Purple,
                "Shop" => Brushes.LightGreen,
                "Rest" => Brushes.LightGray,
                "Event" => Brushes.Gold,
                _ => Brushes.White
            };
        }


        private void DrawMap(Graphics g)
        {
            //this is just to make the circles look smoth on the drawing
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //length of the game
            int nodeCount = nodes.Count;
            int margin = 40;

            //center the nodes
            int centerY = pic_Map.Height / 2;

            //measures depending on the size of pic_map and nodecount
            int totalWidth = pic_Map.Width - (margin * 2);
            int spacing = totalWidth / (nodeCount - 1);

            //node size
            int nodeSize = Math.Max(20, pic_Map.Height / 10);

            //marker size
            int markerSize = nodeSize / 2;

            int markerY = centerY - nodeSize / 2 - markerSize - 6;

            if (markerY < 5) markerY = 5;
            


            for (int i = 0; i < nodeCount; i++)
            {
                int x = margin + i * spacing;

                //draw the path line
                if (i > 0)
                {
                    int prevX = margin + (i - 1) * spacing;
                    g.DrawLine(Pens.Black, prevX + nodeSize / 2, centerY, x, centerY);

                }

                Rectangle nodeRect = new Rectangle(x - nodeSize / 2, centerY - nodeSize / 2, nodeSize, nodeSize);

                Brush nodeBrush = GetNodeColor(nodes[i]);
                //draw node
                g.FillEllipse(nodeBrush, nodeRect);
                g.DrawEllipse(Pens.Black, nodeRect);

            }
            //player position marker(on node 0)
            int playerX = margin + (GameManager.CurrentMapNodeIndex+1) * spacing;
            g.FillEllipse(Brushes.Red, playerX - markerSize / 2, markerY, markerSize, markerSize);
        }

        private void pic_Map_Paint(object sender, PaintEventArgs e)
        {
            DrawMap(e.Graphics);
        }

        //move foward to next node
        //private void btn_Continue_Click(object sender, EventArgs e)
        //{
        //    if (currentNodeIndex >= nodes.Count - 1)
        //    {
        //        return;
        //    }
        //    //next node index
        //    int nextNode = currentNodeIndex + 1;
        //    MapNode node = nodes[nextNode];

        //    string nodeType = node.GetNodeType();

        //    //save the progress befroe switching screens
        //    currentNodeIndex = nextNode;
        //    GameManager.CurrentMapNodeIndex = currentNodeIndex;
        //    pic_Map.Invalidate();

        //    //if(nodeType == "Shop")
        //    //{
        //    //    Shop shopEvent = node.GetNodeData() as Shop;

        //    //    currentNodeIndex = nextNode;
        //    //    GameManager.CurrentMapNodeIndex= currentNodeIndex;
        //    //    pic_Map.Invalidate();

        //    //    GameManager.SwitchTo(new ShopForm(shopEvent));
        //    //    return;
        //    //}
        //    if (nodeType == "Shop")
        //    {
        //        Shop shopEvent = node.GetNodeData() as Shop;
        //        if (shopEvent == null)
        //        {
        //            MessageBox.Show("shop event not found");
        //            return;
        //        }
        //        GameManager.SwitchTo(new ShopForm(shopEvent));
        //        return;
        //    }


        //    //--------------------------------------

        //    //here goes the other forms to keep going with the map
        //    if (nodeType == "Start" || nodeType == "Common Battle" || nodeType == "Elite Battle" || nodeType =="Boss Battle")
        //    {
        //        CombatEncounter enc = node.GetNodeData() as CombatEncounter;

        //        GameManager.CurrentMapNodeIndex = nextNode;
        //        //currentNodeIndex = nextNode;


        //        BattleForm battleForm = new BattleForm(GameManager.SelectedCharacter, enc);
        //        GameManager.SwitchTo(battleForm);
        //        return;
        //    }
        //    if(nodeType == "Rest")
        //    {
        //        MessageBox.Show("You feel stronger now. Your hp is restored");
        //        GameManager.SelectedCharacter.restoreHp();

        //        currentNodeIndex = nextNode;

        //        return;
        //    }
        //    //-----------------------------------------


        //    currentNodeIndex = nextNode;
        //    pic_Map.Invalidate();
        //}
        private void btn_Continue_Click(object sender, EventArgs e)
        {
            if (currentNodeIndex >= nodes.Count - 1)
            {
                return;
            }

            int nextNode = currentNodeIndex + 1;
            MapNode node = nodes[nextNode];
            string nodeType = node.GetNodeType();

            // -------- SHOP --------
            if (nodeType == "Shop")
            {
                Shop shopEvent = node.GetNodeData() as Shop;
                if (shopEvent == null)
                {
                    MessageBox.Show("shop event not found");
                    return;
                }

                currentNodeIndex = nextNode;
                GameManager.CurrentMapNodeIndex = currentNodeIndex;
                pic_Map.Invalidate();
                pic_Map.Refresh();

                GameManager.SwitchTo(new ShopForm(shopEvent));
                return;
            }

            // -------- BATTLE NODES --------
            if (nodeType == "Start" ||
                nodeType == "Common Battle" ||
                nodeType == "Elite Battle" ||
                nodeType == "Boss Battle")
            {
                CombatEncounter enc = node.GetNodeData() as CombatEncounter;

                BattleForm battleForm = new BattleForm(GameManager.SelectedCharacter, enc,GameManager.Campaign);
                battleForm.ShowDialog();

                if (!battleForm.playerWon)
                {
                    MessageBox.Show("You were defeated. You cannot advance.");
                    btn_Continue.Enabled = false;
                    btn_PreviousNode.Enabled = false;
                    return;
                }
                currentNodeIndex = nextNode;
                GameManager.CurrentMapNodeIndex = currentNodeIndex;

                pic_Map.Invalidate();
                pic_Map.Refresh();
                return;
            }

            // -------- REST --------
            if (nodeType == "Rest")
            {
                MessageBox.Show("You feel stronger now. Your hp is restored");
                GameManager.SelectedCharacter.restoreHp();

                currentNodeIndex = nextNode;
                GameManager.CurrentMapNodeIndex = currentNodeIndex;
                pic_Map.Invalidate();
                pic_Map.Refresh();
                return;
            }
        }

        //move to the previous node
        private void btn_PreviousNode_Click(object sender, EventArgs e)
        {
            if (currentNodeIndex > 0)
            {
                currentNodeIndex--;
                GameManager.CurrentMapNodeIndex = currentNodeIndex;
                pic_Map.Invalidate();
                pic_Map.Refresh();
            }
        }

        

    }
}
