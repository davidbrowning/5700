using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuiLayer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listView1.Columns.Add(new string('x', 250));
            listView1.Items.Add("Hello Dave",250);
            listView1.Columns[0].Width = -2;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            e.ToString();
            listView1.Items.Add("HELLO!!!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(ShowControlForm)).Start();
        }
        public void ShowControlForm()
        {
            Form2 f2 = new Form2
            {
                Text = "FORM 2"
            };
            f2.Show();
            Application.Run();
        }
    }
}
