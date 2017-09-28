using System;
using System.Threading;

namespace BouncingBall.Decorators
{
    public class SizeChangingDecorator : BallDecorator
    {
        private Timer _changeTimer;
        private double _maxSize;
        private double _minSize;
        private int _direction = 1;

        public int DeltaSize { get; set; }
        public int DelayBetweenChanges { get; set; }

        public override void Start()
        {
            if (DecoratedBall == null) return;

            base.Start();

            DeltaSize = Math.Abs(DeltaSize);
            _minSize = Math.Max(1, DecoratedBall.Radius - DeltaSize);
            _maxSize = DecoratedBall.Radius + DeltaSize;
            if (DelayBetweenChanges == 0)
                DelayBetweenChanges = 100;

            _changeTimer = new Timer(ChangeSize, null, DelayBetweenChanges, DelayBetweenChanges);
        }

        public override void Stop()
        {
            _changeTimer?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            _changeTimer = null;
            base.Stop();
        }

        private void ChangeSize(object sender)
        {
            DecoratedBall.Radius += _direction;

            if (DecoratedBall.Radius > _maxSize)
            {
                DecoratedBall.Radius = _maxSize;
                _direction = -1;
            }
            if (DecoratedBall.Radius < _minSize)
            {
                DecoratedBall.Radius = _minSize;
                _direction = 1;
            }
            Notify();
        }
    }
}
