using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace SodokuSolver
{
    class OnlyPossibility : Solver
    {
        public override bool SolvePuzzle(Puzzle p)
        {
            start_time();
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
                    if (possible.Count() == 1)
                    {
                        p.Board[emptyCell.Item1, emptyCell.Item2] = possible[0];
                    }
//                    Console.Write(emptyCell.Item1 + "," + emptyCell.Item2 + ": ");
//                    foreach(var possibility in possible)
//                    {
//                        Console.Write(possibility + ",");
//                    }
//                    Console.WriteLine();
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
            stop_time();
            if(Empty_Cell_List_After > 0)
            {
                return false;
            }
            return true;
        }
    }
}
