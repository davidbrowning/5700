using System;
using System.Windows.Forms;

namespace Forests
{
    public partial class LabelBoxForm : Form
    {
        public string LabelText { get; set; }
        public LabelBoxForm()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            LabelText = labelText.Text;
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
