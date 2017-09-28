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
                Brush brush = new SolidBrush(ball.Color);

                float x = Convert.ToSingle(ball.X - ball.Radius);
                float y = Convert.ToSingle(ball.Y - ball.Radius);
                float width = Convert.ToSingle(ball.Radius*2);
                float height = Convert.ToSingle(ball.Radius*2);

                graphics.FillEllipse(brush, x, y, width, height);
                graphics.DrawEllipse(pen, x, y, width, height);
            }
        }

        private void GraphicalDisplay_Load(object sender, EventArgs e)
        {
            Text = Title;
            StartRefreshTimer();
        }
    }
}
