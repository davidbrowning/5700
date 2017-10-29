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
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<ComponentExtrinsicState>));

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
            var extrinsicStates = JsonSerializer.ReadObject(stream) as List<ComponentExtrinsicState>;
            if (extrinsicStates == null) return;

            lock (_myLock)
            {
                foreach (var extrinsicState in extrinsicStates)
                {
                    Component tree = ComponentFactory.Instance.GetComponents(extrinsicState);
                    _components.Add(tree);
                }
                IsDirty = true;
            }
        }

        public void SaveToStream(Stream stream)
        {
            var extrinsicStates = new List<ComponentExtrinsicState>();
            lock (_myLock)
            {
                extrinsicStates.AddRange(_components.OfType<ComponentWithAllState>().Select(t => t.ExtrinsicStatic));
            }
            JsonSerializer.WriteObject(stream, extrinsicStates);
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
