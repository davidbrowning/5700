using Microsoft.VisualStudio.TestTools.UnitTesting;

using BouncingBall;

namespace BouncingBallTesting
{

    [TestClass]
    public class BallTester
    {

        //[TestMethod]
        //public void Ball_SimpleMoveTest()
        //{
        //    Ball b = new Ball() {Radius = 10, X = 1, Y = 1, Direction = 67, Speed = 4, TimeUnit = 10};
        //    b.Move();


        //}




        [TestMethod]
        public void Ball_CheckMovement()
        {
            Box.Width = 20;
            Box.Height = 10;

            Ball b = new Ball() { X = 3, Y = 4, Radius = 2, Direction = 180, Speed=5 };
            PrivateObject b1 = new PrivateObject(b);
            Assert.AreEqual(3, (double) b1.GetFieldOrProperty("X"));
            Assert.AreEqual(4, (double) b1.GetFieldOrProperty("Y"));
            Assert.AreEqual(2, (double) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(180, (double) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (double) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] {null});
            Assert.AreEqual(6, (double) b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (double) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (double)b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(0, (double) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (double) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(11, (double)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (double) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (double) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(0, (double) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (double) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(16, (double)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (double) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (double) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(0, (double) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (double) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(15, (double)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (double) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (double) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(-180, (double) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (double) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(10, (double)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (double) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (double) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(-180, (double) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (double) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(5, (double)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (double) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (double) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(-180, (double) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (double) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(4, (double)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(4, (double) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (double) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(0, (double) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (double) b1.GetFieldOrProperty("Speed"));

            b1.SetFieldOrProperty("Direction", 90);

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(4, (double)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(7, (double) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (double) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(-90, (double) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (double) b1.GetFieldOrProperty("Speed"));

            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(4, (double)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(2, (double) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (double) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(-90, (double) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (double) b1.GetFieldOrProperty("Speed"));


            b1.Invoke("Move", new object[] { null });
            Assert.AreEqual(4, (double)b1.GetFieldOrProperty("X"), .001);
            Assert.AreEqual(7, (double) b1.GetFieldOrProperty("Y"), .001);
            Assert.AreEqual(2, (double) b1.GetFieldOrProperty("Radius"));
            Assert.AreEqual(90, (double) b1.GetFieldOrProperty("Direction"));
            Assert.AreEqual(5, (double) b1.GetFieldOrProperty("Speed"));
        }
    }
}
