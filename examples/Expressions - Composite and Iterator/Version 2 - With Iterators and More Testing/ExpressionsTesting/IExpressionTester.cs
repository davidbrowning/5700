using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions;

namespace ExpressionsTesting
{
    /// <summary>
    /// MockExpression
    /// 
    /// To test IExpression, since it is an abstract class, we create a mock specialization of
    /// IExpression and test using that mock.
    /// </summary>
    public class MockExpression : Expression
    {
        public override double Evaluate(Interpretation interpretation)
        {
            return 0;
        }

        public override double EstimateTime(Interpretation interpretation)
        {
            return 0;
        }

        public override double EstimateValue(Interpretation interpretation)
        {
            return 0;
        }

        public override string PrefixNotation
        {
            get { return string.Empty; }
        }

        public override string InfixNotation
        {
            get { return string.Empty; }
        }

        public override string PostfixNotation
        {
            get { return string.Empty; }
        }

        public override Expression OptimizedExpression
        {
            get { return this; }
        }

        /// <summary>
        /// This method exposes the AddOperand method from the base class, which is overwise protected
        /// </summary>
        public new void AddOperand(Expression exp, int operandNumber)
        {
            base.AddOperand(exp, operandNumber);

        }
    }

    [TestClass]
    public class IExpressionTester
    {
        [TestMethod]
        public void IExpression_TestBaseClassFunctionality()
        {
            MockExpression e1 = new MockExpression();

            // Check initial state
            Assert.IsNotNull(e1.SubExpressions);
            Assert.AreEqual(0, e1.SubExpressions.Count);

            // Check GrowSubExpression through AddOperand in MockExpression
            Constant c1 = new Constant() { Value = 12.34 };
            e1.AddOperand(c1, 3);
            Assert.AreEqual(3, e1.SubExpressions.Count);
            Assert.IsNull(e1.SubExpressions[0]);
            Assert.IsNull(e1.SubExpressions[1]);
            Assert.AreSame(c1, e1.SubExpressions[2]);

            Constant c2 = new Constant() { Value = 23.4 };
            e1.AddOperand(c2, 1);
            Assert.AreEqual(3, e1.SubExpressions.Count);
            Assert.AreSame(c2, e1.SubExpressions[0]);
            Assert.IsNull(e1.SubExpressions[1]);
            Assert.AreSame(c1, e1.SubExpressions[2]);

            Constant c3 = new Constant() { Value = 34.56 };
            e1.AddOperand(c3, 4);
            Assert.AreEqual(4, e1.SubExpressions.Count);
            Assert.AreSame(c2, e1.SubExpressions[0]);
            Assert.IsNull(e1.SubExpressions[1]);
            Assert.AreSame(c1, e1.SubExpressions[2]);
            Assert.AreSame(c3, e1.SubExpressions[3]);
        }
    }
}
