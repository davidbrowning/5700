using System.Drawing;

namespace Shapes
{
    public class Square : Shape
    {
        private readonly Pen _pen = new Pen(Color.Black);

        public float Width => Size;

        public override void Draw(Graphics graphics)
        {
            Brush brush = new SolidBrush(Color);

            float x = X - Width/2;
            float y = MyBox.Height - Y - Width / 2;

            graphics.FillRectangle(brush, x, y, Width, Width);
            graphics.DrawRectangle(_pen, x, y, Width, Width);
        }

        public override float LeftBorder => Width / 2;
        public override float BottomBorder => Width / 2;
        public override float RightBorder => MyBox.Width - Width / 2;
        public override float TopBorder => MyBox.Height - Width / 2;
    }
}
