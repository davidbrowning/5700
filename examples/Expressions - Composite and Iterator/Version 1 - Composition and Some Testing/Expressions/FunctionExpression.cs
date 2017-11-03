using System.Collections.Generic;

using Expressions.Functions;

namespace Expressions
{
    public class FunctionExpression : IExpression
    {
        public Function Function { get; set; }
        public List<IExpression> Parameters { get; set; }

        public double Evaluate(Interpretation interpretation)
        {
            if (Function == null || Parameters == null || Parameters.Count <= 0) return 0;

            var parameterValues = new List<double>();
            foreach (var param in Parameters)
                parameterValues.Add(param.Evaluate(interpretation));
            return Function.Execute(parameterValues);
        }

    }
}
