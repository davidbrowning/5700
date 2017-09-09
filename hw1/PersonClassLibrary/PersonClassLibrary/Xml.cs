using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;

namespace PersonClassLibrary
{
    public class Xml : Serializer 
    {
        private static readonly XmlSerializer XmlSerializer = new XmlSerializer(typeof(List<Person>),
                        new[] { typeof(Person)});

        override public void Write(List<Person> list, string filename)
        {
            StreamWriter writer = null;
            try
            {
                filename = AppendExtension(filename, "xml");
                writer = new StreamWriter(filename);
                XmlSerializer.Serialize(writer.BaseStream, this);
                writer.Close();
            }
            catch (Exception err)
            {
                Console.WriteLine($"Cannot write to {filename}: {err.Message}");
                throw;
            }
            finally
            {
                writer?.Close();
            }

        }
        override public void Read(List<Person> list, string filename)
        {
            StreamReader reader = null;
            try
            {
                filename = AppendExtension(filename, "xml");
                reader = new StreamReader(filename);
                List<Person> input = XmlSerializer.Deserialize(reader.BaseStream) as List<Person>;
                if (input != null)
                {
                    foreach (Person thing in input)
                        list.Add(thing);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine($"Cannot read from {filename}: {err.Message}");
                throw;
            }
            finally
            {
                reader?.Close();
            }

        }
    }
}
