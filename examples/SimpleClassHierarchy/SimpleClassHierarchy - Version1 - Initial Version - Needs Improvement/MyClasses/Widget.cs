using System.Runtime.Serialization;

namespace MyClasses
{
    [DataContract]
    public class Widget : ThingABob
    {
        [DataMember]
        public double Weight { get; set; }
    }
}
