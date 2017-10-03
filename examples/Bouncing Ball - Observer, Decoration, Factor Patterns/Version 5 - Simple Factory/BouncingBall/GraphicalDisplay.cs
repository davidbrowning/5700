using System;
using System.Drawing;

namespace BouncingBall
{
    public partial class GraphicalDisplay : ShapeObserver
    {
        public GraphicalDisplay()
        {
            InitializeComponent();
        }

        protected override void RefreshDisplay()
        {
            if (IsDisposed) return;


            Bitmap buf = new Bitmap(boxPanel.Width, boxPanel.Height);

            using (Graphics g = Graphics.FromImage(buf))
            {
                g.Clear(Color.White);
                foreach (var shape in ShapesBeingObserved)
                    shape.Draw(g);

                boxPanel.CreateGraphics().DrawImageUnscaled(buf, 0, 0);
            }
        }

        private void GraphicalDisplay_Load(object sender, EventArgs e)
        {
            Text = Title;
            StartRefreshTimer();
        }
    }
}
