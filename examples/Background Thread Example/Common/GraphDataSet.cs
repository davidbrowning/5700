using System.Collections.Generic;

namespace Common
{
    public delegate void GraphDataSetChangedHandler();

    public class GraphDataSet
    {
        private GraphData[] _graphDataSets;
        private int _columns;

        public int Rows { get; set; }
        public object GraphLock { get; set; }

        public event GraphDataSetChangedHandler SetupChanged;
        public event GraphDataSetChangedHandler DataChanged;

        public GraphDataSet(List<string> statsDef, int rows, int columns)
        {
            GraphLock = new object();
            Initialize(statsDef, rows, columns);
        }

        #region Public Methods

        public void Initialize(List<string> statsDef, int rows, int columns)
        {
            Rows = rows;
            _columns = columns;
            SetupGraphData(statsDef, columns);
            SetupChanged?.Invoke();
        }

        public int Count => _graphDataSets?.Length ?? 0;

        public int Columns
        {
            get { return _columns; }
            set
            {
                foreach (GraphData data in _graphDataSets)
                    data.NumberOfColumns = value;

                SetupChanged?.Invoke();
            }
        }

        public GraphData this[int index] => (_graphDataSets==null || index<0 || index>=_graphDataSets.Length) ? null : _graphDataSets[index];

        public GraphData this[string code]
        {
            get
            {
                GraphData result = null;
                for (int i=0; i<_graphDataSets.Length && result==null; i++)
                {
                    if (_graphDataSets[i].StatsCode==code)
                        result = _graphDataSets[i];
                }
                return result;
            }
        }

        public void RollForward()
        {
            foreach (GraphData data in _graphDataSets)
                data.RollForward();
            DataChanged?.Invoke();
        }

        #endregion

        #region Helper Functions

        private void SetupGraphData(List<string> statsDef, int columns)
        {
            if (statsDef != null && columns > 0)
            {

                GraphData[] newGraphDataSets = new GraphData[statsDef.Count];
                for (int i = 0; i < statsDef.Count; i++)
                {
                    if (!string.IsNullOrEmpty(statsDef[i]))
                    {
                        string[] tmp = statsDef[i].Split('|');
                        string statsCode = tmp[0].Trim();
                        string statsLabel = (tmp.Length > 1) ? tmp[1].Trim() : statsCode;
                        newGraphDataSets[i] = new GraphData(statsCode, statsLabel, columns);
                    }
                }

                lock (GraphLock)
                {
                    _graphDataSets = newGraphDataSets;
                }
            }
        }

        #endregion
    }
}
