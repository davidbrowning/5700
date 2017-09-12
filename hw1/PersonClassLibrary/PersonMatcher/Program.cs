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
        private const string DefaultFileName = "sampledata";
        private static readonly Serializer[] serializerarray = new Serializer[]
        {
            new Json(){Name=".JSON", Description="Serialize to/from JSON" },
            new Xml(){Name=".XML", Description="Serialize to/from XML" }
        };
        private static readonly Matcher[] matcherarray = new Matcher[]
        {
            new NameMatcher(), new BirthMatcher(), new IdentifierMatcher()
        };

        static void Main(string[] args)
        {
            List<PersonPair> listOfMatches = new List<PersonPair>();
            string dataFilename = "";
            string outputFilename = "";
            int algorithm = 0;
            if (!CheckArguments(args))
            {
                HelpMessage();
                return;
            }
            else
            {
                int.TryParse(args[0],out(algorithm));
                dataFilename = args[1];
                if(args.Length > 2)
                outputFilename = args[2];
            }

            Matcher m = GetMatcher(algorithm);
            SimpleMatcher sm = GetSimpleMatcher(algorithm);
            Serializer serializer = GetFileFormat(args[1]);
            if (serializer == null)
                return;

//            PersonCollection pc1 = new PersonCollection() { MySerializer = serializer, MyDataFile = dataFilename };
//            CreateSampleThings(pc1);
//            pc1.PrintCollection("original object");
//            pc1.MySerializer = serializer;
//            pc1.Write();

            // Read the data file back in and print out the objects
            PersonCollection pc = new PersonCollection() { MySerializer = serializer, MyDataFile = dataFilename };
            pc.Read();
            //pc.PrintCollection("objects in the json collection");
            Dictionary<string, List<Person>> d = m.FindMatches(pc);

            foreach (Person p in pc)
            {
                foreach (Person q in pc)
                {
                    if(p.ObjectId != q.ObjectId)
                    {
                        PersonPair pp = new PersonPair(p, q);
                        if (sm.IsMatchedPair(pp))
                        {
                            listOfMatches.Add(pp);
                        }
                    }
                }
            }
            if (args.Length > 2)
            {
                try
                {
                    StreamWriter f = new StreamWriter(args[2]);
                    foreach (PersonPair pair in listOfMatches)
                    {
                        f.WriteLine(pair.ToString());
                    }
                }
                catch {
                    Console.WriteLine("Error writing to file.");
                }
            }
            else
            {
                foreach (PersonPair pair in listOfMatches)
                {
                    Console.WriteLine("Match:\n\t" + pair.One.ToString() + "\n\t" + pair.Two.ToString());
                }
            }

            Console.WriteLine("\nType ENTER to exit");
            Console.WriteLine("");
            Console.ReadLine();
        }
        private static Matcher GetMatcher(int n)
        {
            switch (n)
            {
                case (1):
                    return new NameMatcher();               
                case (2):
                    return new BirthMatcher();
                case (3):
                    return new IdentifierMatcher();
                default: Console.WriteLine("Something has gone horribly wrong, you should never see this");
                    return new NameMatcher();
            }
        }
        private static SimpleMatcher GetSimpleMatcher(int n)
        {
            switch (n)
            {
                case (1):
                    return new SimpleNameMatcher();               
                case (2):
                    return new SimpleBirthMatcher();
                case (3):
                    return new SimpleIdentityMatcher();
                default: Console.WriteLine("Something has gone horribly wrong, you should never see this");
                    return new SimpleNameMatcher();
            }
        }

        // Leaving this in here in case it makes sense to use 
        //  Dictionary down the line
        private void PrintMatchesFromMap(Dictionary<string, List<Person>> d)
        {
            foreach (string key in d.Keys)
            {
                if(d[key].Count > 1)
                {
                    foreach (Person p in d[key])
                    {
                        Console.WriteLine(p.ToString());
                    }
                }
            }
        }


        private static bool CheckArguments(string[] s)
        {
            if(s[0] == "-h" || s[0] == "--help" || s[0] == "h")
            {
                return false;
            }
            if(s.Length < 2 || s.Length > 3)
            {
                Console.WriteLine("Incorrect number of arguments given");
                return false;
            }
            int r = 0;
            if(int.TryParse(s[0], out (r)))
            {
                if(1 > r || r > 3)
                {
                    Console.WriteLine("Matching Algorithm unknown");
                    return false;
                }
            }
            if (!File.Exists(s[1]))
            {
                Console.WriteLine("File specified does not exist");
                return false;
            }
            return true;
        }

        private static void HelpMessage()
        {
            Console.WriteLine("Person Class Library:");
            Console.WriteLine("\t Usage:");
            Console.WriteLine("\t\t PersonMatcher [Options]");
            Console.WriteLine("\t Options:");
            Console.WriteLine("\t\t PersonMatcher <n> <inputfilename> <output filename>");
            Console.WriteLine("\t\t <n> where 0 < n < 4 as per desired matching algorithm");
            Console.WriteLine("\t\t <input filename> Where PersonMatcher will be looking to import the data");
            Console.WriteLine("\t\t <output filename> (optional) File PersonMatcher will use to export the results " +
                "\n\t\t\t (output to console if empty)");
            Console.WriteLine("\t Example:");
            Console.WriteLine("\t\t PersonMatcher 1 JSON_PersonTestSet_3.json Results.txt ");
            Console.WriteLine("\t Matching:");
            Console.WriteLine("\t\t 1) Match by Name");
            Console.WriteLine("\t\t 2) Match by Birth/Mother");
            Console.WriteLine("\t\t 3) Match by Identifier");
        }
// No longer need this, but it was helpful in understanding the syntax
//        private static void CreateSampleThings(PersonCollection collection)
//        {
//            collection.Add(new Person() { ObjectId = 50, FirstName = "A",MiddleName = "A",LastName = "A", BirthYear = 1900,BirthMonth = 12,BirthDay = 12,});
//            collection.Add(new Person() { ObjectId = 51, FirstName = "B",MiddleName = "B",LastName = "B", BirthYear = 1901,BirthMonth = 12,BirthDay = 13,});
//            collection.Add(new Person() { ObjectId = 52, FirstName = "C",MiddleName = "C",LastName = "C", BirthYear = 1902,BirthMonth = 12,BirthDay = 14,});
//            collection.Add(new Person() { ObjectId = 53, FirstName = "D",MiddleName = "D",LastName = "D", BirthYear = 1903,BirthMonth = 12,BirthDay = 15,});
//            collection.Add(new Person() { ObjectId = 55, FirstName = "F",MiddleName = "F",LastName = "F", BirthYear = 1904,BirthMonth = 12,BirthDay = 16,});
//            collection.Add(new Person() { ObjectId = 57, FirstName = "H",MiddleName = "H",LastName = "H", BirthYear = 1905,BirthMonth = 12,BirthDay = 17,});
//        }

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
