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

            var exp = new UnaryExpression()
            {
                Operand = new Constant() { Value = 12.34 },
                Operator = new FloorOperator()
            };
            var i = new Interpretation();

            Assert.AreEqual(12, exp.Evaluate(i));

            // Case 2 - A basic unary expression of a variable

            var a = new Variable() { Label = "a" };
            exp = new UnaryExpression()
            {
                Operand = a,
                Operator = new CeilingOperator()
            };
            i[a] = 23.45;

            Assert.AreEqual(24, exp.Evaluate(i));

            // Case 3 - A ill-formed with no Operand
            exp = new UnaryExpression()
            {
                Operator = new CeilingOperator()
            };

            Assert.AreEqual(0, exp.Evaluate(i));

            // Case 4 - A ill-formed with no Operator
            exp = new UnaryExpression()
            {
                Operand = a
            };

            Assert.AreEqual(0, exp.Evaluate(i));
        }

    }
}
