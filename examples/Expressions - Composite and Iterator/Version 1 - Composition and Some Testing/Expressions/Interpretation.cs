using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
    public class Interpretation
    {
        private Dictionary<string, double> interpretation = new Dictionary<string, double>();
        private object myLock = new object();

        public bool Contains(Variable variable)
        {
            bool result = false;
            lock (myLock)
            {
                result = interpretation.ContainsKey(variable.Label);
            }
            return result;
        }

        public double this[Variable variable]
        {
            get
            {
                double result = 0;
                lock (myLock)
                {
                    if (variable != null && !string.IsNullOrWhiteSpace(variable.Label)
                        && interpretation.ContainsKey(variable.Label))
                        result = interpretation[variable.Label];
                }
                return result;
            }
            set
            {
                if (variable!=null && !string.IsNullOrWhiteSpace(variable.Label))
                {
                    lock (myLock)
                    {

                        if (interpretation.ContainsKey(variable.Label))
                            interpretation[variable.Label] = value;
                        else
                            interpretation.Add(variable.Label, value);
                    }
                }
            }
        }

    }
}
