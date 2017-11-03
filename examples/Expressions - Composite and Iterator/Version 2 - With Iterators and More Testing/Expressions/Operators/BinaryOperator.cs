namespace Expressions.Operators
{
    public abstract class BinaryOperator
    {
        public abstract double Execute(double operand1, double operand2);
        public string Label => ToString();
    }
}
