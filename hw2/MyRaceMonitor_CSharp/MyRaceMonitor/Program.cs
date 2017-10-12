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
        static void Main()
        {
            new Thread(new ThreadStart(ShowControlForm)).Start();
            SimulatorController controller = new SimulatorController();
            controller.Run("../../../SimulationData/Short Race Simulation-01.csv");
        }
        public static void ShowControlForm()
        {
            GuiLayer.Form1 f1 = new GuiLayer.Form1
            {
                Text = "New Title"
            };
            f1.Show();
            Application.Run();
        }
    }
}
