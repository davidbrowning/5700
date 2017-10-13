using System;

namespace Common
{
    public class GraphData
    {
        public string StatsCode { get; set; }
        public string StatsLabel { get; set; }
        public float TenativeValue { get; set; }

        private int _numberOfColumns = -1;
        private float[] _ticks;
        private float _maxValue;
        private bool _maxValueDirty = true;

        public GraphData(string code, string label, int columns)
        {
            StatsCode = code;
            StatsLabel = label;
            NumberOfColumns = columns;
        }

        public int NumberOfColumns
        {
            get { return _numberOfColumns; }
            set
            {
                _numberOfColumns = (value<0) ? 0 : value;
                float[] newTicks = new float[_numberOfColumns];
                if (_ticks != null)
                {
                    for (int i = 0; i < _ticks.Length && i < newTicks.Length; i++)
                        newTicks[i] = _ticks[i];
                }
                _ticks = newTicks;
            }
        }

        public float this[int columnIndex]
        {
            get
            {
                float result = 0;
                if (_ticks!=null & columnIndex >= 0 && columnIndex < _numberOfColumns)
                    result = _ticks[columnIndex];
                return result;
            }
            set
            {
                if (_ticks != null && columnIndex >= 0 && columnIndex < _numberOfColumns &&
                    Math.Abs(_ticks[columnIndex] - value) > 0.001)
                {
                    _ticks[columnIndex] = value;
                    _maxValueDirty = true;
                }
            }
        }

        public float ComputeMaxValue
        {
            get
            {
                if (_maxValueDirty)
                {
                    _maxValueDirty = false;
                    _maxValue = 0;
                    for (int colIndex = 0; colIndex < _numberOfColumns; colIndex++)
                        if (_ticks[colIndex] > _maxValue)
                            _maxValue = _ticks[colIndex];
                }
                return _maxValue;
            }
        }

        public void AddToEnd(float value)
        {
            for (int index = 0; index < _numberOfColumns - 1; index++)
                _ticks[index] = _ticks[index + 1];

            _ticks[_numberOfColumns-1] = value;
            _maxValueDirty = true;
        }

        public void RollForward()
        {
            AddToEnd(TenativeValue);
            TenativeValue = 0;
        }

    }
}
