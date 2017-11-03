using System.Globalization;

namespace Expressions
{
    public class Constant : Expression
    {
        public double Value { get; set; }

        public override double Evaluate(Interpretation interpretation)
        {
            return Value;
        }

        public override double EstimateTime(Interpretation interpretation)
        {
            return 0;
        }

        public override double EstimateValue(Interpretation interpretation)
        {
            return Value;
        }

        public override string PrefixNotation => Value.ToString(CultureInfo.InvariantCulture);

        public override string InfixNotation => Value.ToString(CultureInfo.InvariantCulture);

        public override string PostfixNotation => Value.ToString(CultureInfo.InvariantCulture);

        public override Expression OptimizedExpression => this.MemberwiseClone() as Constant;
    }
}
