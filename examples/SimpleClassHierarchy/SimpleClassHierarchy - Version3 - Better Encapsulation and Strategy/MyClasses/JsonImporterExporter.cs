using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace MyClasses
{
    public class JsonImporterExporter : ImporterExporter
    {
        private static readonly DataContractJsonSerializer JsonSerializer = new DataContractJsonSerializer(typeof(List<ThingABob>),
                     new [] { typeof(ThingABob), typeof(Gadget), typeof(Widget) });

        public override void Write(List<ThingABob> data, string filename)
        {
            filename = AppendExtension(filename, "json");
            StreamWriter writer = new StreamWriter(filename);
            JsonSerializer.WriteObject(writer.BaseStream, data);
            writer.Close();
        }

        public override void Read(List<ThingABob> list, string filename)
        {
            filename = AppendExtension(filename, "json");
            StreamReader reader = new StreamReader(filename);
            List<ThingABob> data = JsonSerializer.ReadObject(reader.BaseStream) as List<ThingABob>;
            if (data!=null)
            {
                foreach(ThingABob thing in data)
                    list.Add(thing);
            }
        }
    }
}
