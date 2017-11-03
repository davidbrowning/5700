using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions;
using Expressions.Functions;
using Expressions.Operators;
using Expressions.Iterators;

namespace ExpressionsTesting.IteratorTesters
{
    [TestClass]
    public class InOrderIteratorTester
    {
        [TestMethod]
        public void InOrderIterator_TestOnAtomicExpression()
        {
            Constant exp = new Constant() { Value = 1.2 };

            Iterator i = exp.GetInOrderIterator();
            Assert.IsNotNull(i);
            Assert.IsNull(i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next -- should be first and only node
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(exp, i.Current);
            Assert.IsFalse(i.IsDone);

            // Try to move again
            Assert.IsFalse(i.MoveNext());
            Assert.IsNull(i.Current);
            Assert.IsTrue(i.IsDone);

        }

        [TestMethod]
        public void InOrderIterator_TestUnaryExpression()
        {
            Variable v1 = new Variable() { Label = "A" };
            UnaryOperation exp = new UnaryOperation()
            {
                Operator = new FloorOperator(),
                Operand = v1
            };

            Iterator i = exp.GetInOrderIterator();
            Assert.IsNotNull(i);
            Assert.IsNull(i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(exp, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v1, i.Current);
            Assert.IsFalse(i.IsDone);

            // Try to move again
            Assert.IsFalse(i.MoveNext());
            Assert.IsNull(i.Current);
            Assert.IsTrue(i.IsDone);

        }

        [TestMethod]
        public void InOrderIterator_TestBinaryExpression()
        {
            Variable v1 = new Variable() { Label = "A" };
            Variable v2 = new Variable() { Label = "B" };

            BinaryOperation exp = new BinaryOperation()
            {
                Operator = new AddOperator(),
                Operand1 = v1,
                Operand2 = v2
            };

            Iterator i = exp.GetInOrderIterator();
            Assert.IsNotNull(i);
            Assert.IsNull(i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v1, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(exp, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v2, i.Current);
            Assert.IsFalse(i.IsDone);

            // Try to move again
            Assert.IsFalse(i.MoveNext());
            Assert.IsNull(i.Current);
            Assert.IsTrue(i.IsDone);
        }

        [TestMethod]
        public void InOrderIterator_TestFunctionExpression()
        {
            Variable v1 = new Variable() { Label = "A" };
            Variable v2 = new Variable() { Label = "B" };
            Variable v3 = new Variable() { Label = "B" };

            FunctionExpression exp = new FunctionExpression()
            {
                Function = new BigSlowFunction(),
                Parameters = new List<Expression>() { v1, v2, v3 }
            };

            Iterator i = exp.GetInOrderIterator();
            Assert.IsNotNull(i);
            Assert.IsNull(i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(exp, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v1, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v2, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v3, i.Current);
            Assert.IsFalse(i.IsDone);

            // Try to move again
            Assert.IsFalse(i.MoveNext());
            Assert.IsNull(i.Current);
            Assert.IsTrue(i.IsDone);
        }

        [TestMethod]
        public void InOrderIterator_TestExpressionTree()
        {
            Variable v1 = new Variable() { Label = "A" };
            Variable v2 = new Variable() { Label = "B" };
            Variable v3 = new Variable() { Label = "C" };

            Variable v4 = new Variable() { Label = "D" };
            Variable v5 = new Variable() { Label = "E" };

            Variable v7 = new Variable() { Label = "H" };
            Variable v8 = new Variable() { Label = "I" };
            Variable v9 = new Variable() { Label = "J" };

            FunctionExpression exp1 = new FunctionExpression()
            {
                Function = new BigSlowFunction(),
                Parameters = new List<Expression>() { v1, v2, v3 }
            };

            BinaryOperation exp2 = new BinaryOperation()
            {
                Operator = new AddOperator(),
                Operand1 = v4,
                Operand2 = v5
            };

            FunctionExpression exp3 = new FunctionExpression()
            {
                Function = new BigSlowFunction(),
                Parameters = new List<Expression>() { v7, v8, v9 }
            };

            FunctionExpression exp4 = new FunctionExpression()
            {
                Function = new BigSlowFunction(),
                Parameters = new List<Expression>() { exp1, exp2, exp3 }
            };


            Iterator i = exp4.GetInOrderIterator();
            Assert.IsNotNull(i);
            Assert.IsNull(i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(exp4, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(exp1, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v1, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v2, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v3, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v4, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(exp2, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v5, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(exp3, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v7, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v8, i.Current);
            Assert.IsFalse(i.IsDone);

            // Move next
            Assert.IsTrue(i.MoveNext());
            Assert.AreSame(v9, i.Current);
            Assert.IsFalse(i.IsDone);

            // Try to move again
            Assert.IsFalse(i.MoveNext());
            Assert.IsNull(i.Current);
            Assert.IsTrue(i.IsDone);
        }

    }
}
