using System;
using System.Collections.Generic;

namespace AppLayer.DrawingComponents
{
    public class TreeFactory
    {
        public string ResourceNamePattern { get; set; }
        public Type ReferenceType { get; set; }

        private readonly Dictionary<string, TreeWithIntrinsicState> _sharedTrees = new Dictionary<string, TreeWithIntrinsicState>();

        public TreeWithAllState GetTree(TreeExtrinsicState extrinsicState)
        {
            string resourceName = string.Format(ResourceNamePattern, extrinsicState.TreeType);

            TreeWithIntrinsicState treeWithIntrinsicState;
            if (_sharedTrees.ContainsKey(extrinsicState.TreeType))
                treeWithIntrinsicState = _sharedTrees[extrinsicState.TreeType];
            else
            {
                treeWithIntrinsicState = new TreeWithIntrinsicState();
                treeWithIntrinsicState.LoadFromResource(resourceName, ReferenceType);
                _sharedTrees.Add(extrinsicState.TreeType, treeWithIntrinsicState);
            }

            return new TreeWithAllState(treeWithIntrinsicState, extrinsicState);
        }
    }
}
