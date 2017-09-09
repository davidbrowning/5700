using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace PersonClassLibrary
{
    public class Xml : Serializer
    {
        private static readonly XmlSerializer XmlSerializer = new XmlSerializer(typeof(List<Person>),
                        new[] { typeof(Person) });

        public override void Write(List<Person> data, string filename)
        {
            filename = AppendExtension(filename, "xml");
            StreamWriter writer = new StreamWriter(filename);
            XmlSerializer.Serialize(writer, data);
            writer.Close();
        }

        public override void Read(List<Person> list, string filename)
        {
            filename = AppendExtension(filename, "xml");
            StreamReader reader = new StreamReader(filename);
            List<Person> data = XmlSerializer.Deserialize(reader.BaseStream) as List<Person>;
            if (data != null)
            {
                foreach (Person thing in data)
                    list.Add(thing);
            }
        }
    }
}
