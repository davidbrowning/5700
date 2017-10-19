namespace AppLayer.Command
{
    public class RemoveSelectedCommand : Command
    {
        internal RemoveSelectedCommand() { }

        public override void Execute()
        {
            TargetDrawing?.DeleteAllSelected();
        }
    }
}
