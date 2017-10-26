using System;
using System.Collections.Generic;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class DeselectAllCommand : Command
    {
        private List<Tree> _selectedTrees; 
        internal DeselectAllCommand() { }

        public override bool Execute()
        {
            _selectedTrees =  TargetDrawing?.DeselectAll();
            return _selectedTrees != null && _selectedTrees.Count > 0;
        }

        internal override void Undo()
        {
            if (_selectedTrees == null || _selectedTrees.Count == 0) return;

            foreach (var tree in _selectedTrees)
            {
                if (!tree.IsSelected)
                {
                    tree.IsSelected = true;
                    TargetDrawing.IsDirty = true;
                }
            }

        }
        internal override void Redo()
        {
            if (_selectedTrees == null || _selectedTrees.Count == 0) return;

            foreach (var tree in _selectedTrees)
            {
                if (tree.IsSelected)
                {
                    tree.IsSelected = false;
                    TargetDrawing.IsDirty = true;
                }
            }
        }
    }
}
