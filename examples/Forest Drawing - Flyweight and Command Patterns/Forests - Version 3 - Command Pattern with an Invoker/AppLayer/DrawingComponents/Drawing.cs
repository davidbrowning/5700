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
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<TreeExtrinsicState>));

        private readonly List<Tree> _trees = new List<Tree>();
        private readonly object _myLock = new object();

        public bool IsDirty { get; private set; } = true;

        public void Clear()
        {
            lock (_myLock)
            {
                _trees.Clear();
                IsDirty = true;
            }
        }

        public void LoadFromStream(Stream stream)
        {
            var extrinsicStates = JsonSerializer.ReadObject(stream) as List<TreeExtrinsicState>;
            if (extrinsicStates == null) return;

            lock (_myLock)
            {
                _trees.Clear();
                foreach (var extrinsicState in extrinsicStates)
                {
                    Tree tree = TreeFactory.Instance.GetTree(extrinsicState);
                    _trees.Add(tree);
                }
                IsDirty = true;
            }
        }

        public void SaveToStream(Stream stream)
        {
            var extrinsicStates = new List<TreeExtrinsicState>();
            lock (_myLock)
            {
                extrinsicStates.AddRange(_trees.OfType<TreeWithAllState>().Select(t => t.ExtrinsicStatic));
            }
            JsonSerializer.WriteObject(stream, extrinsicStates);
        }

        public void Add(Tree tree)
        {
            if (tree == null) return;

            lock (_myLock)
            {
                _trees.Add(tree);
                IsDirty = true;
            }
        }

        public void DeleteAllSelected()
        {
            lock (_myLock)
            {
                _trees.RemoveAll(t => t.IsSelected);
                IsDirty = true;
            }
        }

        public void ToggleSelectionAtPosition(Point location)
        {
            var tree = FindTreeAtPosition(location);

            if (tree != null)
                tree.IsSelected = !tree.IsSelected;

            IsDirty = true;
        }

        public Tree FindTreeAtPosition(Point location)
        {
            Tree result;
            lock (_myLock)
            {
                result = _trees.FindLast(t => location.X >= t.Location.X &&
                                              location.X < t.Location.X + t.Size.Width &&
                                              location.Y >= t.Location.Y &&
                                              location.Y < t.Location.Y + t.Size.Height);
            }
            return result;
        }

        public void DeselectAll()
        {
            lock (_myLock)
            {
                foreach (var t in _trees)
                    t.IsSelected = false;
                IsDirty = true;
            }
        }

        public bool Draw(Graphics graphics, bool redrawEvenIfNotDirty = false)
        {
            lock (_myLock)
            {
                if (!IsDirty && !redrawEvenIfNotDirty) return false;

                graphics.Clear(Color.White);
                foreach (var t in _trees)
                    t.Draw(graphics);
                IsDirty = false;
            }
            return true;
        }

    }
}
