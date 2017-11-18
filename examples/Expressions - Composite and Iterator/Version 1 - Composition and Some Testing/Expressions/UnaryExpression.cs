using Expressions.Operators;

namespace Expressions
{
    public class UnaryExpression : IExpression
    {
        public UnaryOperator Operator { get; set; }
        public IExpression Operand { get; set; }

        public double Evaluate(Interpretation interpretation)
        {
            double result = 0;
            if (Operator != null && Operand != null)
                result = Operator.Execute(Operand.Evaluate(interpretation));
            return result;
        }
    }
}
