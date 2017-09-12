using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClassLibrary
{
    public class SimpleBirthMatcher : SimpleMatcher
    {
        public override bool IsMatchedPair(PersonPair p)
        {
            if(p.One.BirthYear == p.Two.BirthYear && p.One.BirthMonth == p.Two.BirthMonth && p.One.BirthDay == p.Two.BirthDay)
            {
                return true;
            }
            return false;
        }
    }
}
