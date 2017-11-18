namespace Expressions.Operators
{
    public abstract class UnaryOperator
    {
        public abstract double Execute(double operand);
        public string Label => ToString();
    }
}
