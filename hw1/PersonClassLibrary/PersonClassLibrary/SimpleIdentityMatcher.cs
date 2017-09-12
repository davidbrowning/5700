using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClassLibrary
{
    public class SimpleIdentityMatcher : SimpleMatcher
    {
        public override bool IsMatchedPair(PersonPair p)
        {
            if(p.One.SocialSecurityNumber == p.Two.SocialSecurityNumber || p.One.StateFileNumber == p.Two.StateFileNumber )
            {
                return true;
            }
            return false;
        }
    }
}
