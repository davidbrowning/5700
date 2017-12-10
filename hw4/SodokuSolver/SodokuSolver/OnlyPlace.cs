using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
    class OnlyPlace : Solver
    {
        public OnlyPlace()
        {
            Name = "Only Place";
        }
        public override bool Update_Puzzle(Puzzle p, int row, int col, string symbol, int block_size)
        {
            bool puzzleUpdated = false;
            if (!p.in_block(row, col, symbol))
            {
                int c = -1;
                int r = -1;
                int row_counter = 0;
                int col_counter = 0;
                for (int it = 0; it < block_size; it++)
                {
                    if(!p.in_row((row+it), symbol))
                    {
                        r = (row + it);
                        row_counter += 1;
                    }
                    if(!p.in_col((col+it), symbol))
                    {
                        c = (col + it);
                        col_counter += 1;
                    }
                }
                if(row_counter == 1 && col_counter == 1)
                {
                    if(p.Board[r,c] == "-")
                    {
                        p.Board[r, c] = symbol;
                        puzzleUpdated = true;
                        Console.WriteLine("Updating p.Board[" + r + "," + c + "] = "+c);
                    }
                }
            }
            return puzzleUpdated;
        }
        public override bool Solve(Puzzle p)
        {
            int updates = 0;
            do
            {
                updates = 0;
                foreach (var symbol in p.Symbol_Set)
                {
                    int block_size = (int)Math.Sqrt(p.size);
                    for (int row = 0; row < p.size; row += block_size)
                    {
                        for (int col = 0; col < p.size; col += block_size)
                        {
                            //triangulate from block perspective. 
                            if (Update_Puzzle(p, row, col, symbol, block_size))
                            {
                                updates += 1;
                            }
                        }
                    }
                }
            } while (updates > 0);
            if (p.IsSolved())
            {
                return true;
            }
            else return false;
        }
    }
}
