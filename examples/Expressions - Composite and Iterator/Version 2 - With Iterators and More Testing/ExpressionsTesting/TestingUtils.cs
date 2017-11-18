using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Expressions;

namespace ExpressionsTesting
{
    public static class TestingUtils
    {
        public static Interpretation SetupInterpretation()
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
            };

            double nextValue = 1.11;
            foreach (Variable v in goodVariables)
            {
                interpretation[v] = nextValue;
                nextValue *= 2;
            }

            return interpretation;
        }
    }
}
