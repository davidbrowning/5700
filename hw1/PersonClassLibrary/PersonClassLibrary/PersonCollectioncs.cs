using System;
using System.Collections.Generic;


namespace PersonClassLibrary
{
    public class PersonCollection : List<Person>
    {
        public Serializer MySerializer { get; set; }
        public Outputter MyOutputter { get; set; }
        public string MyDataFile { get; set; }

        public void PrintCollection(string header)
        {
            Console.WriteLine("");
            Console.WriteLine($"Number of {header} back in: {Count}");

            foreach (Person person in this)
            {
                Console.WriteLine(person);
            }
        }

        public void Write()
        {
            MySerializer?.Write(this, MyDataFile);
        }

        public void Read()
        {
            MySerializer?.Read(this, MyDataFile);
        }
    }
}
