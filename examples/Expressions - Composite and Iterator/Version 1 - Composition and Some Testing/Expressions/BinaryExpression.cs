using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Expressions.Operators;

namespace Expressions
{
    public class BinaryExpression : IExpression
    {
        public BinaryOperator Operator { get; set; }
        public IExpression Operand1 { get; set; }
        public IExpression Operand2 { get; set; }

        public double Evaluate(Interpretation interpretation)
        {
            double result = 0;
            if (Operator != null && Operand1 != null && Operand2 != null)
            {
                double op1 = Operand1.Evaluate(interpretation);
                double op2 = Operand2.Evaluate(interpretation);
                result = Operator.Execute(op1, op2);
            }
            return result;
        }

        public double EstimateTime(Interpretation interpretation)
        {
            return 1;
        }

        public double EstimateValue(Interpretation interpretation)
        {
            return Evaluate(interpretation);
        }
    }
}
