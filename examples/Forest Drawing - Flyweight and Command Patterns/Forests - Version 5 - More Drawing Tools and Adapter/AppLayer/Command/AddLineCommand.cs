using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class AddLineCommand : Command
    {
        private readonly Point? _start;
        private readonly Point? _end;
        private Element _line;
        internal AddLineCommand() { }

        /// <summary>
        /// Constructor
        /// 
        /// </summary>
        /// <param name="commandParameters">An array of parameters, where
        ///     [1]: Point      start of the line
        ///     [2]: Point      end of the line
        /// </param>
        internal AddLineCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                _start = (Point) commandParameters[0];

            if (commandParameters.Length > 1)
                _end = (Point) commandParameters[1];
        }

        public override bool Execute()
        {
            if (_start==null || _end==null) return false;

            _line = new Line() {Start = (Point) _start, End = (Point) _end};
            TargetDrawing.Add(_line);

            return true;
        }

        internal override void Undo()
        {
            TargetDrawing.DeleteElement(_line);
        }

        internal override void Redo()
        {
            TargetDrawing.Add(_line);
        }

    }
}
