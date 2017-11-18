using Expressions.Operators;

namespace Expressions
{
    public class BinaryOperation : Expression
    {
        public BinaryOperator Operator { get; set; }
        public Expression Operand1
        {
            get { return (subExpressions.Count > 0) ? subExpressions[0] : null; }
            set { AddOperand(value, 1); }
        }
        public Expression Operand2
        {
            get { return (subExpressions.Count > 1) ? subExpressions[1] : null; }
            set { AddOperand(value, 2); }
        }

        public override double Evaluate(Interpretation interpretation)
        {
            double result = 0;
            if (Operator != null && Operand1 != null && Operand2 != null)
            {
                double op1 = Operand1.Evaluate(interpretation);
                double op2 = Operand2.Evaluate(interpretation);
                result = Operator.Execute(op1, op2);
            }
            return result;
        }

        public override double EstimateTime(Interpretation interpretation)
        {
            return 1;
        }

        public override double EstimateValue(Interpretation interpretation)
        {
            return Evaluate(interpretation);
        }

        public override string PrefixNotation => $"{Operator.Label} {Operand1.PrefixNotation} {Operand2.PrefixNotation}";

        public override string InfixNotation => $"({Operand1.PrefixNotation} {Operator.Label} {Operand2.PrefixNotation})";

        public override string PostfixNotation => $"{Operand1.PrefixNotation} {Operand2.PrefixNotation} {Operator.Label}";

        public override Expression OptimizedExpression
        {
            get
            {
                Expression result;
                if (Operand1 is Constant && Operand2 is Constant)
                {
                    var i = new Interpretation();
                    result = new Constant()
                    {
                        Value = Operand1.Evaluate(i) + Operand2.Evaluate(i)
                    };
                }
                else
                {
                    var newOperand1 = Operand1?.OptimizedExpression;
                    var newOperand2 = Operand2?.OptimizedExpression;

                    result = new BinaryOperation()
                    {
                        Operand1 = newOperand1,
                        Operand2 = newOperand2,
                        Operator = Operator
                    };
                }
                return result;
            }
        }
    }
}
