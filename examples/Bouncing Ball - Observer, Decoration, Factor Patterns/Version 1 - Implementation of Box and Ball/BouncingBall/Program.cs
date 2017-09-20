using System;
using System.Threading;

namespace BouncingBall
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Box.Width = 600;
            Box.Height = 400;
            Box.Label = "My Box";

            // For now, just create a balls, start it moving, and display it's position
            Ball b = new Ball() { Radius = 10, X = 1, Y = 1, Direction = 67, Speed = 4, TimeUnit = 10 };
            b.Start();

            // Run for 10 seconds (100 iterations at 1/10 second per iteration)
            for (int i=0; i<100; i++)
            {
                DateTime currentTime = DateTime.Now;
                Console.WriteLine($"At {currentTime.Minute}:{currentTime.Second}.{currentTime.Millisecond}: X={b.X}, Y={b.Y}");
                Thread.Sleep(100);
            }

            Console.ReadKey();

        }

    }
}
