﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace PersonClassLibrary
{
    [DataContract]
    abstract class Family
    {
        [DataMember]
        private Person Mother {set; get;}
        [DataMember]
        private Person Father {set; get;}
        [DataMember]
        private List<Person> Siblings {set; get;}
    }
}
