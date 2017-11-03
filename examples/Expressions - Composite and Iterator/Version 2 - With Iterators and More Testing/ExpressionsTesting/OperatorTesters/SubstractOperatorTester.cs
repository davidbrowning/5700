using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions.Operators;

namespace ExpressionsTesting.FunctionTesters
{
    [TestClass]
    public class SubtractOperatorTester
    {
        [TestMethod]
        public void SubtractOperator_TestEverything()
        {
            SubtractOperator op = new SubtractOperator();
            Assert.AreEqual("-", op.ToString());
            Assert.AreEqual(-1, op.Execute(2, 3));
            Assert.AreEqual(0, op.Execute(0, 0));
            Assert.AreEqual(2, op.Execute(2, 0));
            Assert.AreEqual(-2, op.Execute(0, 2));
            Assert.AreEqual(1, op.Execute(-2, -3));
        }
    }
}
