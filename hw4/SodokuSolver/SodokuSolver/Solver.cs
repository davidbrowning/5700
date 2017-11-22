using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public abstract bool SolvePuzzle(Puzzle p);

        private Stopwatch s = new Stopwatch();
    }
}
