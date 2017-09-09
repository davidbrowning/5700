using System;
using System.Collections.Generic;

namespace MyClasses
{
    public class ThingABobCollection : List<ThingABob>
    {
        public ImporterExporter MyImporterExporter { get; set; }
        public string MyDataFile { get; set; }

        public void PrintCollection(string header)
        {
            Console.WriteLine("");
            Console.WriteLine($"Number of {header} back in: {Count}");

            foreach (ThingABob thing in this)
            {
                Console.WriteLine(thing);
            }
        }

        public void Write()
        {
            MyImporterExporter?.Write(this, MyDataFile);
        }

        public void Read()
        {
            MyImporterExporter?.Read(this, MyDataFile);
        }

    }
}
