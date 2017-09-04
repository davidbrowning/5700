using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace PersonClassLibrary
{
    public class PersonCollection : List<Person>
    {
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<Person>),
                        new[] { typeof(Person)});


        private static readonly XmlSerializer XmlSerializer = new XmlSerializer(typeof(List<Person>),
                                new[] { typeof(Person)});

        public void WriteJson(string filename)
        {
            StreamWriter writer = null;
            try
            {
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

        public void WriteXml(string filename)
        {
            StreamWriter writer = null;
            try
            {
                writer = new StreamWriter(filename);
                XmlSerializer.Serialize(writer, this);
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

        public void ReadJson(string filename)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filename);
                List<Person> data = JsonSerializer.ReadObject(reader.BaseStream) as List<Person>;
                if (data != null)
                {
                    foreach (Person thing in data)
                        Add(thing);
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

        public void ReadXml(string filename)
        {
            StreamReader reader = null;
            try
            {
                reader = new StreamReader(filename);
                List<Person> data = XmlSerializer.Deserialize(reader.BaseStream) as List<Person>;
                if (data != null)
                {
                    foreach (Person thing in data)
                        Add(thing);
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
