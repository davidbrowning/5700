using System.Collections.Generic;

using Expressions.Functions;

namespace Expressions
{
    public class FunctionExpression : Expression
    {
        public Function Function { get; set; }
        public List<Expression> Parameters
        {
            get { return subExpressions; }
            set
            {
                subExpressions = value ?? new List<Expression>();
            }
        }

        public override double Evaluate(Interpretation interpretation)
        {
            double result = 0;
            if (Function == null || Parameters.Count <= 0) return result;
            var parameterValues = new List<double>();
            foreach (var param in Parameters)
                parameterValues.Add(param.EstimateValue(interpretation));
            result = Function.Execute(parameterValues);
            return result;
        }

        public override double EstimateTime(Interpretation interpretation)
        {
            double result = 0;
            if (Function == null || Parameters == null || Parameters.Count <= 0) return result;
            double parameterTimeEstimates = 0;
            var parameterValueEstimates = new List<double>();
            foreach (var param in Parameters)
            {
                parameterTimeEstimates += param.EstimateTime(interpretation);
                parameterValueEstimates.Add(param.EstimateValue(interpretation));
            }

            result = parameterTimeEstimates + Function.GetEstimatedTime(parameterValueEstimates);
            return result;
        }

        public override double EstimateValue(Interpretation interpretation)
        {
            double result = 0;
            if (Function == null || Parameters.Count <= 0) return result;
            var parameterValues = new List<double>();
            foreach (var param in Parameters)
                parameterValues.Add(param.EstimateValue(interpretation));

            result = Function.GetEstimatedValue(parameterValues);

            return result;
        }

        public override string PrefixNotation
        {
            get
            {
                var result = string.Empty;
                if (Function == null || Parameters.Count <= 0) return result;
                result = Function.Label;

                var parameterValues = new List<double>();
                foreach (var param in Parameters)
                    result += " " + param.PrefixNotation;
                return result;
            }
        }

        public override string InfixNotation
        {
            get
            {
                var result = string.Empty;
                if (Function == null || Parameters.Count <= 0) return result;
                result = Function.Label;
                var delimeter = "(";
                foreach (var param in Parameters)
                {
                    result += delimeter + param.PrefixNotation;
                    delimeter = ", ";
                }
                result += ")";
                return result;
            }
        }

        public override string PostfixNotation
        {
            get
            {
                var result = string.Empty;
                if (Function == null || Parameters.Count <= 0) return result;

                foreach (Expression param in Parameters)
                    result += param.PrefixNotation + " ";
                result += Function.Label;
                return result;
            }
        }

        public override Expression OptimizedExpression
        {
            get
            {
                var newParameters = new List<Expression>();

                if (Function != null && Parameters.Count > 0)
                {
                    foreach (var param in Parameters)
                        newParameters.Add(param.OptimizedExpression);
                }

                var newExpression = new FunctionExpression()
                                                    {
                                                        Function = Function,
                                                        Parameters = newParameters
                                                    };
                return newExpression;
            }
        }
    }
}
