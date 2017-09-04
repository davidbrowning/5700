using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PersonClassLibrary
{
    [DataContract]
    abstract class Birth 
    {
        [DataMember]
        private int Year { get; set; }
        [DataMember]
        private int Month { get; set; }
        [DataMember]
        private int Day { get; set; }
        [DataMember]
        private string IsPartOfMultipleBirth { get; set; }
        [DataMember]
        private int BirthOrder { get; set; }
        [DataMember]
        private string BirthCountry { get; set; }
        
        
    }
}
