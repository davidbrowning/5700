using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace BouncingBall
{
    public partial class ControlForm : Form
    {
        // Data members to track known balls and obversers for UI. These are outside the observer pattern
        private readonly List<Ball> _knownBalls = new List<Ball>();
        private readonly List<BallObserver> _knownDisplays = new List<BallObserver>();
        private BallObserver _selectedObserver;

        public ControlForm()
        {
            InitializeComponent();
        }

        private void RefreshObversersListView()
        {
            observersListView.Items.Clear();
            foreach (BallObserver observer in _knownDisplays)
            {
                ListViewItem item = new ListViewItem(observer.Title);
                observersListView.Items.Add(item);
            }
        }

        private void RefreshBallLists()
        {
            observedBallsListView.Items.Clear();
            otherBallsListView.Items.Clear();

            if (_selectedObserver != null)
                observedBallsLabel.Text = @"Subjects of " + _selectedObserver.Title;
            else
                observedBallsLabel.Text = @"No obverser selected";

            foreach (Ball ball in _knownBalls)
            {
                var item = new ListViewItem(new[]
                {
                    ball.Id.ToString(),
                    ball.Radius.ToString(CultureInfo.InvariantCulture),
                    ball.Speed.ToString(CultureInfo.InvariantCulture)
                }) {Tag = ball};
                if (_selectedObserver != null && ball.Subscribers.Contains(_selectedObserver))
                    observedBallsListView.Items.Add(item);
                else
                    otherBallsListView.Items.Add(item);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void observersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (observersListView.SelectedIndices.Count == 1)
            {
                    _selectedObserver = _knownDisplays[observersListView.SelectedIndices[0]];
                    unscribeButton.Enabled = true;
                    subscribeButton.Enabled = true;
            }
            else
            {
                _selectedObserver = null;
                unscribeButton.Enabled = true;
                subscribeButton.Enabled = true;
            }

            RefreshBallLists();
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            RefreshObversersListView();
            RefreshBallLists();
        }

        private void subscribeButton_Click(object sender, EventArgs e)
        {
            if (_selectedObserver != null)
            {
                foreach (ListViewItem item in otherBallsListView.SelectedItems)
                {
                    Subject subject = item.Tag as Subject;
                    subject?.Subscribe(_selectedObserver);
                }
                RefreshBallLists();
            }
        }

        private void unscribeButton_Click(object sender, EventArgs e)
        {
            if (_selectedObserver != null)
            {
                foreach (ListViewItem item in observedBallsListView.SelectedItems)
                {
                    Subject subject = item.Tag as Subject;
                    subject?.Unsubscribe(_selectedObserver);
                }
                RefreshBallLists();
            }
        }

        private void createBallButton_Click(object sender, EventArgs e)
        {
            Ball ball = new Ball();
            ball.Start();
            _knownBalls.Add(ball);

            RefreshBallLists();
        }

        private void createObserverButton_Click(object sender, EventArgs e)
        {
            var modalDialogForm = new ObserverCreationForm
            {
                Text = @"New Observer",
                ObserverTitle = $"Observer #{_knownDisplays.Count + 1}"
            };
            if (modalDialogForm.ShowDialog() == DialogResult.OK)
            {
                BallObserver observer;
                if (modalDialogForm.ObserverType == "L")
                    observer = new ListDisplay();
                else
                    observer = new GraphicalDisplay();
                observer.Title = modalDialogForm.ObserverTitle;
                _knownDisplays.Add(observer);
                observer.Show();

                _selectedObserver = null;
                observersListView.SelectedIndices.Clear();
                RefreshObversersListView();
                RefreshBallLists();
            }

        }
    }
}
