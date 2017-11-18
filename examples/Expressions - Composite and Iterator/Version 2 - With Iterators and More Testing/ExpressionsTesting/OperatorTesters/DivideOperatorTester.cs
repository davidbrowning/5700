using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions.Operators;

namespace ExpressionsTesting.FunctionTesters
{
    [TestClass]
    public class DivideOperatorTester
    {
        [TestMethod]
        public void DivideOperator_TestEverything()
        {
            DivideOperator op = new DivideOperator();
            Assert.AreEqual("/", op.Label);
            Assert.AreEqual(2, op.Execute(6, 3));
            Assert.AreEqual(0, op.Execute(0, 2));
            Assert.AreEqual(0.5, op.Execute(-2, -4));

            try
            {
                op.Execute(3, 0);
                Assert.Fail("Expected exception not thrown");
            }
            catch { }

        }
    }
}
