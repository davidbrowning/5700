using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClassLibrary
{
    public class FileOutput : Outputter
    {
        private FileOutput()
        {
            Filename = "Default.txt";
        }
        public FileOutput(string f) => Filename = f;
        public override void Output(List<PersonPair> p)
        {
            if(Filename != "")
            {
                try
                {
                    StreamWriter sw = new StreamWriter(Filename);
                    foreach (PersonPair pair in p)
                    {
                        sw.WriteLine(pair.ToString());
                    }
                    sw.Flush();
                }
                catch {
                    Console.WriteLine("Error writing to file.");
                }
            }
        }
        public string Filename { get; set; }
    }
}
