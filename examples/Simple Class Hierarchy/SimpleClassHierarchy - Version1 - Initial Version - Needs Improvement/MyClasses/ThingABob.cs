using System.Runtime.Serialization;

namespace MyClasses
{
    [DataContract]
    public class ThingABob
    {
        [DataMember]
        public int Id { get; set; }
    }
}
