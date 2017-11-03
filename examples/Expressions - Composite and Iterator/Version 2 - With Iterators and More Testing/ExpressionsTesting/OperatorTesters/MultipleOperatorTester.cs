using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions.Operators;

namespace ExpressionsTesting.FunctionTesters
{
    [TestClass]
    public class MultipleOperatorTester
    {
        [TestMethod]
        public void MultipleOperator_TestEverything()
        {
            MultipleOperator op = new MultipleOperator();
            Assert.AreEqual("*", op.Label);
            Assert.AreEqual(6, op.Execute(2, 3));
            Assert.AreEqual(0, op.Execute(0, 0));
            Assert.AreEqual(0, op.Execute(2, 0));
            Assert.AreEqual(0, op.Execute(0, 2));
            Assert.AreEqual(6, op.Execute(-2, -3));
        }
    }
}
