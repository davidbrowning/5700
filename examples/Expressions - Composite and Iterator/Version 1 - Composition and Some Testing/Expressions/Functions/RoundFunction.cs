using System;
using System.Collections.Generic;

namespace Expressions.Functions
{
    public class RoundFunction : Function
    {
        public override double Execute(List<double> parameters)
        {
            double result = 0;
            if (parameters!=null && parameters.Count == 1)
                result = Math.Round(parameters[0]);
            return result;
        }
    }
}
