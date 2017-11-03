using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Expressions
{
    public class Variable: Expression
    {
        private static Regex validLabel = new Regex("^[a-zA-Z_][a-zA-Z_0-9]*$");
        private string label = string.Empty;

        public string Label
        {
            get { return label; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    label = string.Empty;
                else
                {
                    value = value.Trim();
                    if (!validLabel.IsMatch(value))
                        throw new ApplicationException("Invalid variable label");
                    else
                        label = value;
                }
            }
        }

        public override double Evaluate(Interpretation interpretation)
        {
            return (interpretation == null) ? 0 : interpretation[this];
        }

        public override double EstimateTime(Interpretation interpretation)
        {
            return 1;
        }

        public override double EstimateValue(Interpretation interpretation)
        {
            return (interpretation == null) ? 0 : interpretation[this];
        }

        public override string PrefixNotation
        {
            get { return this.Label; }
        }

        public override string InfixNotation
        {
            get { return this.Label; }
        }

        public override string PostfixNotation
        {
            get { return this.Label; }
        }

        public override Expression OptimizedExpression
        {
            get { return this.MemberwiseClone() as Variable; }
        }

    }
}
