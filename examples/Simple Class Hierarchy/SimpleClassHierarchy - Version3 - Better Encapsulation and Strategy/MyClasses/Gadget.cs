using System.Runtime.Serialization;

namespace MyClasses
{
    [DataContract]
    public class Gadget : ThingABob
    {
        [DataMember]
        public double Cost { get; set; }
        [DataMember]
        public int Length { get; set; }
        [DataMember]
        public int Width { get; set; }

        public override string ToString()
        {
            return $"Gadget: {base.ToString()}, width={Width}, length={Length}, cost={Cost}";
        }
    }
}
