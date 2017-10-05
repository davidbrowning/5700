using System.Drawing;

namespace BouncingBall
{
    public class Ball : Shape
    {
        private readonly Pen _pen = new Pen(Color.Black);
        public virtual float Radius => Size / 2;

        public override void Draw(Graphics graphics)
        {
            Brush brush = new SolidBrush(Color);

            float x = X - Radius;
            float y = MyBox.Height - Y - Radius;
            float width = Radius * 2;
            float height = Radius * 2;

            graphics.FillEllipse(brush, x, y, width, height);
            graphics.DrawEllipse(_pen, x, y, width, height);
        }

        public override float LeftBorder => Radius;
        public override float BottomBorder => Radius;
        public override float RightBorder => MyBox.Width - Radius;
        public override float TopBorder => MyBox.Height - Radius;
    }
}
