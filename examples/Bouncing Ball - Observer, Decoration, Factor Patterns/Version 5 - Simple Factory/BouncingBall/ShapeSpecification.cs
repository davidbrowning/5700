using System.Drawing;

namespace BouncingBall
{
    public class ShapeSpecification
    {
        public enum ShapeType { Ball, Square, Triangle }
        public ShapeType MyType { get; set; }

        public virtual float X { get; set; }
        public virtual float Y { get; set; }
        public virtual float Direction { get; set; }
        public virtual float Speed { get; set; }
        public virtual float Size { get; set; }
        public virtual Color Color { get; set; } = Color.Transparent;
    }
}
