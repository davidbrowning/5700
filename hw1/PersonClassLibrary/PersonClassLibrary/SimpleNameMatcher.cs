using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClassLibrary
{
    public class SimpleNameMatcher : SimpleMatcher
    {
        public override bool IsMatchedPair(PersonPair p)
        {
            if(p.One.FirstName == p.Two.FirstName && p.One.LastName == p.Two.LastName)
            {
                return true;
            }
            return false;
        }
    }
}
