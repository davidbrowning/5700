using System;

using MyClasses;

namespace TestDataGenerator
{
    public class Program
    {


        static void Main()
        {
            // Create from sample gadgets and print them out
            ThingABobCollection data = CreateSampleThings();
            data.PrintCollection("original object");

            // Save the gadgets in JSON and XML formats
            data.WriteJson(@"../../SampleData.json");
            data.WriteXml(@"../../SampleData.xml");

            // Read the JSON file back in and print out the objects
            ThingABobCollection data2 = new ThingABobCollection();
            data2.ReadJson(@"../../SampleData.json");
            data2.PrintCollection("objects in the json collection");

            // Read the XML file back in and print out the objects
            ThingABobCollection data3 = new ThingABobCollection();
            data3.ReadXml(@"../../SampleData.xml");
            data3.PrintCollection("objects in xml collection");

            Console.WriteLine("Type ENTER to exit");
            Console.ReadLine();
        }


        private static ThingABobCollection CreateSampleThings()
        {
            ThingABobCollection list = new ThingABobCollection()
            { 
                new Gadget() {Id = 50, Name="A", Cost = 10.99, Length = 3, Width = 4},
                new Widget() {Id = 51, Name="B", Weight = 20.5},
                new Gadget() {Id = 52, Name="C", Cost = 12.99, Length = 4, Width = 4},
                new Widget() {Id = 53, Name="D", Weight = 30.55},
                new Widget() {Id = 54, Name="E", Weight = 50.25},
                new Widget() {Id = 55, Name="F", Weight = 60.19}
            };

            return list;
        }

    }
}
