using System;
using System.Threading;
using Shapes;

namespace BouncingBall.Decorators
{
    public class SizeChangingDecorator : ShapeDecorator
    {
        private Timer _changeTimer;
        private float _maxSize;
        private float _minSize;
        private int _direction = 1;

        public int DeltaSize { get; set; }
        public int DelayBetweenChanges { get; set; }

        public override void Start()
        {
            if (DecoratedShape == null) return;

            base.Start();

            DeltaSize = Math.Abs(DeltaSize);
            _minSize = Math.Max(1, DecoratedShape.Size - DeltaSize);
            _maxSize = DecoratedShape.Size + DeltaSize;
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
            DecoratedShape.Size += _direction;

            if (DecoratedShape.Size > _maxSize)
            {
                DecoratedShape.Size = _maxSize;
                _direction = -1;
            }
            if (DecoratedShape.Size < _minSize)
            {
                DecoratedShape.Size = _minSize;
                _direction = 1;
            }
            Notify();
        }
    }
}
