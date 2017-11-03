using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions;
using Expressions.Functions;

namespace ExpressionsTesting
{
    [TestClass]
    public class FunctionExpressionTester
    {
        [TestMethod]
        public void FunctionExpression_TestEverything()
        {
            Interpretation interpretation = TestingUtils.SetupInterpretation();

            // Check initial state
            FunctionExpression exp = new FunctionExpression();
            Assert.IsNull(exp.Function);
            Assert.IsNotNull(exp.Parameters);

            // Check basic expression with a function and parameter list
            Function f = new RoundFunction();
            List<Expression> paramList = new List<Expression>() { new Variable() { Label = "A" } };
            exp = new FunctionExpression()
            {
                Function = f,
                Parameters = paramList
            };

            Assert.AreSame(f, exp.Function);
            Assert.AreSame(paramList, exp.Parameters);

            // Check setting the parameter to null
            exp.Parameters = null;
            Assert.IsNotNull(exp.Parameters);
            Assert.AreEqual(0, exp.Parameters.Count);

            // Check evaluate with a good function and parameter list
            exp.Parameters = paramList;
            Assert.AreEqual(1, exp.Evaluate(interpretation));

            // Check estimateTime with a good function and parameter list
            Assert.AreEqual(2, exp.EstimateTime(interpretation));

            // Check estimateTime with a good function and parameter list
            Assert.AreEqual(1, exp.EstimateValue(interpretation));

            // Check evaluate with a bad function and good parameter list
            exp.Function = null;
            Assert.AreEqual(0, exp.Evaluate(interpretation));

            // Check estimateTime with a bad function and good parameter list
            Assert.AreEqual(0, exp.EstimateTime(interpretation));

            // Check estimateTime with a bad function and good parameter list
            Assert.AreEqual(0, exp.EstimateValue(interpretation));

            // Check evaluate with a good function and empty parameter list
            exp.Parameters = null;
            Assert.AreEqual(0, exp.Evaluate(interpretation));

            // Check estimateTime with a good function and empty parameter list
            Assert.AreEqual(0, exp.EstimateTime(interpretation));

            // Check estimateTime with a good function and empty parameter list
            Assert.AreEqual(0, exp.EstimateValue(interpretation));
        }
    }
}
