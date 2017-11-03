using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions;
using Expressions.Functions;

namespace ExpressionsTesting.FunctionTesters
{
    [TestClass]
    public class RoundFunctionTester
    {
        [TestMethod]
        public void RoundFunction_TestExecute()
        {
            RoundFunction rf = new RoundFunction();
            Assert.AreEqual(0, rf.Execute(null));
            Assert.AreEqual(0, rf.Execute(new List<double>()));
            Assert.AreEqual(0, rf.Execute(new List<double>() { 1.0, 3.3 }));
            Assert.AreEqual(1, rf.Execute(new List<double>() { 1.2 }));
            Assert.AreEqual(2, rf.Execute(new List<double>() { 1.6 }));

        }
    }
}
