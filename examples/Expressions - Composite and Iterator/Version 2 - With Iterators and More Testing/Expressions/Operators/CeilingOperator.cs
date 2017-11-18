using System;

namespace Expressions.Operators
{
    public class CeilingOperator : UnaryOperator
    {
        public override double Execute(double operand)
        {
            return Math.Ceiling(operand);
        }

        public override string ToString() { return "\u2308"; }
    }
}
