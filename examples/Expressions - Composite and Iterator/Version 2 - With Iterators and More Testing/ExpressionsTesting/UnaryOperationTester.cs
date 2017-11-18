using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions;
using Expressions.Operators;

namespace ExpressionsTesting
{
    [TestClass]
    public class UnaryOperationTester
    {
        [TestMethod]
        public void UnaryOperator_TestEverything()
        {
            // Case 1 - A basic unary expression of a constant

            UnaryOperation exp = new UnaryOperation()
            {
                Operand = new Constant() { Value = 12.34 },
                Operator = new FloorOperator()
            };
            Interpretation i = new Interpretation();

            Assert.AreEqual(12, exp.Evaluate(i));
            Assert.AreEqual(1, exp.EstimateTime(i));
            Assert.AreEqual(12.34, exp.EstimateValue(i));
            Assert.AreEqual("\u230A 12.34", exp.PrefixNotation);
            Assert.AreEqual("(\u230A 12.34)", exp.InfixNotation);
            Assert.AreEqual("12.34 \u230A", exp.PostfixNotation);
            Expression optimized = exp.OptimizedExpression;
            Assert.IsTrue(optimized is Constant);
            Assert.AreEqual(12, (optimized as Constant).Value);

            // Case 2 - A basic unary expression of a variable

            Variable a = new Variable() { Label = "a" };
            exp = new UnaryOperation()
            {
                Operand = a,
                Operator = new CeilingOperator()
            };
            i[a] = 23.45;

            Assert.AreEqual(24, exp.Evaluate(i));
            Assert.AreEqual(2, exp.EstimateTime(i));
            Assert.AreEqual(23.45, exp.EstimateValue(i));
            Assert.AreEqual("\u2308 a", exp.PrefixNotation);
            Assert.AreEqual("(\u2308 a)", exp.InfixNotation);
            Assert.AreEqual("a \u2308", exp.PostfixNotation);
            optimized = exp.OptimizedExpression;
            Assert.IsTrue(optimized is UnaryOperation);
            Assert.IsTrue((optimized as UnaryOperation).Operator is CeilingOperator);
            Assert.IsTrue((optimized as UnaryOperation).Operand is Variable);
            Assert.AreEqual("a", ((optimized as UnaryOperation).Operand as Variable).Label);

            // Case 3 - A ill-formed with no Operand
            exp = new UnaryOperation()
            {
                Operator = new CeilingOperator()
            };

            Assert.AreEqual(0, exp.Evaluate(i));
            Assert.AreEqual(1, exp.EstimateTime(i));
            Assert.AreEqual(0, exp.EstimateValue(i));

            try
            {
                string tmp = exp.PrefixNotation;
                Assert.Fail("Expected exceptation not throw");
            }
            catch { }

            try
            {
                string tmp = exp.InfixNotation;
                Assert.Fail("Expected exceptation not throw");
            }
            catch { }

            try
            {
                string tmp = exp.PostfixNotation;
                Assert.Fail("Expected exceptation not throw");
            }
            catch { }

            try
            {
                Expression tmp = exp.OptimizedExpression;
                Assert.Fail("Expected exceptation not throw");
            }
            catch { }

            // Case 4 - A ill-formed with no Operator
            exp = new UnaryOperation()
            {
                Operand = a
            };

            Assert.AreEqual(0, exp.Evaluate(i));
            Assert.AreEqual(1, exp.EstimateTime(i));
            Assert.AreEqual(0, exp.EstimateValue(i));

            try
            {
                string tmp = exp.PrefixNotation;
                Assert.Fail("Expected exceptation not throw");
            }
            catch { }

            try
            {
                string tmp = exp.InfixNotation;
                Assert.Fail("Expected exceptation not throw");
            }
            catch { }

            try
            {
                string tmp = exp.PostfixNotation;
                Assert.Fail("Expected exceptation not throw");
            }
            catch { }

            try
            {
                Expression tmp = exp.OptimizedExpression;
                Assert.Fail("Expected exceptation not throw");
            }
            catch { }

        }

    }
}
