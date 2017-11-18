﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions.Operators;

namespace ExpressionsTesting
{
    [TestClass]
    public class FloorOperatorTester
    {
        [TestMethod]
        public void FloorOperator_TestEverything()
        {
            FloorOperator op = new FloorOperator();
            Assert.AreEqual(0, op.Execute(0));
            Assert.AreEqual(1, op.Execute(1.6));
            Assert.AreEqual(-2, op.Execute(-1.6));

        }
    }
}
