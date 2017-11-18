using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions;
using Expressions.Operators;

namespace ExpressionsTesting
{
    [TestClass]
    public class BinaryOperationTester
    {
        [TestMethod]
        public void BinaryOperator_TestEverything()
        {
            Interpretation interpretation = TestingUtils.SetupInterpretation();

            // Check initial state
            BinaryOperation exp1 = new BinaryOperation();
            Assert.IsNull(exp1.Operand1);
            Assert.IsNull(exp1.Operand2);
            Assert.IsNull(exp1.Operator);
            Assert.AreEqual(0, exp1.Evaluate(interpretation));
            Assert.AreEqual(1, exp1.EstimateTime(interpretation));
            Assert.AreEqual(0, exp1.EstimateValue(interpretation));
            try
            {
                string tmp = exp1.PrefixNotation;
            }
            catch { }
            try
            {
                string tmp = exp1.InfixNotation;
            }
            catch { }
            try
            {
                string tmp = exp1.PostfixNotation;
            }
            catch { }

            BinaryOperation exp2 = exp1.OptimizedExpression as BinaryOperation;
            Assert.IsNotNull(exp2);
            Assert.AreNotSame(exp1, exp2);
            Assert.IsNull(exp2.Operand1);
            Assert.IsNull(exp2.Operand2);
            Assert.IsNull(exp2.Operator);

            // A basic expression with variables
            BinaryOperator op = new AddOperator();
            Variable v1 = new Variable() { Label = "A" };
            Variable v2 = new Variable() { Label = "B" };
            exp1 = new BinaryOperation()
            {
                Operator = op,
                Operand1 = v1,
                Operand2 = v2
            };
            Assert.AreSame(v1, exp1.Operand1);
            Assert.AreSame(v2, exp1.Operand2);
            Assert.AreSame(op, exp1.Operator);
            Assert.AreEqual(3.33, exp1.Evaluate(interpretation));
            Assert.AreEqual(1, exp1.EstimateTime(interpretation));
            Assert.AreEqual(3.33, exp1.EstimateValue(interpretation));
            Assert.AreEqual("+ A B", exp1.PrefixNotation);
            Assert.AreEqual("(A + B)", exp1.InfixNotation);
            Assert.AreEqual("A B +", exp1.PostfixNotation);

            exp2 = exp1.OptimizedExpression as BinaryOperation;
            Assert.AreEqual("+ A B", exp2.PrefixNotation);
        }

    }
}
