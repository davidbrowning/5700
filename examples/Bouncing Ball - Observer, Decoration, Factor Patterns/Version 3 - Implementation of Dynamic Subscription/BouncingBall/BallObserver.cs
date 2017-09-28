using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BouncingBall
{
    public class BallObserver : Form
    {
        private readonly Dictionary<Int32, Ball> _ballsBeingObserved = new Dictionary<int,Ball>();

        protected bool RepaintNeeded = false;
        private readonly Timer _refreshTester = new Timer();
        private readonly object _myLock = new object();

        public int RefreshFrequency { get; set; }
        public string Title { get; set; }

        public virtual void Update(Subject subject)
        {
            Ball ball = subject as Ball;
            if (ball != null)
            {
                lock (_myLock)
                {
                    if (!_ballsBeingObserved.ContainsKey(ball.Id))
                        _ballsBeingObserved.Add(ball.Id, ball);
                    else
                        _ballsBeingObserved[ball.Id] = ball;
                }

                RepaintNeeded = true;
            }
        }

        protected void StartRefreshTimer()
        {
            if (RefreshFrequency <= 0)
                RefreshFrequency = 50;

            _refreshTester.Interval = RefreshFrequency;
            _refreshTester.Tick += refreshTimer_Tick;
            _refreshTester.Start();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (RepaintNeeded)
            {
                lock (_myLock)
                {
                    RefreshDisplay();
                    RepaintNeeded = false;
                }
            }
        }

        protected virtual void RefreshDisplay() { }

        protected void UnregisterFromAllSubjects()
        {
            Dictionary<Int32, Ball>.Enumerator iterator = _ballsBeingObserved.GetEnumerator();
            while (iterator.MoveNext())
                iterator.Current.Value.Unsubscribe(this);
        }

        protected List<Ball> BallsBeingObserved { get { return _ballsBeingObserved.Values.ToList(); } }
    }
}
