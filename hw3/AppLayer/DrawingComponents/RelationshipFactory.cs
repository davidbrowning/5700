using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace AppLayer.DrawingComponents
{
    public class RelationshipFactory
    {
        private static RelationshipFactory _instance;
        private static readonly object MyLock = new object();

        private RelationshipFactory() { }

        public static RelationshipFactory Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance == null)
                        _instance = new RelationshipFactory();
                }
                return _instance;
            }
        }

        public string ResourceNamePattern { get; set; }
        public Type ReferenceType { get; set; }

        private readonly Dictionary<string, RelationshipWithIntrinsicState> _sharedRelationships = new Dictionary<string, RelationshipWithIntrinsicState>();

        public RelationshipWithAllState GetRelationship(RelationshipExtrinsicState extrinsicState)
        {
            RelationshipWithIntrinsicState relationshipWithIntrinsicState;
            if (_sharedRelationships.ContainsKey(extrinsicState.RelationshipType))
                relationshipWithIntrinsicState = _sharedRelationships[extrinsicState.RelationshipType];
            else
            {
                relationshipWithIntrinsicState = new RelationshipWithIntrinsicState();
                string resourceName = string.Format(ResourceNamePattern, extrinsicState.RelationshipType);
                relationshipWithIntrinsicState.LoadFromResource(resourceName, ReferenceType);
                Pen p;
                switch (resourceName)
                {
                    case ("aggregation"):
                        p = new Pen(Color.Red);
                        break;
                    case ("inheritance"):
                        p = new Pen(Color.Green);
                        break;
                    case ("composition"):
                        p = new Pen(Color.Blue);
                        break;
                    case ("dependency"):
                        p = new Pen(Color.Yellow);
                        break;
                    default:
                        p = new Pen(Color.Black);
                        break;
                }
                p.Width = 5;
                relationshipWithIntrinsicState.SelectPen(p);
                _sharedRelationships.Add(extrinsicState.RelationshipType, relationshipWithIntrinsicState);
            }

            return new RelationshipWithAllState(relationshipWithIntrinsicState, extrinsicState);
        }
    }
}
