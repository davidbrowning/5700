using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BouncingBall
{
    public class ShapeObserver : Form
    {
        private readonly Dictionary<Int32, Shape> _shapeBeingObserved = new Dictionary<int, Shape>();

        protected bool RepaintNeeded;
        private readonly Timer _refreshTester = new Timer();
        private readonly object _myLock = new object();

        public int RefreshFrequency { get; set; }
        public string Title { get; set; }

        public virtual void Update(Subject subject)
        {
            var shape = subject as Shape;
            if (shape != null)
            {
                lock (_myLock)
                {
                    if (!_shapeBeingObserved.ContainsKey(shape.Id))
                        _shapeBeingObserved.Add(shape.Id, shape);
                    else
                        _shapeBeingObserved[shape.Id] = shape;
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
            Dictionary<Int32, Shape>.Enumerator iterator = _shapeBeingObserved.GetEnumerator();
            while (iterator.MoveNext())
                iterator.Current.Value.Unsubscribe(this);
        }

        protected List<Shape> ShapesBeingObserved => _shapeBeingObserved.Values.ToList();
    }
}
