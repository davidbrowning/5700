namespace Expressions.Iterators
{
    /// <summary>
    /// For expressions tree's, in-order travel with have the following meaning:
    ///     Nodes with 1 child: visit child then this node
    ///     Nodes with 2 children: visit first child, this node, then second child
    ///     Nodes with 3+ children: visit this node, then each child.
    /// </summary>
    public class InOrderIterator : Iterator
    {
        public InOrderIterator(Expression firstNode) : base(firstNode) { }

        public override bool MoveNext()
        {
            SetCurrentNode();

            return !IsDone;
        }

        private void SetCurrentNode()
        {
            if (NodesToVisit.Count == 0)
                CurrentNode = null;
            else
            {
                // Pop this top of the stack, recognizing that it might be pushed back
                // on with its children
                var marker = NodesToVisit.Pop();

                if (!marker.HasMarkedChildren)
                {
                    //Mark this node as having it's children pushed onto the stack

                    marker.HasMarkedChildren = true;
                    switch (marker.Node.SubExpressions.Count)
                    {
                        case 0:
                            NodesToVisit.Push(marker);
                            break;
                        case 1:
                            NodesToVisit.Push(new NodeMarker() { Node = marker.Node.SubExpressions[0] });
                            NodesToVisit.Push(marker);
                            break;
                        case 2:
                            NodesToVisit.Push(new NodeMarker() { Node = marker.Node.SubExpressions[1] });
                            NodesToVisit.Push(marker);
                            NodesToVisit.Push(new NodeMarker() { Node = marker.Node.SubExpressions[0] });
                            break;
                        case 3:
                            for (int i = marker.Node.SubExpressions.Count - 1; i >= 0; i--)
                                NodesToVisit.Push(new NodeMarker() { Node = marker.Node.SubExpressions[i] });
                            NodesToVisit.Push(marker);
                            break;
                    }

                    // Recursively call this method to try to the stop of the stack again.
                    SetCurrentNode();
                }
                else
                    CurrentNode = marker.Node;
            }
        }
    }
}
