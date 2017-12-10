using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SodokuSolver
{
    class OnlyPossibility : Solver
    {
        public OnlyPossibility()
        {
            Name = "Only Possibility";
        }
        
        public override bool Update_Puzzle(Puzzle p, int row, int column, string c, int block_size)
        {
            var possible = p.GetEmptyCellPossibilities(new Tuple<int,int>(row,column));
            if (possible.Count() == 1)
            {
                p.Board[row, column] = possible[0];
                var m = GuiLayer.Message_Queue.Instance;
                m.PuzzleMessageQueue.Enqueue(p.Board);
                return true;
            }
            return false;
        }

        public override bool Solve(Puzzle p)
        {
            var Empty_Cell_List = p.GetEmptyCells();
            var Empty_Cell_List_Before = Empty_Cell_List.Count();
            var Empty_Cell_List_After = Empty_Cell_List_Before;
            do
            {
                Empty_Cell_List = p.GetEmptyCells();
                Empty_Cell_List_Before = Empty_Cell_List.Count();
                int block_size = (int)Math.Sqrt(p.size);
                foreach (var emptyCell in Empty_Cell_List)
                {
                    Update_Puzzle(p, emptyCell.Item1, emptyCell.Item2, " ", block_size);
                }
                Empty_Cell_List_After = p.GetEmptyCells().Count();
                Animate(p);
            }
            while (Empty_Cell_List_Before > Empty_Cell_List_After);
            if(Empty_Cell_List_After > 0)
            {
                return false;
            }
            return true;
        }
    }
}
