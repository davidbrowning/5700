using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Common
{
    public partial class MonitorForm : Form
    {

        private List<string> _displayedStats;
        private List<IMonitorable> _monitoredObjects;
        private MonitoringStatHandler _monitoringDelegate;

        private bool _loaded;

        private int _refreshInterval = 250;

        private int _graphColumns = 60;
        private int _graphRows = 5;

        private int _rowIncrement = 10;
        private int _standardMargin = 16;

        private Timer _redrawTimer;

        public MonitorForm()
        {
            InitializeComponent();
        }

        #region Public Properties
        public int RefreshInterval
        { 
            get { return _refreshInterval; }
            set { _refreshInterval = value; }
        }

        public int RowIncrement
        {
            get { return _rowIncrement; }
            set
            {
                _rowIncrement = value;
                statsMultiGraph.RowIncrement = _rowIncrement;
            }
        }

        public int StandardMargin
        {
            get { return _standardMargin; }
            set
            {
                _standardMargin = value;
                statsMultiGraph.StandardMargin = _standardMargin;
            }
        }

        public float TickMargin
        {
            get { return statsMultiGraph.TickMargin; }
            set { statsMultiGraph.TickMargin = value; }
        }

        public int GraphColumns
        {
            get { return _graphColumns; }
            set
            {
                _graphColumns = value;
                SetupMultiGraph();
            }
        }

        public int GraphRows
        {
            get { return _graphRows; }
            set
            {
                _graphRows = value;
                SetupMultiGraph();
            }
        }

        public List<IMonitorable> MonitoredObjects
        {
            get { return _monitoredObjects; }
            set
            {
                if (_monitoredObjects != null && _monitoredObjects.Count > 0 && _monitoringDelegate != null)
                {
                    foreach (IMonitorable mObj in _monitoredObjects)
                        mObj.MonitorEvent -= _monitoringDelegate;
                }

                _monitoringDelegate = null;
                _monitoredObjects = value ?? new List<IMonitorable>();

                if (_monitoredObjects.Count <= 0)
                    return;

                _monitoringDelegate = RecordMonitorData;
                foreach (var mObj in _monitoredObjects)
                    mObj.MonitorEvent += _monitoringDelegate;
            }
        }

        public List<string> DisplayedStats
        {
            get { return _displayedStats; }
            set
            {
                _displayedStats = value;
                SetupMultiGraph();
            }
        }

        #endregion

        #region Event Handlers
        private void SetupMultiGraph()
        {          
            if (_displayedStats!=null && GraphRows>0 && GraphColumns>0)
                statsMultiGraph.GraphDataSet = new GraphDataSet(_displayedStats, GraphRows, GraphColumns);
        }

        private void MonitorForm_Load(object sender, EventArgs e)
        {
            _redrawTimer = new Timer();
            _redrawTimer.Tick += RedrawTimer_Tick;
            _redrawTimer.Interval = _refreshInterval;
            _redrawTimer.Start();

            SetStyle(ControlStyles.UserPaint, true);
            Invalidate();

            _loaded = true;
        }

        private void RecordMonitorData(MonitoringStat stat)
        {
            if (InvokeRequired)
            {
                var mth = new MonitoringStatHandler(RecordMonitorData);
                BeginInvoke(mth, stat);
            }
            else
            {
                if (!_loaded) return;
                if (stat == null) return;

                lock (statsMultiGraph.GraphDataSet.GraphLock)
                {
                    GraphData data = statsMultiGraph.GraphDataSet[stat.Name];
                    if (data == null) return;

                    if (stat.IsDelta)
                        data.TenativeValue += stat.Value;
                    else
                        data.TenativeValue = stat.Value;
                }
            }
        }

        private void MonitorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _redrawTimer?.Stop();

            // Be sure to de-register this form from the monitored objects
            if (MonitoredObjects == null || _monitoringDelegate == null) return;

            foreach (IMonitorable mObj in _monitoredObjects)
                mObj.MonitorEvent -= _monitoringDelegate;
        }

        void RedrawTimer_Tick(object sender, EventArgs e)
        {
            if (_loaded)
                statsMultiGraph.GraphDataSet?.RollForward();
        }

        #endregion

    }
}
