using System;

namespace AppLayer.Command
{
    public class NewCommand : Command
    {
        internal NewCommand() {}

        public override void Execute()
        {
            TargetDrawing?.Clear();
        }
    }
}
