using System.Collections.Generic;

namespace Expressions.Iterators
{
    public abstract class Iterator
    {
        protected Stack<NodeMarker> NodesToVisit = new Stack<NodeMarker>();
        protected Expression CurrentNode;

        protected Iterator(Expression firstNode)
        {
            if (firstNode!=null)
                NodesToVisit.Push(new NodeMarker() { Node = firstNode } );
        }

        public Expression Current => CurrentNode;

        public bool IsDone => CurrentNode == null && NodesToVisit.Count == 0;

        public abstract bool MoveNext();

        protected class NodeMarker
        {
            public Expression Node { get; set; }
            public bool HasMarkedChildren { get; set; }
        }
    }
}
