using System;
using System.Drawing;

namespace BouncingBall
{
    public partial class GraphicalDisplay : BallObserver
    {
        public GraphicalDisplay()
        {
            InitializeComponent();
        }

        protected override void RefreshDisplay()
        {
            if (IsDisposed) return;

            Pen pen = new Pen(Color.Black);
            Graphics graphics = boxPanel.CreateGraphics();
            graphics.Clear(Color.White);

            foreach (Ball ball in BallsBeingObserved)
            {
                graphics.DrawEllipse(pen,
                    Convert.ToInt16(ball.X - ball.Radius),
                    Convert.ToInt32(ball.Y - ball.Radius),
                    Convert.ToInt32(ball.Radius * 2),
                    Convert.ToInt32(ball.Radius * 2));
            }
        }

        private void GraphicalDisplay_Load(object sender, EventArgs e)
        {
            Text = Title;
            StartRefreshTimer();
        }
    }
}
