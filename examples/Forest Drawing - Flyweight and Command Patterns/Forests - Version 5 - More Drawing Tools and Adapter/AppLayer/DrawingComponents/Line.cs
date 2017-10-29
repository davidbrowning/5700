using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public class Line : Element
    {
        public static Pen RegularPen { get; set; } = new Pen(Color.Black);

        public int SelectionMargin { get; set; } = 2;

        [DataMember]
        public Point Start { get; set; }
        [DataMember]
        public Point End { get; set; }

        public override Element Clone()
        {
            return new Line() {Start = Start, End = End};
        }

        public override void Draw(Graphics graphics)
        {
            if (graphics == null) return;

            if (IsSelected)
            {
                var g = new GraphicsWithSelection() { MyGraphics = graphics };
                g.DrawSelectionLine(Start, End);
            }
            else
            {
                graphics.DrawLine(RegularPen, Start, End);
            }
        }

        public override bool ContainsPoint(Point point)
        {
            // See https://en.wikipedia.org/wiki/Distance_from_a_point_to_a_line

            var minX = Math.Min(Start.X, End.X) - SelectionMargin;
            var maxX = Math.Max(Start.X, End.X) + SelectionMargin;
            var minY = Math.Min(Start.Y, End.Y) - SelectionMargin;
            var maxY = Math.Max(Start.Y, End.Y) + SelectionMargin;

            if (point.X < minX && point.Y < minY && point.X > maxX && point.Y > maxY) return false;

            var distance =
                Math.Abs((End.Y - Start.Y)*point.X - (End.X - End.Y)*point.Y + End.X*Start.Y - End.Y*Start.X) /
                Math.Sqrt(Math.Pow(Convert.ToDouble(End.Y) - Convert.ToDouble(Start.Y), 2) +
                          Math.Pow(Convert.ToDouble(End.X) - Convert.ToDouble(Start.X), 2));

            return distance <= SelectionMargin ;
        }

    }
}