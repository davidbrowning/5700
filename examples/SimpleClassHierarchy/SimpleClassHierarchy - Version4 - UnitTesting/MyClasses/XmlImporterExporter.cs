using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace MyClasses
{
    public class XmlImporterExporter : ImporterExporter
    {
        private static readonly XmlSerializer XmlSerializer = new XmlSerializer(typeof(List<ThingABob>),
                        new [] { typeof(ThingABob), typeof(Gadget), typeof(Widget) });

        public override void Write(List<ThingABob> data, string filename)
        {
            filename = AppendExtension(filename, "xml");
            StreamWriter writer = new StreamWriter(filename);
            XmlSerializer.Serialize(writer, data);
            writer.Close();
        }

        public override void Read(List<ThingABob> list, string filename)
        {
            filename = AppendExtension(filename, "xml");
            StreamReader reader = new StreamReader(filename);
            List<ThingABob> data = XmlSerializer.Deserialize(reader.BaseStream) as List<ThingABob>;
            if (data != null)
            {
                foreach (ThingABob thing in data)
                    list.Add(thing);
            }
        }
    }
}
