using System.Globalization;

namespace Expressions
{
    public class Constant : IExpression
    {
        public double Value { get; set; }

        public double Evaluate(Interpretation interpretation)
        {
            return Value;
        }

        public double EstimateTime(Interpretation interpretation)
        {
            return 0;
        }

        public double EstimateValue(Interpretation interpretation)
        {
            return Value;
        }

        public string PrefixNotation => Value.ToString(CultureInfo.InvariantCulture);

        public string InfixNotation => Value.ToString(CultureInfo.InvariantCulture);

        public string PostfixNotation => Value.ToString(CultureInfo.InvariantCulture);

        public IExpression OptimizedExpression => this.MemberwiseClone() as Constant;
    }
}
