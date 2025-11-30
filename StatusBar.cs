using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceBattleGame
{
    public partial class StatusBar : UserControl
    {
        private Graphics graphics;
        public float maxValue = 100f;
        public float currentValue = 100f;

        // default constructor
        public StatusBar()
        {
            InitializeComponent();

            this.graphics = this.CreateGraphics();

        }

        public StatusBar(float max)
        {
            InitializeComponent();
            this.graphics = this.CreateGraphics();
            this.maxValue = max;
        }

        public void UpdateValue(float value)
        {
            this.currentValue += value;
            graphics.Clear(Pens.Gray.Color);
            float percentage = currentValue / maxValue;
            graphics.FillRectangle(Brushes.Green, 0, 0, this.Width * percentage, this.Height);
        }

        public void SetCurrentValue(float value)
        {
            this.currentValue = value;
            graphics.Clear(Pens.Gray.Color);
            float percentage = currentValue / maxValue;
            graphics.FillRectangle(Brushes.Green, 0, 0, this.Width * percentage, this.Height);
        }


        // initial draw
        protected override void OnPaint(PaintEventArgs e)
        {
            
            UpdateValue(0f);
        }

    }
}
