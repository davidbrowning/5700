using System.Drawing;

namespace AppLayer.Command
{
    public class SelectCommand : Command
    {
        private readonly Point _location;
         
        internal SelectCommand(params object[] commandParameters)
        {
            if (commandParameters.Length>0)
            _location = (Point) commandParameters[0];
        }

        public override void Execute()
        {
            TargetDrawing?.ToggleSelectionAtPosition(_location);
        }

    }
}
