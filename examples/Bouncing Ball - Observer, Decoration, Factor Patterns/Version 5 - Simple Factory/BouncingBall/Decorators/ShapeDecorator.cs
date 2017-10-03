using System.Drawing;

namespace BouncingBall.Decorators
{
    public class ShapeDecorator : Shape
    {
        public Shape DecoratedShape { get; set; }

        public override int Id => DecoratedShape.Id;
        public override float X
        {
            get { return DecoratedShape.X; }
            set { DecoratedShape.X = value; }
        }

        public override float Y
        {
            get { return DecoratedShape.Y; }
            set { DecoratedShape.Y = value; }
        }

        public override float Size
        {
            get { return DecoratedShape.Size; }
            set { DecoratedShape.Size = value; }
        }

        public override float Direction
        {
            get { return DecoratedShape.Direction; }
            set { DecoratedShape.Direction = value; }
        }

        public override float Speed
        {
            get { return DecoratedShape.Speed; }
            set { DecoratedShape.Speed = value; }
        }

        public override Color Color
        {
            get { return DecoratedShape.Color; }
            set { DecoratedShape.Color = value; }
        }

        public override void Draw(Graphics graphics)
        {
            DecoratedShape.Draw(graphics);
        }

        public override float LeftBorder => DecoratedShape.LeftBorder;
        public override float BottomBorder => DecoratedShape.BottomBorder;
        public override float RightBorder => DecoratedShape.RightBorder;
        public override float TopBorder => DecoratedShape.TopBorder;

        public override void Start()
        {
            DecoratedShape.Start();
        }

        public override void Stop()
        {
            DecoratedShape.Stop();
        }
    }
}
