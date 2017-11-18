using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions.Operators;

namespace ExpressionsTesting.FunctionTesters
{
    [TestClass]
    public class AddOperatorTester
    {
        [TestMethod]
        public void AddOperator_TestEverything()
        {
            AddOperator op = new AddOperator();
            Assert.AreEqual("+", op.Label);
            Assert.AreEqual(5, op.Execute(2, 3));
            Assert.AreEqual(0, op.Execute(0, 0));
            Assert.AreEqual(2, op.Execute(2, 0));
            Assert.AreEqual(2, op.Execute(0, 2));
            Assert.AreEqual(-5, op.Execute(-2, -3));
        }
    }
}
