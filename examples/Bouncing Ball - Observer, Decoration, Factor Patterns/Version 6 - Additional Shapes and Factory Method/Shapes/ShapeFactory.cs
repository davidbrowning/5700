namespace Shapes
{
    public class ShapeFactory
    {
        public virtual Shape Create(Specification specs)
        {
            Shape shape = null;
            switch (specs.MyType)
            {
                case Specification.ShapeType.Ball:
                    shape = new Ball();
                    break;
                case Specification.ShapeType.Square:
                    shape = new Square();
                    break;
                case Specification.ShapeType.Triangle:
                    shape = new Triangle();
                    break;
            }
            if (shape != null)
                shape.MyBox = BoxContainingCreatedShapes;

            return shape;
        }
        public Box BoxContainingCreatedShapes { get; set; }

        public class Specification
        {
            public enum ShapeType { Ball, Square, Triangle }
            public ShapeType MyType { get; set; }
        }
    }
}
