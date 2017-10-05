using System;
using System.Windows.Forms;

namespace BouncingBall
{
    public partial class ObserverCreationForm : Form
    {
        public ObserverCreationForm()
        {
            InitializeComponent();
        }

        public string ObserverTitle
        {
            get { return titleTextBox.Text; }
            set { titleTextBox.Text = value; }
        }

        private void creaetionButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        public string ObserverType
        {
            get { return (listTypeRadioButton.Checked) ? "L" : "G"; }
        }
    }
}
