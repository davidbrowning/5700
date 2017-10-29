using System.Collections.Generic;
using System.IO;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class LoadCommand : Command
    {
        private readonly string _filename;
        private List<Component> _previousTrees;

        internal LoadCommand() { }
        internal LoadCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                _filename = commandParameters[0] as string;
        }

        public override bool Execute()
        {
            _previousTrees = TargetDrawing.GetCloneOfComponents();
            TargetDrawing?.Clear();

            StreamReader reader = new StreamReader(_filename);
            TargetDrawing?.LoadFromStream(reader.BaseStream);
            reader.Close();

            return true;
        }

        internal override void Undo()
        {
            TargetDrawing.Clear();

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
