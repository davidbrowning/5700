using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    /// <summary>
    /// This class plays a role in two different patterns: a Flyweight and a Decorator.  For the Flyweight, this
    /// class represent a "whole" relationship that combines both intrinsic state part and the extrinsic state part.
    /// Objects of this class only need to exist for short period time, like a drawing session.
    /// 
    /// For the decorator pattern, this class is a Decorator.  It add the extrinsic state to RelationshipWithIntrinsic State objects
    /// </summary>
    [DataContract]
    public class RelationshipWithAllState : Relationship
    {
        public Pen OutlinePen { get; set; } = new Pen(Color.DarkGray);
        internal RelationshipWithIntrinsicState IntrinsicState { get; }

        [DataMember]
        public RelationshipExtrinsicState ExtrinsicState { get; set; }

        internal RelationshipWithAllState(RelationshipWithIntrinsicState sharedPart, RelationshipExtrinsicState nonsharedPart)
        {
            IntrinsicState = sharedPart;                // From a decorator perspective, this is the decorated object
            ExtrinsicState = nonsharedPart;            // From a decorator perspective, this is the added feature or
                                                        // capability that this object (a decorator) is adding
        }

        public override bool IsSelected {
            get { return ExtrinsicState.IsSelected;  }
            set { ExtrinsicState.IsSelected = value;  }
        }

        public override Pen SelectedPen
        {
            get { return ExtrinsicState.SelectedPen; }
            set { ExtrinsicState.SelectedPen = value; }
        }

        public override Point Location
        {
            get { return ExtrinsicState.Location; }
            set { ExtrinsicState.Location = value; }
        }
        public override Point StartingPoint
        {
            get { return ExtrinsicState.StartingPoint; }
            set { ExtrinsicState.StartingPoint = value; }
        }


        public override Size Size
        {
            get { return ExtrinsicState.Size; }
            set { ExtrinsicState.Size = value; }
        }

        public override Element Clone()
        {
            return new RelationshipWithAllState(IntrinsicState, ExtrinsicState = ExtrinsicState.Clone());
        }


        public override void Draw(Graphics graphics)
        {
            if (graphics == null) return;

            //new Rectangle(ExtrinsicState.Location.X, ExtrinsicState.Location.Y, ExtrinsicState.Size.Width,
            //   ExtrinsicState.Size.Height);
            Point p = new Point(Location.X+100, Location.Y);
            graphics.DrawLine(IntrinsicState.SelectedPen,StartingPoint, Location);
            //graphics.DrawArc(IntrinsicState.SelectedPen, new Rectangle(Location.X, Location.Y, 100, 100), 0, 360);


            if (ExtrinsicState.IsSelected)
            {
                var g = new GraphicsWithSelection() {MyGraphics = graphics};
                g.DrawSelectionBox(ExtrinsicState.Location, ExtrinsicState.Size);
            }
        }

        public override bool ContainsPoint(Point point)
        {
            return point.X >= Location.X && point.Y >= Location.Y &&
                   point.X <= Location.X + Size.Width &&
                   point.Y <= Location.Y + Size.Height;
        }

    }

}
