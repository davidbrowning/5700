using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Expressions.Operators;

namespace Expressions
{
    public class UnaryOperation : Expression
    {
        public UnaryOperator Operator { get; set; }
        public Expression Operand
        {
            get { return (subExpressions.Count > 0) ? subExpressions[0] : null; }
            set { AddOperand(value, 1); }
        }

        public override double Evaluate(Interpretation interpretation)
        {
            double result = 0;
            if (Operator != null && Operand != null)
                result = Operator.Execute(Operand.Evaluate(interpretation));
            return result;
        }

        public override double EstimateTime(Interpretation interpretation)
        {
            double result = 1;
            if (Operator != null && Operand != null)
                result += Operand.EstimateTime(interpretation);
            return result;
        }

        public override double EstimateValue(Interpretation interpretation)
        {
            double result = 0;
            if (Operator != null && Operand != null)
                result = Operand.EstimateValue(interpretation);
            return result;
        }

        public override string PrefixNotation
        {
            get { return string.Format("{0} {1}", Operator.Label, Operand.PrefixNotation); }

        }

        public override string InfixNotation
        {
            get { return string.Format("({0} {1})", Operator.Label, Operand.PrefixNotation); }
        }

        public override string PostfixNotation
        {
            get { return string.Format("{0} {1}", Operand.PrefixNotation, Operator.Label); }
        }

        public override Expression OptimizedExpression
        {
            get
            {
                Expression result = null;
                if (Operand is Constant)
                {
                    Interpretation i = new Interpretation();
                    result = new Constant() { Value = Operator.Execute(Operand.Evaluate(i)) };
                }
                else
                {
                    result = new UnaryOperation()
                        {
                            Operand = Operand.OptimizedExpression,
                            Operator = Operator
                        };
                }
                return result;
            }
        }
    }
}
