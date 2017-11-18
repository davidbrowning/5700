using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions;
using Expressions.Functions;

namespace ExpressionsTesting.FunctionTesters
{
    [TestClass]
    public class BigSlowFunctionTester
    {
        [TestMethod]
        public void BigSlowFunction_TestEverything()
        {
            BigSlowFunction f = new BigSlowFunction();

            Assert.AreEqual(0, f.Execute(null));
            Assert.AreEqual(0, f.GetEstimatedTime(null));
            Assert.AreEqual(0, f.GetEstimatedValue(null));

            List<double> p = new List<double>();
            double r = f.Execute(p);
            Assert.IsTrue(r >= 0 && r < 1);
            Assert.AreEqual(1, f.GetEstimatedTime(p));
            Assert.AreEqual(0.5, f.GetEstimatedValue(p));

            p = new List<double>() { 10 };
            r = f.Execute(p);
            Assert.IsTrue(r>=0 && r<10);
            Assert.AreEqual(11, f.GetEstimatedTime(p));
            Assert.AreEqual(5.5, f.GetEstimatedValue(p));

            p = new List<double>() { 10, 20 };
            r = f.Execute(p);
            Assert.IsTrue(r >= 0 && r < 211);
            Assert.AreEqual(211, f.GetEstimatedTime(p));
            Assert.AreEqual(105.5, f.GetEstimatedValue(p));

            p = new List<double>() { 10, 20, 30 };
            r = f.Execute(p);
            Assert.IsTrue(r >= 0 && r < 6301);
            Assert.AreEqual(6211, f.GetEstimatedTime(p));
            Assert.AreEqual(3105.5, f.GetEstimatedValue(p));

        }
    }
}
