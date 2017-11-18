namespace Expressions.Iterators
{
    public class PostOrderIterator : Iterator
    {
        public PostOrderIterator(Expression firstNode) : base(firstNode) { }

        public override bool MoveNext()
        {
            SetCurrentNode();
            return !IsDone;
        }

        private void SetCurrentNode()
        {
            // Visit the next node on the stack
            if (NodesToVisit.Count == 0)
                CurrentNode = null;
            else
            {
                var marker = NodesToVisit.Peek();
                if (!marker.HasMarkedChildren)
                {
                    // Mark this node's as having it's children pushed onto the stack
                    marker.HasMarkedChildren = true;

                    // Add this node's children to the stack in reverse order
                    for (int i = marker.Node.SubExpressions.Count - 1; i >= 0; i--)
                        NodesToVisit.Push(new NodeMarker() { Node = marker.Node.SubExpressions[i] });

                    // Recursively call this method to try the top of the stack again
                    SetCurrentNode();
                }
                else
                {
                    // Pop the stack of the stack and use the node as the current node
                    CurrentNode = NodesToVisit.Pop().Node;
                }
            }
        }
    }
}
