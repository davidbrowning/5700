using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;


namespace PersonClassLibrary
{
    [DataContract]
    abstract class Name 
    {
        [DataMember]
        private string First { get; set; }
        [DataMember]
        private string Second { get; set; }
    }
}
