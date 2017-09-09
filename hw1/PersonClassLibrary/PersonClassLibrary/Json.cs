using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace PersonClassLibrary
{
    public class Json : Serializer
    {
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<Person>),
                     new[] { typeof(Person) });

        public override void Write(List<Person> data, string filename)
        {
            filename = AppendExtension(filename, "json");
            StreamWriter writer = new StreamWriter(filename);
            JsonSerializer.WriteObject(writer.BaseStream, data);
            writer.Close();
        }

        public override void Read(List<Person> list, string filename)
        {
            filename = AppendExtension(filename, "json");
            StreamReader reader = new StreamReader(filename);
            List<Person> data = JsonSerializer.ReadObject(reader.BaseStream) as List<Person>;
            if (data != null)
            {
                foreach (Person thing in data)
                    list.Add(thing);
            }
        }
    }
}
