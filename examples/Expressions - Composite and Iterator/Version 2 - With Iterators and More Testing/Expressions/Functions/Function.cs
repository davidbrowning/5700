using System.Collections.Generic;

namespace Expressions.Functions
{
    public abstract class Function
    {
        public string Label { get; set; }
        public abstract double Execute(List<double> parameters);
        public abstract double GetEstimatedTime(List<double> parameters);
        public abstract double GetEstimatedValue(List<double> parameters);
    }
}
