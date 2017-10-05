using System;
using System.Globalization;
using System.Windows.Forms;

using Shapes;

namespace BouncingBall
{
    public partial class ListDisplay : ShapeObserver
    {
        public ListDisplay()
        {
            InitializeComponent();
        }

        protected override void RefreshDisplay()
        {
            shapeListView.Items.Clear();
            foreach (var ball in ShapesBeingObserved)
            {
                ListViewItem item = new ListViewItem(new []
                                                {
                                                    ball.X.ToString("F1"),
                                                    ball.Y.ToString("F1"),
                                                    ball.Size.ToString(CultureInfo.InvariantCulture),
                                                    ball.Direction.ToString(CultureInfo.InvariantCulture),
                                                    ball.Speed.ToString(CultureInfo.InvariantCulture),
                                                    ball.StateChanges.ToString()
                                                });
                shapeListView.Items.Add(item);
            }
        }

        private void ListDisplay_Load(object sender, EventArgs e)
        {
            Text = Title;
            StartRefreshTimer();
        }

    }
}
