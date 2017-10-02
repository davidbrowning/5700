using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClassLibrary
{
    public class ConsoleOutput : Outputter
    {
        public override void Output(List<PersonPair> p)
        {
            try
            {
                foreach (PersonPair pair in p)
                {
                    Console.WriteLine("Match:\n\t" + pair.One.ToString() + "\n\t" + pair.Two.ToString());
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
