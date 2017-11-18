using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions.Operators;

namespace ExpressionsTesting.FunctionTesters
{
    [TestClass]
    public class CeilingOperatorTester
    {
        [TestMethod]
        public void CeilingOperator_TestEverything()
        {
            CeilingOperator op = new CeilingOperator();
            Assert.AreEqual("\u2308", op.Label);
            Assert.AreEqual(2, op.Execute(1.6));
            Assert.AreEqual(-1, op.Execute(-1.6));
        }
    }
}
