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
    public partial class GraphicDisplay : AthleteObserver
    {
        public GraphicDisplay()
        {
            InitializeComponent();
            StartRefreshTimer();
            //progressBar1.Value = 50;
        }
        protected override void RefreshDisplay()
        {
            foreach (Athlete athlete in this.AthletesBeingObserved)
            {
                double percent = (athlete.Location / RaceDistance) * 100;
                double p = Math.Floor(percent);
                progressBar1.Value = (int)Math.Round(p);
                ListViewItem item = new ListViewItem(new[]
                                                {
                                                    athlete.BibNumber.ToString(),
                                                    athlete.raceStatus.ToString(),
                                                    athlete.FirstName.ToString(),
                                                    athlete.LastName.ToString(),
                                                    athlete.Location.ToString(),
                                                    athlete.StartTime.TimeOfDay.ToString(),
                                                    athlete.FinishTime.TimeOfDay.ToString(),
                                                });
                //athleteListView.Items.Add(item);
            }
        }
        public void callRefreshDisplay()
        {
            RefreshDisplay();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
    }
}
