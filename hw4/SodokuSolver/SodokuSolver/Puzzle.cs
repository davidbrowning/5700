using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver
{
    public class Puzzle 
    {
        // Checks whether indicated Column is solved. Throws invalid symbol exception
        public bool Column(int offset)
        {
            List<string> responses = new List<string>();
            for (int i = 0; i < size; ++i)
            {
                //Console.WriteLine(Board[i,offset]);
                if(Board[i,offset] == "-"){ return false;} // found dash, col not complete
                if(symbol_set.Contains(Board[i,offset]) == false)
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
                //Console.WriteLine(Board[i,offset]);
                if(Board[offset,i] == "-"){ return false;} // found dash, col not complete
                if(symbol_set.Contains(Board[offset,i]) == false)
                {
                    throw new System.ArgumentException("Symbol Found not in symbol set");
                }
                if(responses.Contains(Board[offset,i]) == true) { Console.WriteLine("Already have "+Board[offset,i]+" in solution"); return false;}
                responses.Add(Board[offset,i]);
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
        public bool CheckAllBlocks()
        {

            return false;
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
                    Console.WriteLine("Board[" + i + "," + j + "] is " + Board[i,j]);
                    if(Board[i,j] == "-"){ return false;} // found dash, col not complete
                    if(symbol_set.Contains(Board[i,j]) == false)
                    {
                        throw new System.ArgumentException("Symbol Found not in symbol set");
                    }
                    if(responses.Contains(Board[i,j]) == true) { Console.WriteLine("Already have "+Board[i,j]+" in solution"); return false;}
                    responses.Add(Board[i, j]);
                }
            }
            return true;
        }
        public Puzzle()
        {
            symbol_set = new List<string>();
        }
        public string[,] Board { get; set; }
        public List<string> symbol_set{ get; set; }
        public int size{ get; set; }
    }
}
