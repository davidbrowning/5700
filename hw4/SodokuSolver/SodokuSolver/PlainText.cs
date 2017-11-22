using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
    class PlainText : Serializer
    {
        public void Bad_puzzle(string[] lines)
        {
            Console.WriteLine("Bad Puzzle Found When Reading");
            foreach(var line in lines)
            {
                Console.WriteLine(line);
            }
            return;
        }
        public char delimiter { get; set; }
        public PlainText()
        {
            delimiter = ' ';
        }
        public override void Read(Puzzle puzzle, string filename, char del)
        {
            delimiter = del;
            Read(puzzle, filename);
        }

        public override bool Read(Puzzle puzzle, string filename)
        {
            if (!System.IO.File.Exists(filename))
            {
                throw new System.IO.FileNotFoundException();
            }
            string[] lines = System.IO.File.ReadAllLines(filename);
            int row, col, size;
            row = col = size = 0;
            Int32.TryParse(lines[0],out size);

            Console.WriteLine("Puzzle to be solved:" + filename);
            Console.WriteLine("Size of Matrix: "+size);
            Console.WriteLine("Possible Characters: " + lines[1]);

            List<string> ss = new List<string>();
            foreach (var l in lines[1].Split(delimiter)){ss.Add(l);}

            List<string> mx = new List<string>(lines);
            mx.RemoveRange(0, 2);
            string[,] matrix = new string[size, size];
            int index = 0;
            try
            {
                foreach (var line in mx)
                {
                    if (index >= size)
                    {
                        Console.WriteLine("" +
                            "There were more rows than exptected found in the provided file. " +
                               "\n\tAttempting to solve puzzle based on given" +
                               "\n\tnumber of rows");
                        break;
                    } 
                    foreach (var character in line.Split(delimiter))
                    {
                        matrix[row, col] = character;
                        Console.Write('(' + row.ToString() + ',' + col.ToString() + "): "
                            + matrix[row, col].ToString() + " | ");
                        col += 1;
                    }
                    if(col != size)
                    {
                        Console.WriteLine("COLUMN != SIZE");
                        Bad_puzzle(lines);
                        return false;
                    }
                    index += 1;
                    row += 1;
                    col = 0;
                    Console.Write("\n");
                }
            }
            catch
            {
                Bad_puzzle(lines);
                return false;
            }
            
            puzzle.size = size;
            puzzle.Symbol_Set = ss;
            puzzle.Board = matrix;
            return true;
        }

        public override void Write(Puzzle puzzle, string filename)
        {
            throw new NotImplementedException();
        }
    }
}
