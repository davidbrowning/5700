using System;
using System.Windows.Forms;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Box.Width = 600;
            Box.Height = 400;
            Box.Label = "My Box";

            Application.Run(new ControlForm());
        }
    }
}
