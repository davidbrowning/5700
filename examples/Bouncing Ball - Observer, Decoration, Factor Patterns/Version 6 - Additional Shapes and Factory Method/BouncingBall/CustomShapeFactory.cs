using BouncingBall.Decorators;
using Shapes;

namespace BouncingBall
{
    public class CustomShapeFactory : ShapeFactory
    {
        public override Shape Create(Specification specs)
        {
            Shape shape = base.Create(specs);

            CustomSpecification customSpecs = specs as CustomSpecification;
            if (customSpecs == null) return shape;
            
            if (customSpecs.ChangeSize)
                shape = new SizeChangingDecorator() { DecoratedShape = shape, DeltaSize = 10 };

            if (customSpecs.ChangeSpeed)
                shape = new SpeedChangingDecorator() { DecoratedShape = shape, DeltaSpeed = 6 };

            if (customSpecs.ChangeDirection)
                shape = new DirectionChangeDecorator() { DecoratedShape = shape, DeltaDegrees = 60 };

            if (customSpecs.ChangeColor)
                shape = new ColorChangingDecorator() { DecoratedShape = shape, AltColor = Shape.RandomColor };

            return shape;
        }


        public class CustomSpecification : ShapeFactory.Specification
        {
            public bool ChangeSize { get; set; }
            public bool ChangeSpeed { get; set; }
            public bool ChangeDirection { get; set; }
            public bool ChangeColor { get; set; }
        }
    }
}
