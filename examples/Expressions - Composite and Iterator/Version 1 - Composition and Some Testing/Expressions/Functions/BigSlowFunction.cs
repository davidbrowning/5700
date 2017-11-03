using System;
using System.Collections.Generic;
using System.Threading;

namespace Expressions.Functions
{
    /// <summary>
    /// BigSlowFunction
    /// 
    /// This function computes a big number based on one or more numbers, but does slowly.  The actually
    /// mathmatically function is not meaningful.  This function just illustrate a long-running method
    /// whose estimate value is not the same as the real computed value, and the estimated time can be big.
    /// </summary>
    public class BigSlowFunction : Function
    {
        private readonly Random _randomGenerator = new Random();

        public override double Execute(List<double> parameters)
        {
            return ComputeBigNumberSlowly(parameters, 0);
        }

        private double ComputeBigNumberSlowly(IReadOnlyList<double> parameters, int startingWithIndex)
        {
            if (parameters == null) return 0;

            if (startingWithIndex >= parameters.Count) return _randomGenerator.NextDouble();

            double result = 0;  
            for (var i = 0; i < parameters[startingWithIndex]; i++)
            {
                result += ComputeBigNumberSlowly(parameters, startingWithIndex + 1);
                Thread.Sleep(1);
            }

            return result;
        }

    }
}
