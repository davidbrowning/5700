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
using RaceData;

namespace GuiLayer
{
    public partial class ControlForm : Form
    {
        private readonly List<AthleteObserver> _knownDisplays = new List<AthleteObserver>();
        private AthleteObserver _selectedObserver = new AthleteObserver();
        public ControlForm()
        {
            InitializeComponent();
        }

        private void RefreshObserverListView()
        {
            observerlv.Items.Clear();
            foreach (AthleteObserver ob in _knownDisplays)
            {
                ListViewItem item = new ListViewItem(ob.Title);
                observerlv.Items.Add(item);
            }

        }

        private void RefreshAthleteLists()
        {
            subscriberlv.Items.Clear();
            athletelv.Items.Clear();

            if(_selectedObserver != null)
            {
                subscriberlv.Text = "@Subjects of " + _selectedObserver.Title;
            }
            else
            {
                subscriberlv.Text = @"No observer selected";
            }

            Dictionary<int, Athlete> _knownAthletes = ObservedAthletes.GetInstance().GetDictionary();
            foreach (var pair in _knownAthletes)
            {
                var item = new ListViewItem(new[]
                {
                    pair.Value.BibNumber.ToString(),
                    pair.Value.FirstName.ToString(),
                    pair.Value.LastName.ToString(),
                    pair.Value.raceStatus.ToString(),
                })
                { Tag = pair.Value };
                if(_selectedObserver != null && pair.Value.Subscribers.Contains(_selectedObserver))
                {
                    subscriberlv.Items.Add(item);
                }
                else
                {
                    athletelv.Items.Add(item);
                }
            }
        }

        private void subscribe_button_click(object sender, EventArgs e)
        {
            if(_selectedObserver != null)
            {
                foreach(ListViewItem item in athletelv.SelectedItems)
                {
                    Subject subject = item.Tag as Subject;
                    subject?.Subscribe(_selectedObserver);
                }
            }
        }

        private void unsubscribe_button_click(object sender, EventArgs e)
        {
            if(_selectedObserver != null)
            {
                foreach(ListViewItem item in subscriberlv.SelectedItems)
                {
                    Subject subject = item.Tag as Subject;
                    subject?.Unsubscribe(_selectedObserver);
                }
                RefreshAthleteLists();
            }
        }

        private void observerlv_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (athletelv.SelectedIndices.Count == 1)
            {
                _selectedObserver = _knownDisplays[athletelv.SelectedIndices[0]];
                unsubscribe_button.Enabled = true;
                subscribe_button.Enabled = true;
            }
            else
            {
                _selectedObserver = null;
                unsubscribe_button.Enabled = true;
                subscribe_button.Enabled = true;
            }

            RefreshAthleteLists();
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            RefreshObserverListView();
            RefreshAthleteLists();
        }

        private void create_observer_button_Click(object sender, EventArgs e)
        {
            var modalDialogForm = new ObserverCreationForm
            {
                Text = @"New Observer",
                Title = $"Observer #{_knownDisplays.Count + 1}"
            };
            if(modalDialogForm.ShowDialog() == DialogResult.OK)
            {
                AthleteObserver observer;
                observer = new ListDisplay();
                observer.Title = "List Display";
                _knownDisplays.Add(observer);
                observer.Show();

                _selectedObserver = null;
                observerlv.SelectedIndices.Clear();
                RefreshObserverListView();
                RefreshAthleteLists();
            }
        }
    }
}
