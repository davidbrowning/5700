using System;

namespace AppLayer.Command
{
    public class DeselectAllCommand : Command
    {
        internal DeselectAllCommand() { }

        public override void Execute()
        {
            TargetDrawing?.DeselectAll();
        }
    }
}
