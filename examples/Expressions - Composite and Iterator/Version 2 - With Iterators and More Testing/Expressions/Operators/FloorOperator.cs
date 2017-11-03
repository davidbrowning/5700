using System;

namespace Expressions.Operators
{
    public class FloorOperator : UnaryOperator
    {
        public override double Execute(double operand)
        {
            return Math.Floor(operand);
        }

        public override string ToString() { return "\u230A"; }
    }
}
