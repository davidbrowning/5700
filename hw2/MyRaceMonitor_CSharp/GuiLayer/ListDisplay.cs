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
            StartRefreshTimer();
        }
        protected override void RefreshDisplay()
        {
            athleteListView.Items.Clear();
            foreach (Athlete athlete in this.AthletesBeingObserved)
            {
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
                athleteListView.Items.Add(item);
            }
        }
        public void callRefreshDisplay()
        {
            RefreshDisplay();
        }
    }
}

