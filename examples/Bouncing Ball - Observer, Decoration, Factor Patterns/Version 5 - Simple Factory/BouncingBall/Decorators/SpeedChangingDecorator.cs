using System;
using System.Threading;

namespace BouncingBall.Decorators
{
    public class SpeedChangingDecorator : ShapeDecorator
    {
        private Timer _changeTimer;
        private float _maxSpeed;
        private float _minSpeed;
        private int _direction = 1;

        public int DeltaSpeed { get; set; }
        public int DelayBetweenChanges { get; set; }

        public override void Start()
        {
            if (DecoratedShape == null) return;

            base.Start();

            DeltaSpeed = Math.Abs(DeltaSpeed);
            _minSpeed = Math.Max(1, DecoratedShape.Speed - DeltaSpeed);
            _maxSpeed = DecoratedShape.Speed + DeltaSpeed;

            if (DelayBetweenChanges == 0)
                DelayBetweenChanges = 250;

            _changeTimer = new Timer(ChangeSpeed, null, DelayBetweenChanges, DelayBetweenChanges);
        }

        public override void Stop()
        {
            _changeTimer?.Change(Timeout.InfiniteTimeSpan, Timeout.InfiniteTimeSpan);
            _changeTimer = null;
            base.Stop();
        }

        private void ChangeSpeed(object sender)
        {
            DecoratedShape.Speed += _direction;

            if (DecoratedShape.Speed > _maxSpeed)
            {
                DecoratedShape.Speed = _maxSpeed;
                _direction = -1;
            }
            if (DecoratedShape.Speed < _minSpeed)
            {
                DecoratedShape.Speed = _minSpeed;
                _direction = 1;
            }
            Notify();
        }

    }
}
