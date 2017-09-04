using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PersonClassLibrary
{
    [DataContract]
    public class Person
    {
        [DataMember]
        private string ObjectId { get; set; }
        [DataMember]
        private Birth _birth;
        [DataMember]
        private Family _family;
        [DataMember]
        private LegalInfo _legalinfo;
        [DataMember]
        private Name _name;
    }
}
