using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class SelectCommand : Command
    {
        private readonly Point _location;
        private Element _element;
        private bool _originalState;
         
        internal SelectCommand(params object[] commandParameters)
        {
            if (commandParameters.Length>0)
            _location = (Point) commandParameters[0];
        }

        public override bool Execute()
        {
            _element = TargetDrawing.FindElementAtPosition(_location);
            if (_element == null) return false;

            _originalState = _element.IsSelected;
             _element.IsSelected = !_originalState;

            TargetDrawing.IsDirty = true;

            return true;
        }

        internal override void Undo()
        {
            if (_element.IsSelected == _originalState) return;

            _element.IsSelected = _originalState;
            TargetDrawing.IsDirty = true;
        }

        internal override void Redo()
        {
            if (_element.IsSelected != _originalState) return;

            _element.IsSelected = !_originalState;
            TargetDrawing.IsDirty = true;
        }

    }
}
