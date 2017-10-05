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

            Box myBox = new Box()
            {
                Width = 600,
                Height = 400,
                Label = "My Box"
            };

            Application.Run(new ControlForm() { MyBox = myBox } );
        }
    }
}
