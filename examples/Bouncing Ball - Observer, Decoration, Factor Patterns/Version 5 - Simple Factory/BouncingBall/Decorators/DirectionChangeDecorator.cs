using System;
using System.Threading;

namespace BouncingBall.Decorators
{
    public class DirectionChangeDecorator : ShapeDecorator
    {
        private Timer _changeTimer;
        private int _direction = 1;
        private int _changeCount;

        public int DeltaDegrees { get; set; }
        public int DelayBetweenChanges { get; set; }

        public override void Start()
        {
            if (DecoratedShape == null) return;

            base.Start();

            DeltaDegrees = Math.Abs(DeltaDegrees);
            if (DelayBetweenChanges == 0)
                DelayBetweenChanges = 40;

            _changeTimer = new Timer(ChangeDirection, null, DelayBetweenChanges, DelayBetweenChanges);
        }

        public override void Stop()
        {
            _changeTimer?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            _changeTimer = null;
            base.Stop();
        }

        private void ChangeDirection(object sender)
        {
            DecoratedShape.Direction += _direction;
            _changeCount++;

            if (_changeCount > DeltaDegrees)
            {
                _changeCount = 0;
                _direction = -_direction;
            }
            Notify();
        }

    }
}
