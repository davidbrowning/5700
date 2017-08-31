using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Xml.Serialization;
using MyClasses;

namespace TestDataGenerator
{
    public class Program
    {


        static void Main()
        {
            // Create from sample gadgets and print them out
            ThingABobCollection data = CreateSampleGadgets();
            Console.WriteLine("Number of objects: {0}", data.Count);
            foreach (ThingABob thing in data)
            {
                if (thing is Gadget)
                {
                    var g = thing as Gadget;
                    Console.WriteLine($"Gadget: {g.Id}, width={g.Width}, length={g.Length}, cost={g.Cost}");
                }
                else
                {
                    var g = thing as Widget;
                    Console.WriteLine($"Width: {g.Id}, width={g.Weight}");
                }
            }

            // Save the gadgets in JSON and XML formats
            data.WriteJson(@"../../SampleData.json");
            data.WriteXml(@"../../SampleData.xml");

            // Read the JSON file back in and print out the objects
            ThingABobCollection data2 = new ThingABobCollection();
            data2.ReadJson(@"../../SampleData.json");
            Console.WriteLine("");
            Console.WriteLine("Number of json objects read back in: {0}", data2.Count);
            foreach (ThingABob thing in data)
            {
                if (thing is Gadget)
                {
                    var g = thing as Gadget;
                    Console.WriteLine($"Gadget: {g.Id}, width={g.Width}, length={g.Length}, cost={g.Cost}");
                }
                else
                {
                    var g = thing as Widget;
                    Console.WriteLine($"Width: {g.Id}, width={g.Weight}");
                }
            }

            // Read the XML file back in and print out the objects
            ThingABobCollection data3 = new ThingABobCollection();
            data3.ReadXml(@"../../SampleData.xml");
            Console.WriteLine("");
            Console.WriteLine("Number of xml objects read back in: {0}", data3.Count);
            foreach (ThingABob thing in data)
            {
                if (thing is Gadget)
                {
                    var g = thing as Gadget;
                    Console.WriteLine($"Gadget: {g.Id}, width={g.Width}, length={g.Length}, cost={g.Cost}");
                }
                else
                {
                    var g = thing as Widget;
                    Console.WriteLine($"Width: {g.Id}, width={g.Weight}");
                }
            }

            Console.WriteLine("Type ENTER to exit");
            Console.ReadLine();
        }

        private static ThingABobCollection CreateSampleGadgets()
        {
            ThingABobCollection list = new ThingABobCollection()
            { 
                new Gadget() {Id = 50, Cost = 10.99, Length = 3, Width = 4},
                new Widget() {Id = 51, Weight = 20.5},
                new Gadget() {Id = 52, Cost = 12.99, Length = 4, Width = 4},
                new Widget() {Id = 53, Weight = 30.55},
                new Widget() {Id = 54, Weight = 50.25},
                new Widget() {Id = 55, Weight = 60.19}
            };

            return list;
        }

    }
}
