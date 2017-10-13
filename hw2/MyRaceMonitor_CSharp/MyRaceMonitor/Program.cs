using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppLayer;
using GuiLayer;
using System.Threading;

namespace MyRaceMonitor
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            new Thread(new ThreadStart(ShowControlForm)).Start();
            SimulatorController controller = new SimulatorController();
            int distance = 0;
            if (args.Length == 2)
            {
                try
                {
                    if (int.Parse(args[0]) == 1)
                    {
                        controller.Run("../../../SimulationData/Short Race Simulation-01.csv");
                    }
                    if (int.Parse(args[0]) == 2)
                    {
                        controller.Run("../../../SimulationData/Century Simulation-01.csv");
                    }
                    distance = int.Parse(args[1]);
                }
                catch
                {
                    help();
                }
            }
            else
            {
                help();
            }
        }
        public static void ShowControlForm()
        {
            GuiLayer.ControlForm f1 = new GuiLayer.ControlForm();
            f1.Show();
            Application.Run();
        }
        public static void help()
        {
            Console.WriteLine("Incorrect number of arguments:" +
                "[options]" +
                "First Argumeent (1 or 2)" +
                "\t 1: run Short Race Simulation-01"+
                "\t 2: run Century Simulation-01" +
                "Second Argument (int > 0 and < max_int indicates total race length");
        }
    }
}
