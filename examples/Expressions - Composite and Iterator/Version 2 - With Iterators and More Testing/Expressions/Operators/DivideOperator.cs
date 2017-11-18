﻿namespace Expressions.Operators
{
    public class DivideOperator : BinaryOperator
    {
        public override double Execute(double operand1, double operand2)
        {
            return operand1 / operand2;
        }

        public override string ToString() { return "/"; }
    }
}
