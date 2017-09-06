using System.Runtime.Serialization;

namespace MyClasses
{
    [DataContract]
    public class ThingABob
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public string Name { get; set; }

        public override string ToString()
        {
            return $"Id={Id}, Name={Name}";
        }
    }
}
