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
        private static readonly DataContractJsonSerializer JsonSerializer =
                new DataContractJsonSerializer(typeof(List<Element>), new [] { typeof(Element), typeof(Tree), typeof(TreeWithAllState), typeof(TreeExtrinsicState), typeof(LabeledBox), typeof(Line) });

        private readonly List<Element> _elements = new List<Element>();
        private readonly object _myLock = new object();

        public bool IsDirty { get; set; } = true;

        public List<Element> GetCloneOfElements()
        {
            var cloneList = new List<Element>();
            lock (_myLock)
            {
                cloneList.AddRange(_elements.Select(element => element.Clone()));
            }

            return cloneList;           
        }

        public void Clear()
        {
            lock (_myLock)
            {
                _elements.Clear();
                IsDirty = true;
            }
        }

        public void LoadFromStream(Stream stream)
        {
            var loadedElements = JsonSerializer.ReadObject(stream) as List<Element>;

            if (loadedElements == null || loadedElements.Count == 0) return;

            lock (_myLock)
            {
                // Since only the extrinsic state is saved, recreate the full tree objects
                foreach (var element in loadedElements)
                {
                    var tmpTree = element as TreeWithAllState;
                    if (tmpTree != null)
                    {
                        Tree fullTree = TreeFactory.Instance.GetTree(tmpTree.ExtrinsicState);
                        _elements.Add(fullTree);
                    }
                    else
                    {
                        _elements.Add(element);
                    }
                }
                IsDirty = true;
            }
        }

        public void SaveToStream(Stream stream)
        {
            lock (_myLock)
            {
                JsonSerializer.WriteObject(stream, _elements);
            }
        }

        public void Add(Element element)
        {
            if (element == null) return;

            lock (_myLock)
            {
                _elements.Add(element);
                IsDirty = true;
            }
        }

        public List<Element> DeleteAllSelected()
        {
            List<Element> elementsToDelete;
            lock (_myLock)
            {
                elementsToDelete = _elements.FindAll(t => t.IsSelected);
                _elements.RemoveAll(t => t.IsSelected);
                IsDirty = true;
            }

            return elementsToDelete;
        }

        public void DeleteElement(Element element)
        {
            lock (_myLock)
            {
                _elements.Remove(element);
                IsDirty = true;
            }
        }

        public Element FindElementAtPosition(Point point)
        {
            Element result;
            lock (_myLock)
            {
                result = _elements.FindLast(t => t.ContainsPoint(point));
            }
            return result;
        }

        public List<Element> DeselectAll()
        {
            var selectedElements = new List<Element>();
            lock (_myLock)
            {
                foreach (var t in _elements)
                {
                    if (t.IsSelected)
                    {
                        selectedElements.Add(t);
                        t.IsSelected = false;
                    }
                }
                IsDirty = true;
            }
            return selectedElements;
        }

        public bool Draw(Graphics graphics, bool redrawEvenIfNotDirty = false)
        {
            lock (_myLock)
            {
                if (!IsDirty && !redrawEvenIfNotDirty) return false;

                graphics.Clear(Color.White);
                foreach (var t in _elements)
                    t.Draw(graphics);
                IsDirty = false;
            }
            return true;
        }

    }
}
