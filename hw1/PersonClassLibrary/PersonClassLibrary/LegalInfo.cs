using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PersonClassLibrary
{
    [DataContract]

    abstract class LegalInfo 
    {
        [DataMember]
        private string Ssn { get; set; }
        [DataMember]
        private string State_file_number { get; set;}
    }
}
