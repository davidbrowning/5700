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
                        new[] { typeof(Person)});

        override public void Write(List<Person> list, string filename)
        {
            StreamWriter writer = null;
            try
            {
                filename = AppendExtension(filename, "json");
                writer = new StreamWriter(filename);
                JsonSerializer.WriteObject(writer.BaseStream, this);
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
                filename = AppendExtension(filename, "json");
                reader = new StreamReader(filename);
                List<Person> input = JsonSerializer.ReadObject(reader.BaseStream) as List<Person>;
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
