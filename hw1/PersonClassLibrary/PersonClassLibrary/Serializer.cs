using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace PersonClassLibrary
{
    public abstract class Serializer 
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public abstract void Write(List<Person> list, string filename);
        public abstract void Read(List<Person> list, string filename);

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
