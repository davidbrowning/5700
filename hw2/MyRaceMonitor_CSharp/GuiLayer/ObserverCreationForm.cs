using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AppLayer;

namespace GuiLayer
{
    public partial class ObserverCreationForm : AthleteObserver
    {
        public ObserverCreationForm()
        {
            InitializeComponent();
        }
        public string ObserverTitle = "Title";
        public string ObserverType
        {
            get { return (ListViewRadioButton.Checked) ? "L" : "G"; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
