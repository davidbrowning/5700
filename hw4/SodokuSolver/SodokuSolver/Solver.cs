using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace SodokuSolver
{
    public abstract class Solver
    {
        public void start_time()
        {
            s.Start();
        }
        public void stop_time()
        {
            s.Stop();
            Console.WriteLine("Elapsed Ticks: " + s.ElapsedTicks);
            Console.WriteLine("Elapsed Time(ms): " + s.ElapsedMilliseconds);
            s.Reset();
        }
        public abstract bool Solve(Puzzle p);
        public void Animate(Puzzle p)
        {
            if (p.Animate)
            {
                Console.Clear();
                Console.Write(p.ToString());
                Thread.Sleep(1000);
            }
        }

        //I tried to make this part of the concrete function, 
        // but I use it differently for different concrete solvers. 
        public abstract bool Update_Puzzle(Puzzle p, int row, int col, string c, int block_size);

        public bool SolvePuzzle(Puzzle p)
        {
            start_time();
            GuiLayer.Message_Queue m = GuiLayer.Message_Queue.Instance;
            m.MessageQueue.Enqueue(p.ToString());
            m.PuzzleMessageQueue.Enqueue(p.Board);
            var was_solved = Solve(p);
            stop_time();
            return was_solved;
        }

        private Stopwatch s = new Stopwatch();
        public string Name { get; set; }
    }
}
