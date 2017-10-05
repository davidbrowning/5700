using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using BouncingBall;

namespace BouncingBallTesting
{
    [TestClass]
    public class BallTester
    {
        [TestMethod]
        public void Ball_CheckMovement()
        {
            var myBox = new Box() { Width = 20, Height = 30 };

            var spec = new ShapeSpecification()
            {
                MyType = ShapeSpecification.ShapeType.Ball,
                X = 3,
                Y = 4,
                Size = 4,
                Direction = 180,
                Speed = 5
            };
            var b = Shape.Create(spec, myBox);
            Assert.IsNotNull(b);

            var b1 = new PrivateObject(b);

            Assert.AreEqual(3, b.X);
            Assert.AreEqual(4, b.Y);
            Assert.AreEqual(180, b.Direction);
            Assert.AreEqual(5, b.Speed);

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(6, b.X, .001);
            Assert.AreEqual(4, b.Y, .001);
            Assert.AreEqual(0, b.Direction);
            Assert.AreEqual(5, b.Speed);

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(11, b.X, .001);
            Assert.AreEqual(4, b.Y, .001);
            Assert.AreEqual(0, b.Direction);
            Assert.AreEqual(5, b.Speed);

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(16, b.X, .001);
            Assert.AreEqual(4, b.Y, .001);
            Assert.AreEqual(0, b.Direction);
            Assert.AreEqual(5, b.Speed);

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(15, b.X, .001);
            Assert.AreEqual(4, b.Y, .001);
            Assert.AreEqual(-180, b.Direction);
            Assert.AreEqual(5, b.Speed);

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(10, b.X, .001);
            Assert.AreEqual(4, b.Y, .001);
            Assert.AreEqual(-180, b.Direction);
            Assert.AreEqual(5, b.Speed);

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(5, b.X, .001);
            Assert.AreEqual(4, b.Y, .001);
            Assert.AreEqual(-180, b.Direction);
            Assert.AreEqual(5, b.Speed);

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(4, b.X, .001);
            Assert.AreEqual(4, b.Y, .001);
            Assert.AreEqual(0, b.Direction);
            Assert.AreEqual(5, b.Speed);

            b1.SetFieldOrProperty("Direction", 90);

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(4, b.X, .001);
            Assert.AreEqual(7, b.Y, .001);
            Assert.AreEqual(-90, b.Direction);
            Assert.AreEqual(5, b.Speed);

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(4, b.X, .001);
            Assert.AreEqual(2, b.Y, .001);
            Assert.AreEqual(-90, b.Direction);
            Assert.AreEqual(5, b.Speed);


            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(4, b.X, .001);
            Assert.AreEqual(7, b.Y, .001);
            Assert.AreEqual(90, b.Direction);
            Assert.AreEqual(5, b.Speed);

        }
    }
}
