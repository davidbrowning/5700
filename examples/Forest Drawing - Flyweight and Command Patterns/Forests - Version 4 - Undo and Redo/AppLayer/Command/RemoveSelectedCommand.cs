using System.Collections.Generic;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class RemoveSelectedCommand : Command
    {
        private List<Component> _deletedTrees; 
        internal RemoveSelectedCommand() { }

        public override bool Execute()
        {
            _deletedTrees = TargetDrawing?.DeleteAllSelected();
            return _deletedTrees != null && _deletedTrees.Count > 0;
        }

        internal override void Undo()
        {
            if (_deletedTrees == null || _deletedTrees.Count==0) return;

            foreach (var tree in _deletedTrees)
                TargetDrawing?.Add(tree);
        }

        internal override void Redo()
        {
            if (_deletedTrees == null || _deletedTrees.Count == 0) return;

            foreach (var tree in _deletedTrees)
                TargetDrawing?.DeleteComponent(tree);
        }
    }
}
