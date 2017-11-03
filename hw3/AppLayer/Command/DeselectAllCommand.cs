using System;
using System.Collections.Generic;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class DeselectAllCommand : Command
    {
        private List<Element> _selectedElements; 
        internal DeselectAllCommand() { }

        public override bool Execute()
        {
            _selectedElements =  TargetDrawing?.DeselectAll();
            return _selectedElements != null && _selectedElements.Count > 0;
        }

        internal override void Undo()
        {
            if (_selectedElements == null || _selectedElements.Count == 0) return;

            foreach (var element in _selectedElements)
            {
                if (!element.IsSelected)
                {
                    element.IsSelected = true;
                    TargetDrawing.IsDirty = true;
                }
            }

        }
        internal override void Redo()
        {
            if (_selectedElements == null || _selectedElements.Count == 0) return;

            foreach (var element in _selectedElements)
            {
                if (element.IsSelected)
                {
                    element.IsSelected = false;
                    TargetDrawing.IsDirty = true;
                }
            }
        }
    }
}
