using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.DrawingComponents
{
    public abstract class Element
    {
        public virtual bool IsSelected { get; set; } = false;

        public abstract Element Clone();

        public virtual void Draw(Graphics graphics) { }

        public virtual bool ContainsPoint(Point point) { return false; }
    }
}
