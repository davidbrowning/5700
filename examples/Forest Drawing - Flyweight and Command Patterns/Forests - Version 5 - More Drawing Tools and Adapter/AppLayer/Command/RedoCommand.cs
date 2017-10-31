namespace AppLayer.Command
{
    public class RedoCommand : Command
    {
        public override bool Execute()
        {
            // Do Nothing, since its execution will be handled by the Invoker directly
            return false;
        }

        internal override void Undo()
        {
            // Do Nothing
        }

        internal override void Redo()
        {
            // Do Nothing
        }
    }
}
