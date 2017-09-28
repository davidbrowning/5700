using System;
using System.Threading;

namespace BouncingBall.Decorators
{
    public class SpeedChangingDecorator : BallDecorator
    {
        private Timer _changeTimer;
        private double _maxSpeed;
        private double _minSpeed;
        private int _direction = 1;

        public int DeltaSpeed { get; set; }
        public int DelayBetweenChanges { get; set; }

        public override void Start()
        {
            if (DecoratedBall == null) return;

            base.Start();

            DeltaSpeed = Math.Abs(DeltaSpeed);
            _minSpeed = Math.Max(1, DecoratedBall.Speed - DeltaSpeed);
            _maxSpeed = DecoratedBall.Speed + DeltaSpeed;

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
            DecoratedBall.Speed += _direction;

            if (DecoratedBall.Speed > _maxSpeed)
            {
                DecoratedBall.Speed = _maxSpeed;
                _direction = -1;
            }
            if (DecoratedBall.Speed < _minSpeed)
            {
                DecoratedBall.Speed = _minSpeed;
                _direction = 1;
            }
            Notify();
        }

    }
}
