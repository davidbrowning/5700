using System.Collections.Generic;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class NewCommand : Command
    {
        private List<Tree> _previousTrees; 
        internal NewCommand() {}

        public override bool Execute()
        {
            _previousTrees = TargetDrawing.GetCloneOfTrees();
            TargetDrawing?.Clear();
            return _previousTrees != null && _previousTrees.Count > 0;
        }

        internal override void Undo()
        {
            if (_previousTrees == null || _previousTrees.Count == 0) return;

            foreach (var tree in _previousTrees)
                TargetDrawing?.Add(tree);
        }

        internal override void Redo()
        {
            Execute();
        }
    }
}
