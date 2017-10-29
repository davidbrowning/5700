using System.Collections.Generic;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class RemoveSelectedCommand : Command
    {
        private List<Element> _deletedElements; 
        internal RemoveSelectedCommand() { }

        public override bool Execute()
        {
            _deletedElements = TargetDrawing?.DeleteAllSelected();
            return _deletedElements != null && _deletedElements.Count > 0;
        }

        internal override void Undo()
        {
            if (_deletedElements == null || _deletedElements.Count==0) return;

            foreach (var element in _deletedElements)
                TargetDrawing?.Add(element);
        }

        internal override void Redo()
        {
            if (_deletedElements == null || _deletedElements.Count == 0) return;

            foreach (var tree in _deletedElements)
                TargetDrawing?.DeleteElement(tree);
        }
    }
}
