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
    public partial class ListDisplay : AthleteObserver
    {
        public ListDisplay()
        {
            InitializeComponent();
        }
        protected override void RefreshDisplay()
        {
                MessageBox.Show("Refreshing List Observer...", "Some title", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //This function is never entered
            athleteListView.Items.Clear();
            foreach (Athlete athlete in ObservedAthletes.GetInstance().GetList())
            {
                ListViewItem item = new ListViewItem(new []
                                                {
                                                    athlete.FirstName.ToString(),
                                                    athlete.LastName.ToString(),
                                                    athlete.BibNumber.ToString(),
                                                });
                athleteListView.Items.Add(item);
            }
        }
        private void ListDisplay_Load(object sender, EventArgs e)
        {
            Text = Title;
            StartRefreshTimer();
        }
    }
}

