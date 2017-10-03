using Microsoft.VisualStudio.TestTools.UnitTesting;

using Shapes;

namespace BouncingBallTesting
{
    [TestClass]
    public class BallTester
    {
        [TestMethod]
        public void Ball_CheckMovement()
        {
            Box myBox = new Box() {Width = 20, Height = 10 };

            Shape b = new Ball() { MyBox = myBox, X = 3, Y = 4, Size = 4, Direction = 180, Speed=5 };
            PrivateObject b1 = new PrivateObject(b);
            Assert.AreEqual(3, (float) b1.GetFieldOrProperty("X"));
            Assert.AreEqual(4, (float) b1.GetFieldOrProperty("Y"));
            Assert.AreEqual(2, (float) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(180, (float) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (float) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] {null});
            Assert.AreEqual(6, (float) b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (float) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (float)b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(0, (float) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (float) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(11, (float)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (float) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (float) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(0, (float) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (float) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(16, (float)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (float) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (float) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(0, (float) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (float) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(15, (float)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (float) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (float) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(-180, (float) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (float) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(10, (float)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (float) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (float) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(-180, (float) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (float) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(5, (float)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (float) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (float) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(-180, (float) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (float) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(4, (float)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (float) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (float) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(0, (float) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (float) b1.GetFieldOrProperty("Speed"));

            b1.SetFieldOrProperty("Direction", 90);

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(4, (float)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(7, (float) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (float) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(-90, (float) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (float) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(4, (float)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(2, (float) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (float) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(-90, (float) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (float) b1.GetFieldOrProperty("Speed"));


            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(4, (float)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(7, (float) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (float) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(90, (float) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (float) b1.GetFieldOrProperty("Speed"));
        }
    }
}
