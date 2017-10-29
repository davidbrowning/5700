using System;
using System.Collections.Generic;

namespace AppLayer.DrawingComponents
{
    public class ComponentFactory
    {
        private static ComponentFactory _instance;
        private static readonly object MyLock = new object();

        private ComponentFactory() { }

        public static ComponentFactory Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance == null)
                        _instance = new ComponentFactory();
                }
                return _instance;
            }
        }

        public string ResourceNamePattern { get; set; }
        public Type ReferenceType { get; set; }

        private readonly Dictionary<string, ComponentWithIntrinsicState> _sharedComponents = new Dictionary<string, ComponentWithIntrinsicState>();

        public ComponentWithAllState GetComponents(ComponentExtrinsicState extrinsicState)
        {
            string resourceName = string.Format(ResourceNamePattern, extrinsicState.ComponentType);

            ComponentWithIntrinsicState treeWithIntrinsicState;
            if (_sharedComponents.ContainsKey(extrinsicState.ComponentType))
                treeWithIntrinsicState = _sharedComponents[extrinsicState.ComponentType];
            else
            {
                treeWithIntrinsicState = new ComponentWithIntrinsicState();
                treeWithIntrinsicState.LoadFromResource(resourceName, ReferenceType);
                _sharedComponents.Add(extrinsicState.ComponentType, treeWithIntrinsicState);
            }

            return new ComponentWithAllState(treeWithIntrinsicState, extrinsicState);
        }
    }
}
