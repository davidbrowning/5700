using System;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace AppLayer.DrawingComponents
{
    /// <summary>
    /// This is class is part of two patterns: Flyweight and Decorator.  For the Flyweight Pattern it is a concrete flyweight
    /// that defines the intrinsic state (shared state).  For the Decorator pattern is a concrete components, i.e., something that can
    /// be decorated.
    /// 
    /// Note that this class is tagged as "internal", which means only components in the AppLayer can acces it.  This helps encapsulate the idea
    /// in the AppLayer and prevent misuse by components in other layers.
    /// </summary>
    internal class RelationshipWithIntrinsicState : Relationship
    {
        public static Color SelectionBackgroundColor { get; set; } = Color.DarkKhaki;
        public string RelationshipType { get; set; }

        public override Element Clone()
        {
            return this;        // Don't really clone
        }

        public void LoadFromResource(string relationshipType, Type referenceTypeForAssembly)
        {
            if (string.IsNullOrWhiteSpace(relationshipType)) return;
            //MessageBox.Show("Relationship Type: " + relationshipType);
            // not sure I need this function
        }

        public bool SelectPen(Pen p)
        {
            SelectedPen = p;
            return true;
        }

        public override bool IsSelected
        {
            get { return false; }
            set
            {
                throw new ApplicationException("Cannot select a relationship with only intrinsic state - the intrinsic state is immutable");
            }
        }


        public override Point Location
        {
            get { return new Point(); }
            set
            {
                throw new ApplicationException("Cannot change a relationship with only intrinsic state - the intrinsic state is immutable");
            }
        }

        public override Size Size
        {
            get { return new Size(); }
            set
            {
                throw new ApplicationException("Cannot change a relationship with only intrinsic state - the intrinsic state is immutable");
            }
        }

        public override void Draw(Graphics graphics)
        {
            throw new ApplicationException("Cannot draw a relationship with only intrinsic state");
        }
    }
}
