using System;
using System.Drawing;
using System.Windows.Forms;
using Shapes;

namespace BouncingBall
{
    public partial class GraphicalDisplay : ShapeObserver
    {
        private readonly Brush _faderBrush = new SolidBrush(Color.FromArgb(50, 255, 255, 255));

        public GraphicalDisplay()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        public Box MyBox { get; set; }

        protected override void RefreshDisplay()
        {
            if (IsDisposed) return;


            Bitmap buf = new Bitmap(boxPanel.Width, boxPanel.Height);

            using (Graphics g = Graphics.FromImage(buf))
            {
                g.FillRectangle(_faderBrush, 0, 0, boxPanel.Width, boxPanel.Height);
                foreach (var shape in ShapesBeingObserved)
                    shape.Draw(g);

                boxPanel.CreateGraphics().DrawImageUnscaled(buf, 0, 0);
            }
        }

        private void GraphicalDisplay_Load(object sender, EventArgs e)
        {
            Text = Title;
            StartRefreshTimer();
            if (MyBox != null)
                boxPanel.Size = MyBox.BoxSize;
        }
    }
}
