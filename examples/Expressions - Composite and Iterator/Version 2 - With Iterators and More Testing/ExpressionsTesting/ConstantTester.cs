using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions;

namespace ExpressionsTesting
{
    [TestClass]
    public class ConstantTester
    {
        [TestMethod]
        public void Constant_TestEverything()
        {
            Interpretation interpretation = new Interpretation();

            // Check initial state
            Constant c1 = new Constant();
            Assert.AreEqual(0, c1.Value);
            Assert.AreEqual(0, c1.Evaluate(interpretation));
            Assert.AreEqual(0, c1.EstimateTime(interpretation));
            Assert.AreEqual(0, c1.EstimateValue(interpretation));
            Assert.AreEqual("0", c1.PrefixNotation);
            Assert.AreEqual("0", c1.InfixNotation);
            Assert.AreEqual("0", c1.PostfixNotation);

            // Check initial state
            c1.Value = 1.23;
            Assert.AreEqual(1.23, c1.Value);
            Assert.AreEqual(1.23, c1.Evaluate(interpretation));
            Assert.AreEqual(0, c1.EstimateTime(interpretation));
            Assert.AreEqual(1.23, c1.EstimateValue(interpretation));
            Assert.AreEqual("1.23", c1.PrefixNotation);
            Assert.AreEqual("1.23", c1.InfixNotation);
            Assert.AreEqual("1.23", c1.PostfixNotation);
        }

    }
}
