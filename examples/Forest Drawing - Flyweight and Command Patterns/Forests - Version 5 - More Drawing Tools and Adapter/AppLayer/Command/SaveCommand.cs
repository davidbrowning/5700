using System.IO;
using System.Runtime.Serialization.Json;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class SaveCommand : Command
    {
        private readonly string _filename;
        internal SaveCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                _filename = commandParameters[0] as string;
        }

        public override bool Execute()
        {
            StreamWriter writer = new StreamWriter(_filename);
            TargetDrawing?.SaveToStream(writer.BaseStream);
            writer.Close();

            return true;
        }

        internal override void Undo()
        {
            // Do nothing -- we don't want to delete the saved file.
        }

        internal override void Redo()
        {
            Execute();
        }
    }
}
