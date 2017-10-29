using System.Drawing;

namespace AppLayer.DrawingComponents
{
    interface IGraphicsWithSelection
    {
        void DrawSelectionBox(Point location, Size size);
        void DrawSelectionLine(Point start, Point end);
    }
}
