using System.Collections.Generic;
using System.IO;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class LoadCommand : Command
    {
        private readonly string _filename;
        private List<Element> _previousElements;

        internal LoadCommand() { }
        internal LoadCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                _filename = commandParameters[0] as string;
        }

        public override bool Execute()
        {
            _previousElements = TargetDrawing.GetCloneOfElements();
            TargetDrawing?.Clear();

            StreamReader reader = new StreamReader(_filename);
            TargetDrawing?.LoadFromStream(reader.BaseStream);
            reader.Close();

            return true;
        }

        internal override void Undo()
        {
            TargetDrawing.Clear();

            if (_previousElements == null || _previousElements.Count == 0) return;

            foreach (var element in _previousElements)
                TargetDrawing?.Add(element);
        }

        internal override void Redo()
        {
            Execute();
        }
    }
}
