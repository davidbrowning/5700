using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
    public class Puzzle 
    {

        public List<Tuple<int,int>> GetEmptyCells()
        {
            List<Tuple<int, int>> E_cells = new List<Tuple<int, int>>();
            for (int i = 0; i < size; ++i)
            {
                for (int j = 0; j < size; ++j)
                {
                    if(Board[i,j] == "-")
                    {
                        E_cells.Add(new Tuple<int, int>(i, j)); 
                    }
                }
            }
            Empty_Cells = E_cells;
            return E_cells;
        }
        public bool in_row(int row_num, string symbol)
        {
            for (int i = 0; i < size; ++i)
            {
                if (Board[row_num,i] == symbol)
                {
                    return true;
                }
            }
            return false;
        }
        public bool in_col(int col_num, string symbol)
        {
            for (int i = 0; i < size; ++i)
            {
                if (Board[i,col_num] == symbol)
                {
                    return true;
                }
            }
            return false;
        }
        public bool in_block(int row, int column, string symbol)
        {
            var block_size = Math.Sqrt(size);
            int row_offset = (int)(Math.Floor(row / block_size)); // e.g. in a 3x3 puzzle, row 5 would be in offset 1
            int column_offset = (int)(Math.Floor(column / block_size));
            for (int i = (int)(row_offset*block_size); i < block_size; ++i)
            {
                for (int j = (int)(column_offset*block_size); j < block_size; ++j)
                {
                    if (Board[i, j] == symbol)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public Tuple<int,int> Get_Block(Tuple<int,int> t)
        {
            var block_size = (int)Math.Sqrt(size);
            int row_offset = (int)(Math.Floor((double)t.Item1 / block_size)); // e.g. in a 3x3 puzzle, row 5 would be in offset 1
            int column_offset = (int)(Math.Floor((double)t.Item2 / block_size));
            Tuple<int, int> block = new Tuple<int, int>((row_offset*block_size),(column_offset*block_size));
            return block;
        }
        public List<string> GetEmptyCellPossibilities(Tuple<int,int> t)
        {
            List<string> delete_these = new List<string>();
            List<string> possibilities = new List<string>(Symbol_Set);
            foreach(var p in Symbol_Set)
            {
                if(in_row(t.Item1,p))
                {
                    delete_these.Add(p);
                    continue;
                }
                if(in_col(t.Item2,p))
                {
                    delete_these.Add(p);
                    continue;
                }
                if(in_block(t.Item1,t.Item2,p))
                {
                    delete_these.Add(p);
                    continue;
                }

            }
            foreach(var item in delete_these)
            {
                if (possibilities.Contains(item))
                {
                    possibilities.Remove(item);
                }
            }
            return possibilities;
        }
        // Checks whether indicated Column is solved. Throws invalid symbol exception
        public bool Column(int offset)
        {
            List<string> responses = new List<string>();
            for (int i = 0; i < size; ++i)
            {
                if(Board[i,offset] == "-"){ return false;} // found dash, col not complete
                if(Symbol_Set.Contains(Board[i,offset]) == false)
                {
                    throw new System.ArgumentException("Symbol Found not in symbol set");
                }
                if(responses.Contains(Board[i,offset]) == true) { Console.WriteLine("Already have "+Board[i,offset]+" in solution"); return false;}
                responses.Add(Board[i, offset]);
            }
            return true;
        }

        // Checks whether indicated row is solved
        public bool Row(int offset)
        {
            List<string> responses = new List<string>();
            for (int i = 0; i < size; ++i)
            {
                if(Board[offset,i] == "-"){ return false;} // found dash, col not complete
                if(Symbol_Set.Contains(Board[offset,i]) == false)
                {
                    throw new System.ArgumentException("Symbol Found not in symbol set");
                }
                if(responses.Contains(Board[offset,i]) == true) { Console.WriteLine("Already have "+Board[offset,i]+" in solution"); return false;}
                responses.Add(Board[offset,i]);
            }
            return true;
        }
        // Checks whether indicated block is solved (top left corner)
        public bool Block(int x,int y)
        {
            List<string> responses = new List<string>();
            int block_size = (int)Math.Sqrt(size);
            for (int i = x; i < x+block_size; ++i)
            {
                for (int j = y; j < y+block_size; ++j)
                {
                    if(Board[i,j] == "-"){ return false;} // found dash, col not complete
                    if(Symbol_Set.Contains(Board[i,j]) == false)
                    {
                        throw new System.ArgumentException("Symbol Found not in symbol set");
                    }
                    if(responses.Contains(Board[i,j]) == true) { Console.WriteLine("Already have "+Board[i,j]+" in solution"); return false;}
                    responses.Add(Board[i, j]);
                }
            }
            return true;
        }
        public bool IsSolved()
        {
            for (int i = 0; i < size; i++)
            {
                if (!Row(i) || !Column(i))
                {
                    return false;
                }
            }
            for (int i = 0; i < size; i += (int)Math.Sqrt(size))
            {
                for (int j = 0; j < size; j += (int)Math.Sqrt(size))
                {
                    if (!Block(i,j))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override string ToString()
        {
            string final = "";
            for (int i = 0; i < size; ++i)
            {
                final += "| ";
                for (int j = 0; j < size; ++j)
                {
                    final += Board[i, j] + " | ";
                }
                final += '\n';
            }
            return final;
        }

        public Puzzle()
        {
            Symbol_Set = new List<string>();
            Empty_Cells = new List<Tuple<int, int>>();
        }
        public List<Tuple<int, int>> Empty_Cells { get; set; }
        public Dictionary<Tuple<int, int>, List<string>> Empty_Cell_Possible_Answers { get; set; }
        public string[,] Board { get; set; }
        public List<string> Symbol_Set{ get; set; }
        public int size{ get; set; }
        public bool Animate { get; set; }
    }
}
