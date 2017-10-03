using System;
using System.Drawing;

namespace Shapes
{
    public class Box
    {
        public float Width { get; set; }
        public float Height { get; set; }
        public string Label { get; set; }

        public Size BoxSize => new Size(Convert.ToInt32(Width), Convert.ToInt32(Height));
    }
}
