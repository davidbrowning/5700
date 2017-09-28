using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BouncingBall
{
    public partial class ControlForm : Form
    {
        private readonly List<Ball> _balls = new List<Ball>();
        private ListDisplay _observer1;
        private GraphicalDisplay _observer2;

        public ControlForm()
        {
            InitializeComponent();
        }

        private void createStuffButon_Click(object sender, EventArgs e)
        {
            UnsubscribeObserversAndDeleteBalls();

            _observer1 = new ListDisplay();
            _observer1.Show();
            _observer2 = new GraphicalDisplay();
            _observer2.Show();

            for (int i=0; i < 10; i++)
            {
                Ball b = new Ball();
                b.Start();
                _balls.Add(b);

                b.Subscribe(_observer1);
                b.Subscribe(_observer2);
            }

        }

        private void UnsubscribeObserversAndDeleteBalls()
        {
            foreach (Ball b in _balls)
            {
                b.Unsubscribe(_observer1);
                b.Unsubscribe(_observer2);                
            }

            _balls.Clear();
        }

        private void ControlForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            UnsubscribeObserversAndDeleteBalls();
        }
    }
}
