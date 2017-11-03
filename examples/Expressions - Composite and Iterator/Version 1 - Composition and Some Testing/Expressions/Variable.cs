using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Expressions
{
    public class Variable: IExpression
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

        public double Evaluate(Interpretation interpretation)
        {
            return (interpretation == null) ? 0 : interpretation[this];
        }

        public double EstimateTime(Interpretation interpretation)
        {
            return 0;
        }

        public double EstimateValue(Interpretation interpretation)
        {
            return (interpretation == null) ? 0 : interpretation[this];
        }

        public string PrefixNotation
        {
            get { return this.Label; }
        }

        public string InfixNotation
        {
            get { return this.Label; }
        }

        public string PostfixNotation
        {
            get { return this.Label; }
        }

        public IExpression OptimizedExpression
        {
            get { return this.MemberwiseClone() as Variable; }
        }

    }
}
