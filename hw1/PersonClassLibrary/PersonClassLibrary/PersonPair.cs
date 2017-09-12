using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClassLibrary
{
    public class PersonPair
    {
        public PersonPair(Person first, Person Second)
        {
            One = first;
            Two = Second;
        }
        public Person One { get; set; }
        public Person Two { get; set; }
        public override string ToString()
        {
            return (One.ObjectId+","+Two.ObjectId);
        }
    }
}
