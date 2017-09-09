using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClassLibrary
{
    public abstract class Matcher
    {
        public abstract Dictionary<string, List<Person>> FindMatches(List<Person> list);
    }
}
