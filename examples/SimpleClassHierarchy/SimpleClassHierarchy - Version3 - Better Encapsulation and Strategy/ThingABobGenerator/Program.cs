using System;

using MyClasses;

namespace TestDataGenerator
{
    public class Program
    {
        private const string DefaultDataFilename = "../../SampleData";

        private static readonly ImporterExporter[] ImporterExporters = new ImporterExporter[]
                        {
                            new JsonImporterExporter() { Name = "JSON", Description  = "JavaScript Object Notation"},
                            new XmlImporterExporter() { Name = "XML", Description = "Extensible Markup Language"}
                        };

        public static void Main(string[] args)
        {
            ImporterExporter importerExporter = GetFileFormatFromUser();
            if (importerExporter == null)
                return;

            string dataFilename = GetFilenameFromUser();
            if (string.IsNullOrWhiteSpace(dataFilename))
                return;

            // Create from sample gadgets and print them out
            ThingABobCollection data1 = new ThingABobCollection() { MyImporterExporter = importerExporter, MyDataFile = dataFilename };
            CreateSampleThings(data1);
            data1.PrintCollection("original object");
            data1.MyImporterExporter = importerExporter;
            data1.Write();

            // Read the data file back in and print out the objects
            ThingABobCollection data2 = new ThingABobCollection() { MyImporterExporter = importerExporter, MyDataFile = dataFilename };
            data2.Read();
            data2.PrintCollection("objects in the json collection");

            Console.WriteLine("Type ENTER to exit");
            Console.WriteLine("");
            Console.ReadLine();
        }

        private static void CreateSampleThings(ThingABobCollection collection)
        {
            collection.Add(new Gadget() { Id = 50, Name = "A", Cost = 10.99, Length = 3, Width = 4 });
            collection.Add(new Widget() { Id = 51, Name = "B", Weight = 20.5 });
            collection.Add(new Gadget() { Id = 52, Name = "C", Cost = 12.99, Length = 4, Width = 4 });
            collection.Add(new Widget() { Id = 53, Name = "D", Weight = 30.55 });
            collection.Add(new Widget() { Id = 54, Name = "E", Weight = 50.25 });                
            collection.Add(new Widget() { Id = 55, Name = "F", Weight = 60.19 });
            collection.Add(new Gadget() { Id = 56, Name = "G", Cost = 45.99, Length = 20, Width = 4 });
            collection.Add(new Gadget() { Id = 57, Name = "H", Cost = 5.09, Length = 12, Width = 5 });
        }

        private static ImporterExporter GetFileFormatFromUser()
        {
            ImporterExporter result = null;
            while (result == null)
            {
                Console.WriteLine("File Format Types:");
                foreach (ImporterExporter importerExporter in ImporterExporters)
                    Console.WriteLine($"\t{importerExporter.Name.PadRight(10)}{importerExporter.Description}");
                Console.Write("Specific which format type you want to work or EXIT? ");
                string response = Console.ReadLine()?.Trim().ToUpper();

                if (response == "EXIT")
                    return null;

                foreach (ImporterExporter importerExporter in ImporterExporters)
                {
                    if (response == importerExporter.Name)
                    {
                        result = importerExporter;
                        break;
                    }
                }
            }

            return result;       
        }

        private static string GetFilenameFromUser()
        {
            string result = null;
            Console.Write($"Enter data file name or EXIT (default={DefaultDataFilename})? ");
            string response = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(response))
                response = DefaultDataFilename;

            if (response != "EXIT")
                result = response;

            return result;
        }

    }
}
