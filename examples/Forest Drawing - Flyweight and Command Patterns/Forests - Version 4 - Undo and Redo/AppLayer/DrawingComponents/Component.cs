using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
<<<<<<< HEAD:examples/Forest Drawing - Flyweight and Command Patterns/Forests - Version 4 - Undo and Redo/AppLayer/DrawingComponents/Component.cs
    public abstract class Component
=======
    [DataContract]
    public abstract class Tree
>>>>>>> 883e0355e2e7d796800a66f2e050eb4a2fb20b5a:examples/Forest Drawing - Flyweight and Command Patterns/Forests - Version 4 - Undo and Redo/AppLayer/DrawingComponents/Tree.cs
    {
        public static Pen SelectedPen { get; set; } = new Pen(Color.DarkGray);
        public static Brush HandlesBrush { get; set; } = new SolidBrush(Color.Black);
        public static int HandleHalfSize { get; set; } = 3;
        public static Size ToolSize { get; set; } = new Size() { Width = 64, Height = 64};

        public virtual Point Location { get; set; } = new Point(0, 0);
        public virtual Size Size { get; set; } = new Size(0, 0);
        public virtual bool IsSelected { get; set; } = false;

        public virtual void Draw(Graphics graphics) { }
    }
}
