using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
    class Program
    {
        static void write_help()
        {
            Console.WriteLine("" +
                "Sudoku Solver:" +
                "\n \t ./SudokuSolver.exe [options] -i [inputfile] -o [outputfile]" +
                "\n\t\t[Options]" +
                "\n\t\t-h|--help  -- displays the help message" +
                "\n\t\t-i|--infile -- file that contains puzzle to be read" +
                "\n\t\t-o|--outfile -- (optional) file to write solution to.");
            return;
        }
        static bool Check_args(Dictionary<string,string> d)
        {
            if (d.ContainsKey("-h") || d.ContainsKey("--help")) { write_help(); return false; }
            if (d.ContainsKey("-i")) {Console.WriteLine("Input File: " + d["-i"]);}
            if (d.ContainsKey("--infile")) {Console.WriteLine("Input File: " + d["--infile"]);d.Add("-i", d["--infile"]); }
            if (d.ContainsKey("-o")) { Console.WriteLine("Output File: "+d["-o"]); }
            if (d.ContainsKey("--outfile")) { Console.WriteLine("Output File: "+d["--outfile"]);d.Add("-o", d["--outfile"]); }
            if (!d.ContainsKey("-i")) { Console.WriteLine("No Input File"); write_help(); return false; }
            return true;
        }
        static Dictionary<string, string> Parse_args(string[] s)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            string argument, value;
            argument = value = " ";
            foreach (string a in s)
            {
                if (a[0] == ('-'))
                {
                    argument = a;
                    dictionary.Add(a, " ");
                }
                else
                {
                    value = a;
                    try
                    {
                        dictionary[argument] = value;
                    }
                    catch
                    {
                        Console.WriteLine("Couldn't Parse Command Line Arguments");
                    }
                }
            }
            return dictionary;
        }

        static void Failure()
        {
            Console.WriteLine("Something didn't work...");
            Console.Read();
            return;
        }

        static void Main(string[] args)
        {
            Dictionary<string, string> arguments = Parse_args(args);
            if (!Check_args(arguments))
            {
                Failure();
                return;
            }
            string fn = arguments["-i"];
            Puzzle p = new Puzzle();
            Serializer s = new PlainText();
            if(!s.Read(p, fn))
            {
                Console.WriteLine("Bad Puzzle Detected, Cannot Read Puzzle");
                Failure();
                return;
            }
            Console.Write(p.ToString());
            p.Animate = true;
            OnlyPossibility op = new OnlyPossibility();
            var success = op.SolvePuzzle(p);
            if (success)
            {
                Console.Write(p.ToString());
                Console.WriteLine("Puzzle Solved!");
            }
            else
            {
                Console.WriteLine("Puzzle Not Solved");
            }
            Console.Read();
            return;
        }
    }
}
