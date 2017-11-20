using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SodokuSolver
{
    public abstract class Serializer 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public abstract void Write(Puzzle puzzle, string filename);
        // must read puzzle into puzzle's Board member. 
        public abstract bool Read(Puzzle puzzle, string filename);
        public abstract void Read(Puzzle puzzle, string filename, char delimiter);

        protected string AppendExtension(string filename, string extension)
        {
            if (string.IsNullOrWhiteSpace(extension))
                extension = string.Empty;

            if (string.IsNullOrWhiteSpace(filename))
                filename = string.Empty;

            if (!extension.StartsWith("."))
                extension = "." + extension;

            if (!filename.EndsWith(extension))
                filename += extension;

            return filename;
        }
    }
}
