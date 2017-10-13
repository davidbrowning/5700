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
    public partial class SplashForm : AthleteObserver
    {
        Dictionary<int, Athlete> selected_athletes = new Dictionary<int, Athlete>();
        public SplashForm()
        {
            InitializeComponent();
        }

        private void refresh_buttonClick(object sender, EventArgs e)
        {
            Dictionary<int, Athlete> current_map = ObservedAthletes.GetInstance().GetDictionary();
            ListedAthletes.Items.Clear();
            foreach (KeyValuePair<int, Athlete> entry in current_map)
            {
                ListedAthletes.Items.Add(entry.Value.BibNumber);
            }
        }

        protected override void RefreshDisplay()
        {
            Dictionary<int, Athlete> current_map = ObservedAthletes.GetInstance().GetDictionary();
            ListedAthletes.Items.Clear();
            foreach (KeyValuePair<int, Athlete> entry in current_map)
            {
                ListedAthletes.Items.Add(entry.Value.BibNumber);
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            AthleteObserver selectedObserver = new AthleteObserver();
            if (radioButton1.Checked)
            {
                selectedObserver = new ListDisplay();
                foreach(var ath in selected_athletes)
                {
                    Subject subject = ath.Value as Subject;
                    subject?.Subscribe(selectedObserver);
                    selectedObserver.Update(subject);
                }
                selectedObserver.Show();
            }
            if (radioButton2.Checked)
            {
                selectedObserver = new GraphicDisplay();
            }

        }

        private void ListedAthletes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Dictionary<int, Athlete> current_map = ObservedAthletes.GetInstance().GetDictionary();
            selected_athletes.Clear();
            foreach (var ath in ListedAthletes.CheckedItems)
            {
                int bibno = int.Parse(ath.ToString());
                selected_athletes.Add(bibno, current_map[bibno]);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
             //   MessageBox.Show("Creating List Observer...", "Some title", 
             //       MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else if (radioButton2.Checked)
            {
                MessageBox.Show("Creating Graphic Observer...", "Some title", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SplashForm_Load(object sender, EventArgs e)
        {
            RefreshDisplay();
            StartRefreshTimer();
        }
    }
}
