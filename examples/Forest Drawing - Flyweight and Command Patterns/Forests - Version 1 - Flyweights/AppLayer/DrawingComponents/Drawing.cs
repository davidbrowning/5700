using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Json;

namespace AppLayer.DrawingComponents
{
    // NOTE: This class at least one  problem that is hurting coupling and cohesion

    public class Drawing
    {
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<TreeExtrinsicState>));

        private readonly List<Tree> _trees = new List<Tree>();
        private readonly object _myLock = new object();

        public TreeFactory Factory { get; set; }
        public Tree SelectedTree { get; set; }
        public bool IsDirty { get; set; } = true;

        public void Load(string filename)
        {
            StreamReader reader = new StreamReader(filename);
            var extrinsicStates = JsonSerializer.ReadObject(reader.BaseStream) as List<TreeExtrinsicState>;
            if (extrinsicStates == null) return;

            lock (_myLock)
            {
                _trees.Clear();
                foreach (TreeExtrinsicState extrinsicState in extrinsicStates)
                {
                    Tree tree = Factory.GetTree(extrinsicState);
                    _trees.Add(tree);
                }
                IsDirty = true;
            }
            reader.Close();
        }

        public void Save(string filename)
        {
            StreamWriter writer = new StreamWriter(filename);
            List<TreeExtrinsicState> extrinsicStates = new List<TreeExtrinsicState>();
            lock (_myLock)
            {
                foreach (Tree tree in _trees)
                {
                    TreeWithAllState t = tree as TreeWithAllState;
                    if (t != null)
                        extrinsicStates.Add(t.ExtrinsicStatic);
                }
            }
            JsonSerializer.WriteObject(writer.BaseStream, extrinsicStates);
            writer.Close();
        }

        public void Add(Tree tree)
        {
            if (tree != null)
            {
                lock (_myLock)
                {
                    _trees.Add(tree);
                    IsDirty = true;
                }
            }
        }

        public void RemoveTree(Tree tree)
        {
            if (tree != null)
            {
                lock (_myLock)
                {
                    if (SelectedTree == tree)
                        SelectedTree = null;
                    _trees.Remove(tree);
                    IsDirty = true;
                }
            }
        }

        public void SelectTreeAtPosition(Point location)
        {
            if (SelectedTree != null)
                SelectedTree.IsSelected = false;

            SelectedTree = FindTreeAtPosition(location);

            if (SelectedTree != null)
                SelectedTree.IsSelected = true;

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
                /*
                    The above method call with a lamba predicate is the same as the following:
                for (var i=_trees.Count-1; i>=0; i--)
                {
                    if (location.X >= _trees[i].Location.X &&
                        location.X < _trees[i].Location.X + _trees[i].Size.Width &&
                        location.Y >= _trees[i].Location.Y &&
                        location.Y < _trees[i].Location.Y + _trees[i].Size.Height)
                    {
                        result = _trees[i];
                        break;
                    }
                }
                */
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

        public void RemoveSelectedTree()
        {
            if (SelectedTree != null)
            {
                RemoveTree(SelectedTree);
                SelectedTree = null;
            }
        }

        public bool Draw(Graphics graphics)
        {
            bool didARedraw = false;
            lock (_myLock)
            {
                if (IsDirty)
                {
                    graphics.Clear(Color.White);
                    foreach (Tree t in _trees)
                        t.Draw(graphics);
                    IsDirty = false;
                    didARedraw = true;
                }
            }
            return didARedraw;
        }

    }
}
