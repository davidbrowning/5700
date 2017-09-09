using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using PersonClassLibrary;
using System.IO;

namespace PersonMatcher
{
    class Program
    {
        //Credit to Dr. Clyde for the general format of these functions

        private const string DefaultFileName = "sampledata";
        private static readonly Serializer[] serializerarray = new Serializer[]
        {
            new Json(){Name=".JSON", Description="Serialize to/from JSON" },
            new Xml(){Name=".XML", Description="Serialize to/from XML" }
        };

        static void Main(string[] args)
        {
            string dataFilename = "";
            string outputFilename = "";
            int algorithm = 0;
            if (args.Length != 3)
            {
                Console.WriteLine("Incorrect number of Arguments given.");
                HelpMessage();
                return;
            }
            else
            {
                int.TryParse(args[0],out(algorithm));
                dataFilename = args[1];
                outputFilename = args[2];
            }
         //   Console.WriteLine(args.Length);
         //   Console.WriteLine("Input Parameters: " + args[0] + " " + args[1]  ); // " " +args[2]);
            Serializer serializer = GetFileFormat(args[1]);
            if (serializer == null)
                return;

            PersonCollection pc1 = new PersonCollection() { MySerializer = serializer, MyDataFile = dataFilename };
            CreateSampleThings(pc1);
            pc1.PrintCollection("original object");
            pc1.MySerializer = serializer;
            pc1.Write();

            // Read the data file back in and print out the objects
            PersonCollection pc2 = new PersonCollection() { MySerializer = serializer, MyDataFile = dataFilename };
            pc2.Read();
            pc2.PrintCollection("objects in the json collection");

            Console.WriteLine("Type ENTER to exit");
            Console.WriteLine("");
            Console.ReadLine();
        }

        private static void HelpMessage()
        {
            Console.WriteLine("Person Class Library:");
            Console.WriteLine("\t Usage:");
            Console.WriteLine("\t\t PersonMatcher [Options]");
            Console.WriteLine("\t Options:");
            Console.WriteLine("\t\t PersonMatcher <n> <inputfilename> <output filename>");
            Console.WriteLine("\t\t <n> where 0 < n < 3 as per desired matching algorithm");
            Console.WriteLine("\t\t <input filename> Where PersonMatcher will be looking to import the data");
            Console.WriteLine("\t\t <output filename> Where PersonMatcher will be looking to export the results");
            Console.WriteLine("\t Example:");
            Console.WriteLine("\t\t PersonMatcher 1 JSON_PersonTestSet_3.json Results.txt ");
        }
        private static void CreateSampleThings(PersonCollection collection)
        {
            collection.Add(new Person() { ObjectId = 50, FirstName = "A",MiddleName = "A",LastName = "A", BirthYear = 1900,BirthMonth = 12,BirthDay = 12,});
            collection.Add(new Person() { ObjectId = 51, FirstName = "B",MiddleName = "B",LastName = "B", BirthYear = 1901,BirthMonth = 12,BirthDay = 13,});
            collection.Add(new Person() { ObjectId = 52, FirstName = "C",MiddleName = "C",LastName = "C", BirthYear = 1902,BirthMonth = 12,BirthDay = 14,});
            collection.Add(new Person() { ObjectId = 53, FirstName = "D",MiddleName = "D",LastName = "D", BirthYear = 1903,BirthMonth = 12,BirthDay = 15,});
            collection.Add(new Person() { ObjectId = 55, FirstName = "F",MiddleName = "F",LastName = "F", BirthYear = 1904,BirthMonth = 12,BirthDay = 16,});
            collection.Add(new Person() { ObjectId = 57, FirstName = "H",MiddleName = "H",LastName = "H", BirthYear = 1905,BirthMonth = 12,BirthDay = 17,});
        }

        private static Serializer GetFileFormat(string filename)
        {
            string ext = Path.GetExtension(filename).Trim().ToUpper();
            foreach (Serializer s in serializerarray)
            {
                if (ext == s.Name)
                {
                    return s;
                }
            }
            Console.WriteLine("No valid serializers found");
            Console.WriteLine("Input: " + ext);
            HelpMessage();
            return null;
        }
    }
}
