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


        private enum NodeType
        {
            Battle,
            Shop,
            Rest,
            Boss
        }
        private List<NodeType> nodeTypes = new List<NodeType>
        {
            NodeType.Battle,
            NodeType.Battle,
            NodeType.Rest,
            NodeType.Shop,
            NodeType.Battle,
            NodeType.Battle,
            NodeType.Rest,
            NodeType.Boss
        };

        private int currentNodeIndex = 0;

        //-------------------
        public MapForm()
        {
            InitializeComponent();


        }

        private void btn_StartMenuForm_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(new StartMenuForm());
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            GameManager.SwitchTo(new CharacterSelectForm());
        }

        private Brush GetNodeColor(NodeType type)
        {
            switch (type)
            {
                case NodeType.Battle: return Brushes.LightGray;
                case NodeType.Shop: return Brushes.Pink;
                case NodeType.Rest: return Brushes.LightBlue;
                case NodeType.Boss: return Brushes.DarkRed;
                default: return Brushes.LightGray;
            }
        }


        private void DrawMap(Graphics g)
        {
            //this is just to make the circles look smoth on the drawing
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            //length of the game
            int nodeCount = nodeTypes.Count;
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

                Brush fillBrush = GetNodeColor(nodeTypes[i]);
                //draw node
                g.FillEllipse(fillBrush, nodeRect);
                g.DrawEllipse(Pens.Black, nodeRect);

            }
            //player position marker(on node 0)
            int playerX = margin + currentNodeIndex * spacing;
            g.FillEllipse(Brushes.Red, playerX - markerSize / 2, centerY - nodeSize, markerSize, markerSize);
        }

        private void pic_Map_Paint(object sender, PaintEventArgs e)
        {
            DrawMap(e.Graphics);
        }

        //move foward to next node
        private void btn_Continue_Click(object sender, EventArgs e)
        {
            if (currentNodeIndex >= nodeTypes.Count - 1)
            {
                return;
            }
            //next node index
            int nextNode = currentNodeIndex + 1;

            //detect node type
            NodeType type = nodeTypes[nextNode];

            switch (type)
            {
                //case NodeType.Battle:
                //GameManager.SwitchTo(new BattleForm)
                //break;

                case NodeType.Shop:
                    GameManager.SwitchTo(new ShopForm());
                    break;

                    //If we want a different form for boss battle goes here in other switch 
                    //and also we can do a new form to summarize or show the healing in the rest node
            }

            currentNodeIndex = nextNode;
            pic_Map.Invalidate();
        }

        //move to the previous node
        private void btn_PreviousNode_Click(object sender, EventArgs e)
        {
            if (currentNodeIndex > 0)
            {
                currentNodeIndex--;
                pic_Map.Invalidate();
            }
        }

        

    }
}
