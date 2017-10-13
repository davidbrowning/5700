using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLayer
{
    public class AthleteObserver : Form
    {
        //private readonly Dictionary<int, Athlete> _AthletesBeingObserved = new Dictionary<int, Athlete>();
        private readonly Dictionary<int, Athlete> _AthletesBeingObserved = new Dictionary<int, Athlete>();
        protected bool RepaintNeeded = false;
        private readonly Timer _refreshTester = new Timer();
        private readonly object _myLock = new object();

        public int RefreshFrequency { get; set; }
        public string Title { get; set; }

        public virtual void Update(Subject subject)
        {
            var Athlete = subject as Athlete;
            if (Athlete == null)
                return;

            lock (_myLock)
            {
                if (!_AthletesBeingObserved.ContainsKey(Athlete.BibNumber))
                    _AthletesBeingObserved.Add(Athlete.BibNumber, Athlete);
                else
                    _AthletesBeingObserved[Athlete.BibNumber] = Athlete;
            }
            RepaintNeeded = true;
        }

        protected void StartRefreshTimer()
        {
            if (RefreshFrequency <= 0)
                RefreshFrequency = 50;

            _refreshTester.Interval = RefreshFrequency;
            _refreshTester.Tick += refreshTimer_Tick;
            _refreshTester.Start();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            if (RepaintNeeded)
            {
                lock (_myLock)
                {
                    RefreshDisplay();
                    RepaintNeeded = false;
                }
            }
        }

        protected virtual void RefreshDisplay() { }

        protected void UnregisterFromAllSubjects()
        {
            var iterator = _AthletesBeingObserved.GetEnumerator();
            while (iterator.MoveNext())
                iterator.Current.Value.Unsubscribe(this);
        }

        protected List<Athlete> AthletesBeingObserved => _AthletesBeingObserved.Values.ToList();

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AthleteObserver
            // 
            this.ClientSize = new System.Drawing.Size(282, 253);
            this.Name = "AthleteObserver";
            this.Load += new System.EventHandler(this.AthleteObserver_Load);
            this.ResumeLayout(false);

        }

        private void AthleteObserver_Load(object sender, EventArgs e)
        {

        }
    }
}
