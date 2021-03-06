﻿using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    /// <summary>
    /// This class plays a role in two different patterns: a Flyweight and a Decorator.  For the Flyweight, this
    /// class represent a "whole" tree that combines both intrinsic state part and the extrinsic state part.
    /// Objects of this class only need to exist for short period time, like a drawing session.
    /// 
    /// For the decorator pattern, this class is a Decorator.  It add the extrinsic state to TreeWithIntrinsic State objects
<<<<<<< HEAD:examples/Forest Drawing - Flyweight and Command Patterns/Forests - Version 4 - Undo and Redo/AppLayer/DrawingComponents/ComponentWithAllState.cs
    /// </summary>
    public class ComponentWithAllState : Component
    {
        internal ComponentWithIntrinsicState IntrinsicState { get; }
        public ComponentExtrinsicState ExtrinsicStatic { get; }
=======
    /// </summary
    [DataContract]
    public class TreeWithAllState : Tree
    {
        internal TreeWithIntrinsicState IntrinsicState { get; }

        [DataMember]
        public TreeExtrinsicState ExtrinsicStatic { get; set; }
>>>>>>> 883e0355e2e7d796800a66f2e050eb4a2fb20b5a:examples/Forest Drawing - Flyweight and Command Patterns/Forests - Version 4 - Undo and Redo/AppLayer/DrawingComponents/TreeWithAllState.cs

        internal ComponentWithAllState(ComponentWithIntrinsicState sharedPart, ComponentExtrinsicState nonsharedPart)
        {
            IntrinsicState = sharedPart;                // From a decorator perspective, this is the decorated object
            ExtrinsicStatic = nonsharedPart;            // From a decorator perspective, this is the added feature or
                                                        // capability that this object (a decorator) is adding
        }

        public override bool IsSelected {
            get { return ExtrinsicStatic.IsSelected;  }
            set { ExtrinsicStatic.IsSelected = value;  }
        }

        public override Point Location
        {
            get { return ExtrinsicStatic.Location; }
            set { ExtrinsicStatic.Location = value; }
        }


        public override Size Size
        {
            get { return ExtrinsicStatic.Size; }
            set { ExtrinsicStatic.Size = value; }
        }

        public override void Draw(Graphics graphics)
        {
            if (graphics == null || IntrinsicState?.Image == null) return;

            graphics.DrawImage(IntrinsicState.Image,
                new Rectangle(ExtrinsicStatic.Location.X, ExtrinsicStatic.Location.Y, ExtrinsicStatic.Size.Width, ExtrinsicStatic.Size.Height),
                0, 0, IntrinsicState.Image.Width, IntrinsicState.Image.Height,
                GraphicsUnit.Pixel);

            if (ExtrinsicStatic.IsSelected)
            {
                graphics.DrawRectangle(
                    SelectedPen,
                    ExtrinsicStatic.Location.X,
                    ExtrinsicStatic.Location.Y,
                    ExtrinsicStatic.Size.Width,
                    ExtrinsicStatic.Size.Height);

                DrawActionHandle(graphics, ExtrinsicStatic.Location.X, ExtrinsicStatic.Location.Y);
                DrawActionHandle(graphics, ExtrinsicStatic.Location.X + ExtrinsicStatic.Size.Width, ExtrinsicStatic.Location.Y);
                DrawActionHandle(graphics, ExtrinsicStatic.Location.X, ExtrinsicStatic.Location.Y + ExtrinsicStatic.Size.Height);
                DrawActionHandle(graphics, ExtrinsicStatic.Location.X + ExtrinsicStatic.Size.Width, ExtrinsicStatic.Location.Y + ExtrinsicStatic.Size.Height);
            }
        }

        private void DrawActionHandle(Graphics graphics, int x, int y)
        {
            graphics.FillRectangle(HandlesBrush, x - HandleHalfSize, y - HandleHalfSize, HandleHalfSize*2, HandleHalfSize*2);
        }

    }

}
