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

        public bool IsDirty { get; set; } = true;

        public List<Tree> GetCloneOfTrees()
        {
            var cloneList = new List<Tree>();
            var extrinsicStates = new List<TreeExtrinsicState>();
            lock (_myLock)
            {
                extrinsicStates.AddRange(_trees.OfType<TreeWithAllState>().Select(t => t.ExtrinsicStatic));
                foreach (var extrinsicState in extrinsicStates)
                {
                    Tree tree = TreeFactory.Instance.GetTree(extrinsicState);
                    cloneList.Add(tree);
                }
            }

            return cloneList;           
        }

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

        public List<Tree> DeleteAllSelected()
        {
            List<Tree> treesToDelete;
            lock (_myLock)
            {
                treesToDelete = _trees.FindAll(t => t.IsSelected);
                _trees.RemoveAll(t => t.IsSelected);
                IsDirty = true;
            }

            return treesToDelete;
        }

        public void DeleteTree(Tree tree)
        {
            lock (_myLock)
            {
                _trees.Remove(tree);
                IsDirty = true;
            }
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

        public List<Tree> DeselectAll()
        {
            var selectedTrees = new List<Tree>();
            lock (_myLock)
            {
                foreach (var t in _trees)
                {
                    if (t.IsSelected)
                    {
                        selectedTrees.Add(t);
                        t.IsSelected = false;
                    }
                }
                IsDirty = true;
            }
            return selectedTrees;
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
