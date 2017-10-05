using System;
using System.Windows.Forms;
using Shapes;

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

            CustomShapeFactory myFactor = new CustomShapeFactory() {BoxContainingCreatedShapes = myBox};

            Application.Run(new ControlForm() { MyBox = myBox, MyFactory = myFactor });
        }
    }
}
