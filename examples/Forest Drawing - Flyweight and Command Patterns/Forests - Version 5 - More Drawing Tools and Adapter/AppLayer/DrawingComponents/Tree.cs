﻿using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public abstract class Tree : Element
    {
        public static Pen SelectedPen { get; set; } = new Pen(Color.DarkGray);
        public static Size ToolSize { get; set; } = new Size() { Width = 64, Height = 64};
        public virtual Point Location { get; set; } = new Point(0, 0);
        public virtual Size Size { get; set; } = new Size(0, 0);
    }
}
