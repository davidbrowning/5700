using System.Drawing;
using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    public class AddBoxCommand : Command
    {
        private readonly Point? _corner;
        private readonly Size? _size;
        private readonly string _label;
        private Element _labelBox;
        internal AddBoxCommand() { }

        /// <summary>
        /// Constructor
        /// 
        /// </summary>
        /// <param name="commandParameters">An array of parameters, where
        ///     [1]: Point      start of the line
        ///     [2]: Point      end of the line
        /// </param>
        internal AddBoxCommand(params object[] commandParameters)
        {
            if (commandParameters.Length > 0)
                _label = (string) commandParameters[0];

            if (commandParameters.Length > 1)
                _corner = (Point) commandParameters[1];

            if (commandParameters.Length > 1)
                _size = (Size) commandParameters[2];
        }

        public override bool Execute()
        {
            if (_label == null || _corner == null || _size == null) return false;

            _labelBox = new ClassBox() { Corner = (Point) _corner, Size = (Size) _size, Label = _label};
            TargetDrawing.Add(_labelBox);

            return true;
        }

        internal override void Undo()
        {
            TargetDrawing.DeleteElement(_labelBox);
        }

        internal override void Redo()
        {
            TargetDrawing.Add(_labelBox);
        }
    }
}
