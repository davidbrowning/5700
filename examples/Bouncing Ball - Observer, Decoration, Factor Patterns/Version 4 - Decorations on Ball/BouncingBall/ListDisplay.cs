using System;
using System.Globalization;
using System.Windows.Forms;

namespace BouncingBall
{
    public partial class ListDisplay : BallObserver
    {
        public ListDisplay()
        {
            InitializeComponent();
        }

        protected override void RefreshDisplay()
        {
            ballListView.Items.Clear();
            foreach (Ball ball in BallsBeingObserved)
            {
                ListViewItem item = new ListViewItem(new []
                                                {
                                                    ball.X.ToString("F1"),
                                                    ball.Y.ToString("F1"),
                                                    ball.Radius.ToString(CultureInfo.InvariantCulture),
                                                    ball.Direction.ToString(CultureInfo.InvariantCulture),
                                                    ball.Speed.ToString(CultureInfo.InvariantCulture),
                                                    ball.StateChanges.ToString()
                                                });
                ballListView.Items.Add(item);
            }
        }

        private void ListDisplay_Load(object sender, EventArgs e)
        {
            Text = Title;
            StartRefreshTimer();
        }
    }
}
