using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;

namespace MyClasses
{
    public class ThingABobCollection : List<ThingABob>
    {
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<ThingABob>),
                        new[] { typeof(ThingABob), typeof(Gadget), typeof(Widget) });


        private static readonly XmlSerializer XmlSerializer = new XmlSerializer(typeof(List<ThingABob>),
                                new[] { typeof(ThingABob), typeof(Gadget), typeof(Widget) });

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
                List<ThingABob> data = JsonSerializer.ReadObject(reader.BaseStream) as List<ThingABob>;
                if (data != null)
                {
                    foreach (ThingABob thing in data)
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
                List<ThingABob> data = XmlSerializer.Deserialize(reader.BaseStream) as List<ThingABob>;
                if (data != null)
                {
                    foreach (ThingABob thing in data)
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
