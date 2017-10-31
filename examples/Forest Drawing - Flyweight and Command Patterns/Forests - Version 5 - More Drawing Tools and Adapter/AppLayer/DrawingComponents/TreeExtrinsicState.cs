using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class TreeExtrinsicState
    {
        [DataMember]
        public string TreeType { get; set; }

        [DataMember]
        public Point Location { get; set; }

        [DataMember]
        public Size Size { get; set; }

        [DataMember]
        public bool IsSelected { get; set; }

        public TreeExtrinsicState Clone()
        {
            return new TreeExtrinsicState()
            {
                TreeType = TreeType,
                Location = Location,
                Size = Size,
                IsSelected = IsSelected
            };
        }
    }
}
