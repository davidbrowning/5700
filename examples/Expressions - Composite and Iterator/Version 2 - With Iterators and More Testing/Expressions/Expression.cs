using System.Collections.Generic;

using Expressions.Iterators;

namespace Expressions
{
    public abstract class Expression
    {
        protected List<Expression> subExpressions = new List<Expression>();

        public abstract double Evaluate(Interpretation interpretation);
        public abstract double EstimateTime(Interpretation interpretation);
        public abstract double EstimateValue(Interpretation interpretation);
        public abstract string PrefixNotation { get; }
        public abstract string InfixNotation { get; }
        public abstract string PostfixNotation { get; }
        public abstract Expression OptimizedExpression { get; }

        public List<Expression> SubExpressions => subExpressions;

        public Iterator GetPreOrderIterator() { return new PreOrderIterator(this); }
        public Iterator GetInOrderIterator() { return new InOrderIterator(this); }
        public Iterator GetPostOrderIterator() { return new PostOrderIterator(this); }

        protected void AddOperand(Expression exp, int operandNumber)
        {
            if (exp != null && operandNumber > 0)
            {
                GrowSubExpressions(operandNumber);
                subExpressions[operandNumber - 1] = exp;
            }
        }

        protected void GrowSubExpressions(int targetSize)
        {
            for (int i = subExpressions.Count; i < targetSize; i++)
                subExpressions.Add(null);
        }
    }
}
