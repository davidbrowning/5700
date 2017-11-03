using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Expressions;
using Expressions.Operators;

namespace ExpressionsTesting
{
    [TestClass]
    public class InterpretationTester
    {
        [TestMethod]
        public void Interpretation_TestEverything()
        {
            Interpretation interpretation = new Interpretation();

            Variable[] goodVariables = new Variable[]
            {
                new Variable() { Label = "A" },
                new Variable() { Label = "B" },
                new Variable() { Label = "C" },
                new Variable() { Label = "D" },
                new Variable() { Label = "E" },
                new Variable() { Label = "F" },
                new Variable() { Label = "G" },
                new Variable() { Label = "H" },
                new Variable() { Label = "I" },
                new Variable() { Label = "XYZZY" },
                new Variable() { Label = "ABC1234" }
            };

            // Check init set of each variable -- should be 0
            foreach (Variable v in goodVariables)
                Assert.AreEqual(0, interpretation[v]);

            // Set a variable and make sure the value is remembered
            interpretation[goodVariables[0]] = 123.45;
            Assert.AreEqual(123.45, interpretation[goodVariables[0]]);

            // Set lots of variables
            Random r = new Random();
            foreach (Variable v in goodVariables)
            {
                double value = r.NextDouble();
                interpretation[v] = value;
                Assert.AreEqual(value, interpretation[v]);
            }

            // Check bad variables
            Assert.AreEqual(0, interpretation[null]);
            interpretation[null] = 0;

            Variable[] badVariables = new Variable[]
            {
                new Variable(),
                new Variable() { Label = string.Empty },
                new Variable() { Label = "  " }
            };

            // Check value of bad variable -- always should be 0
            foreach (Variable v in badVariables)
                Assert.AreEqual(0, interpretation[v]);

            // Try to set bad variables -- values should always remain 0
            r = new Random();
            foreach (Variable v in badVariables)
            {
                double value = r.NextDouble();
                interpretation[v] = value;
                Assert.AreEqual(0, interpretation[v]);
            }

        }
    }
}
