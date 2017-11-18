namespace Expressions.Iterators
{
    public class PreOrderIterator : Iterator
    {
        public PreOrderIterator(Expression firstNode) : base(firstNode) { }

        public override bool MoveNext()
        {
            if (NodesToVisit.Count == 0)
                CurrentNode = null;
            else
            {
                // Visit the next node on the stack
                var marker = NodesToVisit.Pop();
                CurrentNode = marker.Node;

                // Add this node's children to the stack in reverse order
                for (var i = CurrentNode.SubExpressions.Count - 1; i >= 0; i--)
                    NodesToVisit.Push(new NodeMarker() { Node = CurrentNode.SubExpressions[i] });
            }

            return !IsDone;
        }
    }
}
