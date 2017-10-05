using System.Drawing;

namespace BouncingBall
{
    public class Triangle : Shape
    {
        private readonly Pen _pen = new Pen(Color.Black);

        private float _circumscribedCircleRadius;
        private float _inscribedCircleRadius;
        private readonly PointF[] _vertices = new PointF[3];

        public float EdgeLength => Size;

        public override void Draw(Graphics graphics)
        {
            Brush brush = new SolidBrush(Color);

            _circumscribedCircleRadius = Size * 0.577350F;
            _inscribedCircleRadius = _circumscribedCircleRadius / 2;
            _vertices[0] = new PointF(X, Y + _circumscribedCircleRadius);
            _vertices[1] = new PointF(X - EdgeLength / 2, Y - _inscribedCircleRadius);
            _vertices[2] = new PointF(X + EdgeLength / 2, Y - _inscribedCircleRadius);

            graphics.FillPolygon(brush, _vertices);
            graphics.DrawPolygon(_pen, _vertices);
        }

        public override float LeftBorder => EdgeLength / 2;
        public override float BottomBorder => _inscribedCircleRadius;
        public override float RightBorder => MyBox.Width - EdgeLength / 2;
        public override float TopBorder => MyBox.Height - _circumscribedCircleRadius;
    }
}
