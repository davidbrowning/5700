using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class RelationshipExtrinsicState
    {
        [DataMember]
        public string RelationshipType { get; set; }
        [DataMember]
        public Pen SelectedPen { get; set; }

        [DataMember]
        public Point Location { get; set; }
        [DataMember]
        public Point StartingPoint { get; set; }

        [DataMember]
        public Size Size { get; set; }

        [DataMember]
        public bool IsSelected { get; set; }

        public RelationshipExtrinsicState Clone()
        {
            return new RelationshipExtrinsicState()
            {
                RelationshipType = RelationshipType,
                Location = Location,
                Size = Size,
                StartingPoint = StartingPoint,
                IsSelected = IsSelected,
                SelectedPen = SelectedPen
            };
        }
    }
}
