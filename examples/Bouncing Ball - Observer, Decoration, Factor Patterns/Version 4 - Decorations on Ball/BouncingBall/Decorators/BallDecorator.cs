using System.Drawing;

namespace BouncingBall.Decorators
{
    public class BallDecorator : Ball
    {
        public Ball DecoratedBall { get; set; }
        public override int Id => DecoratedBall.Id;     // This BallDecorator object has the same Id and the ball object it wraps

        // This BallDecorator should delegate all public properties and methods of Ball to the ball object it wraps
        public override double X {
            get { return DecoratedBall.X; }
            set { DecoratedBall.X = value; }
        }

        public override double Y
        {
            get { return DecoratedBall.Y; }
            set { DecoratedBall.Y = value; }
        }

        public override double Radius
        {
            get { return DecoratedBall.Radius; }
            set { DecoratedBall.Radius = value; }
        }

        public override double Direction
        {
            get { return DecoratedBall.Direction;  }
            set { DecoratedBall.Direction = value; }            
        }

        public override double Speed
        {
            get { return DecoratedBall.Speed; }
            set { DecoratedBall.Speed = value; }
        }

        public override Color Color
        {
            get { return DecoratedBall.Color; }
            set { DecoratedBall.Color = value; }
        }

        public override void Start()
        {
            DecoratedBall.Start();
        }

        public override void Stop()
        {
            DecoratedBall.Stop();
        }
    }
}
