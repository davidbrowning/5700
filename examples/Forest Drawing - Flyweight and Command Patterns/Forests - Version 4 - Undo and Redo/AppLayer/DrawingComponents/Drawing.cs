using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace AppLayer.DrawingComponents
{
    // NOTE: This class at least one  problem that is hurting coupling and cohesion

    public class Drawing
    {
<<<<<<< HEAD
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<ComponentExtrinsicState>));
=======
        private static readonly DataContractJsonSerializer JsonSerializer =
                new DataContractJsonSerializer(typeof(List<Tree>), new [] { typeof(Tree), typeof(TreeWithAllState), typeof(TreeExtrinsicState) });
>>>>>>> 883e0355e2e7d796800a66f2e050eb4a2fb20b5a

        private readonly List<Component> _components = new List<Component>();
        private readonly object _myLock = new object();

        public bool IsDirty { get; set; } = true;

        public List<Component> GetCloneOfComponents()
        {
            var cloneList = new List<Component>();
            var extrinsicStates = new List<ComponentExtrinsicState>();
            lock (_myLock)
            {
                extrinsicStates.AddRange(_components.OfType<ComponentWithAllState>().Select(t => t.ExtrinsicStatic));
                foreach (var extrinsicState in extrinsicStates)
                {
                    Component component = ComponentFactory.Instance.GetComponents(extrinsicState);
                    cloneList.Add(component);
                }
            }

            return cloneList;           
        }

        public void Clear()
        {
            lock (_myLock)
            {
                _components.Clear();
                IsDirty = true;
            }
        }

        public void LoadFromStream(Stream stream)
        {
<<<<<<< HEAD
            var extrinsicStates = JsonSerializer.ReadObject(stream) as List<ComponentExtrinsicState>;
            if (extrinsicStates == null) return;
=======
            var loadedTrees = JsonSerializer.ReadObject(stream) as List<Tree>;

            if (loadedTrees == null || loadedTrees.Count == 0) return;
>>>>>>> 883e0355e2e7d796800a66f2e050eb4a2fb20b5a

            lock (_myLock)
            {
                // Since only the extrinsic state is saved, recreate the full tree objects
                foreach (var partialTree in loadedTrees)
                {
<<<<<<< HEAD
                    Component tree = ComponentFactory.Instance.GetComponents(extrinsicState);
                    _components.Add(tree);
=======
                    TreeWithAllState tmpTree = partialTree as TreeWithAllState;
                    if (tmpTree != null)
                    {
                        Tree fullTree = TreeFactory.Instance.GetTree(tmpTree.ExtrinsicStatic);
                        _trees.Add(fullTree);
                    }
>>>>>>> 883e0355e2e7d796800a66f2e050eb4a2fb20b5a
                }
                IsDirty = true;
            }
        }

        public void SaveToStream(Stream stream)
        {
<<<<<<< HEAD
            var extrinsicStates = new List<ComponentExtrinsicState>();
            lock (_myLock)
            {
                extrinsicStates.AddRange(_components.OfType<ComponentWithAllState>().Select(t => t.ExtrinsicStatic));
=======
            lock (_myLock)
            {
                JsonSerializer.WriteObject(stream, _trees);
>>>>>>> 883e0355e2e7d796800a66f2e050eb4a2fb20b5a
            }
        }

        public void Add(Component tree)
        {
            if (tree == null) return;

            lock (_myLock)
            {
                _components.Add(tree);
                IsDirty = true;
            }
        }

        public List<Component> DeleteAllSelected()
        {
            List<Component> componentsToDelete;
            lock (_myLock)
            {
                componentsToDelete = _components.FindAll(t => t.IsSelected);
                _components.RemoveAll(t => t.IsSelected);
                IsDirty = true;
            }

            return componentsToDelete;
        }

        public void DeleteComponent(Component component)
        {
            lock (_myLock)
            {
                _components.Remove(component);
                IsDirty = true;
            }
        }

        public Component FindTreeAtPosition(Point location)
        {
            Component result;
            lock (_myLock)
            {
                result = _components.FindLast(t => location.X >= t.Location.X &&
                                              location.X < t.Location.X + t.Size.Width &&
                                              location.Y >= t.Location.Y &&
                                              location.Y < t.Location.Y + t.Size.Height);
            }
            return result;
        }

        public List<Component> DeselectAll()
        {
            var selectedComponents = new List<Component>();
            lock (_myLock)
            {
                foreach (var t in _components)
                {
                    if (t.IsSelected)
                    {
                        selectedComponents.Add(t);
                        t.IsSelected = false;
                    }
                }
                IsDirty = true;
            }
            return selectedComponents;
        }

        public bool Draw(Graphics graphics, bool redrawEvenIfNotDirty = false)
        {
            lock (_myLock)
            {
                if (!IsDirty && !redrawEvenIfNotDirty) return false;

                graphics.Clear(Color.White);
                foreach (var t in _components)
                    t.Draw(graphics);
                IsDirty = false;
            }
            return true;
        }

    }
}
