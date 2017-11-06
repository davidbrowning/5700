using System;
using System.Drawing;
using AppLayer.DrawingComponents;
using System.Windows.Forms;

namespace AppLayer.Command
{
    public class AddRelationshipCommand : Command
    {
        private const int NormalWidth = 80;
        private const int NormalHeight = 80;

        private readonly string _relationshipType;
        private Point _location;
        private Point _startingPoint;
        private readonly float _scale;
        private Element _relationshipAdded;
        internal AddRelationshipCommand() { }

        /// <summary>
        /// Constructor
        /// 
        /// </summary>
        /// <param name="commandParameters">An array of parameters, where
        ///     [1]: string     relationship type -- a fully qualified resource name
        ///     [2]: Point      center location for the relationship, defaut = top left corner
        ///     [3]: float      scale factor</param>
        internal AddRelationshipCommand(params object[] commandParameters)
        {
            if (commandParameters.Length>0)
                _relationshipType = commandParameters[0] as string;

            if (commandParameters.Length > 1)
                _location = (Point) commandParameters[1];
            else
                _location = new Point(0, 0);

            if (commandParameters.Length > 2)
                _scale = (float) commandParameters[2];
            else
                _scale = 1.0F;
            if(commandParameters.Length > 3)
            {
                _startingPoint = (Point)commandParameters[3];
            }
        }

        public override bool Execute()
        {
            if (string.IsNullOrWhiteSpace(_relationshipType) || TargetDrawing==null) return false;

            var relationshipSize = new Size()
            {
                Width = Convert.ToInt16(Math.Round(NormalWidth * _scale, 0)),
                Height = Convert.ToInt16(Math.Round(NormalHeight * _scale, 0))
            };
            //var relationshipLocation = new Point(_location.X - relationshipSize.Width / 2, _location.Y - relationshipSize.Height / 2);
            var relationshipLocation = new Point(_location.X, _location.Y);
            var relationshipStartingPoint = new Point(_startingPoint.X,_startingPoint.Y);

            var extrinsicState = new RelationshipExtrinsicState()
            {
                RelationshipType = _relationshipType,
                Location = relationshipLocation,
                StartingPoint = relationshipStartingPoint,
                Size = relationshipSize
            };
            _relationshipAdded = RelationshipFactory.Instance.GetRelationship(extrinsicState);
            TargetDrawing.Add(_relationshipAdded);

            return true;
        }

        internal override void Undo()
        {
            TargetDrawing.DeleteElement(_relationshipAdded);
        }

        internal override void Redo()
        {
            TargetDrawing.Add(_relationshipAdded);
        }
    }
}
