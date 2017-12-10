using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace SodokuSolver
{
    class Twins : Solver
    {
        public Twins()
        {
            Name = "Twins";
        }
        // This was not implemented very well. 
        public void Eliminate_Twins(List<string> list, Tuple<int, int> cell, Puzzle p)
        {
            var block_size = (int)Math.Sqrt(p.size);
            var block = p.Get_Block(cell);
            Dictionary<Tuple<int, int>, List<string>> Map_of_Possibilities = new Dictionary<Tuple<int, int>, List<string>>();
            for (int row = block.Item1; row < (block.Item1 + block_size); row += 1)
            {
                if (row == cell.Item1) continue;
                for (int col = block.Item1; col < (block.Item1 + block_size); col += 1)
                {
                    if (col == cell.Item2) continue; // don't care about twins in same row or column. 
                    if (p.Board[row, col] == "-")
                    {
                        //Console.WriteLine("Board[" + row + "," + col + "] is Empty.");
                        Tuple<int, int> t = new Tuple<int, int>(row, col);
                        var Possibilities = p.GetEmptyCellPossibilities(t);
                        foreach (var entry in Map_of_Possibilities)
                        {
                            if(t.Item1 == entry.Key.Item1 || t.Item2 == entry.Key.Item2) // if it's on the same row or column
                            {
                                bool twin_found = true;
                                foreach(var item in Possibilities)
                                {
                                    if (!entry.Value.Contains(item))
                                    {
                                        twin_found = false;
                                    }
                                }
                                if (twin_found)
                                {
                                    // Twin Found!
                                    foreach (var val in Possibilities)
                                    {
                                        if (list.Contains(val))
                                        {
                                            //Console.WriteLine("Eliminating Twin! \nValue: " + val);
                                            //Console.Write(p.ToString());
                                            list.Remove(val);
                                        }
                                    }
                                }
                            } 
                        }
                        Map_of_Possibilities.Add(t, Possibilities);
                    }
                }
            }
        }
       
        public override bool Solve(Puzzle p)
        {
            //Twins is very similar to OnlyPossibility with the addition of 
            // further eliminating possibilities.
            var Empty_Cell_List = p.GetEmptyCells();
            var Empty_Cell_List_Before = Empty_Cell_List.Count();
            var Empty_Cell_List_After = Empty_Cell_List_Before;
            do
            {
                Empty_Cell_List = p.GetEmptyCells();
                Empty_Cell_List_Before = Empty_Cell_List.Count();
                foreach (var emptyCell in Empty_Cell_List)
                {
                    var possible = p.GetEmptyCellPossibilities(emptyCell);
                    Eliminate_Twins(possible,emptyCell,p);
                    if (possible.Count() == 1)
                    {
                        p.Board[emptyCell.Item1, emptyCell.Item2] = possible[0];
                    }
                }
                Empty_Cell_List_After = p.GetEmptyCells().Count();
                if (p.Animate)
                {
                    Console.Clear();
                    Console.Write(p.ToString());
                    Thread.Sleep(1000);
                }
            }
            while (Empty_Cell_List_Before > Empty_Cell_List_After);
            if(Empty_Cell_List_After > 0)
            {
                return false;
            }
            return true;
        }

        public override bool Update_Puzzle(Puzzle p, int row, int col, string c, int block_size)
        {
            throw new NotImplementedException();
        }
    }
}
