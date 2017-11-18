using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions;
using Expressions.Functions;

namespace ExpressionsTesting.FunctionTesters
{
    /// <summary>
    /// MockFunction
    /// 
    /// To test Function, since it is an abstract class, we create a mock specialization of
    /// Function and test using that mock.
    /// </summary>
    public class MockFunction : Function
    {
        public override double Execute(System.Collections.Generic.List<double> parameters)
        {
            return 1;
        }

        public override double GetEstimatedTime(System.Collections.Generic.List<double> parameters)
        {
            return 2;
        }

        public override double GetEstimatedValue(System.Collections.Generic.List<double> parameters)
        {
            return 3;
        }
    }

    [TestClass]
    public class FunctionTester
    {
        [TestMethod]
        public void Function_TestEverything()
        {
            List<double> parameters = new List<double>();

            MockFunction f1 = new MockFunction() { Label = "Test" };
            Assert.AreEqual("Test", f1.Label);
            Assert.AreEqual(1, f1.Execute(parameters));
            Assert.AreEqual(2, f1.GetEstimatedTime(parameters));
            Assert.AreEqual(3, f1.GetEstimatedValue(parameters));
        }
    }
}
