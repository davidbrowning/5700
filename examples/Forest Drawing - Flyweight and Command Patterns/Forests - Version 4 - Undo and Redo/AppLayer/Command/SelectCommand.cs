using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class SelectCommand : Command
    {
        private readonly Point _location;
        private Component _tree;
        private bool _originalState;
         
        internal SelectCommand(params object[] commandParameters)
        {
            if (commandParameters.Length>0)
            _location = (Point) commandParameters[0];
        }

        public override bool Execute()
        {
            _tree = TargetDrawing.FindTreeAtPosition(_location);
            if (_tree == null) return false;

            _originalState = _tree.IsSelected;
             _tree.IsSelected = !_originalState;

            TargetDrawing.IsDirty = true;

            return true;
        }

        internal override void Undo()
        {
            if (_tree.IsSelected == _originalState) return;

            _tree.IsSelected = _originalState;
            TargetDrawing.IsDirty = true;
        }

        internal override void Redo()
        {
            if (_tree.IsSelected != _originalState) return;

            _tree.IsSelected = !_originalState;
            TargetDrawing.IsDirty = true;
        }

    }
}
