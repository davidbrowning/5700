using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions;

namespace ExpressionsTesting
{
    [TestClass]
    public class VariableTester
    {
        [TestMethod]
        public void Variable_TestLabel()
        {
            // Case 1 - Test valid 1-character label
            Variable v1 = new Variable() { Label = "A" };
            Assert.AreEqual("A", v1.Label);

            // Case 2 - Test valid 2-character label
            v1 = new Variable() { Label = "aA" };
            Assert.AreEqual("aA", v1.Label);

            // Case 3 - Test valid 2-character label
            v1 = new Variable() { Label = "_1" };
            Assert.AreEqual("_1", v1.Label);

            // Case 4 - Test valid 4-character label
            v1 = new Variable() { Label = "AA_1" };
            Assert.AreEqual("AA_1", v1.Label);

            // Case 5 - Test null label
            v1 = new Variable() { Label = null };
            Assert.AreEqual(string.Empty, v1.Label);

            // Case 6 - Test string.empty label
            v1 = new Variable() { Label = string.Empty };
            Assert.AreEqual(string.Empty, v1.Label);

            // Case 6 - Test string.empty label
            v1 = new Variable() { Label = "A\n" };
            Assert.AreEqual("A", v1.Label);

            // Case 6 - Test numeric only label
            try
            {
                v1 = new Variable() { Label = "11" };
                Assert.Fail("Expected exception not thrown");
            }
            catch { }

            // Case 6 - Test illegal symbol label
            try
            {
                v1 = new Variable() { Label = "$" };
                Assert.Fail("Expected exception not thrown");
            }
            catch { }

            // Case 6 - Test embedded newline label
            try
            {
                v1 = new Variable() { Label = "A\nB" };
                Assert.Fail("Expected exception not thrown");
            }
            catch { }

        }

        [TestMethod]
        public void Variable_TestEvaluate()
        {
            Variable v1 = new Variable() { Label = "A" };
            Interpretation i = new Interpretation();
            i[v1] = 10;

            Assert.AreEqual(10, v1.Evaluate(i));
            Assert.AreEqual(0, v1.Evaluate(null));

        }
    }
}
