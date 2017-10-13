using System;
using System.Drawing;
using System.Windows.Forms;

namespace Common
{
    public partial class MultiGraph : UserControl
    {
        private GraphDataSet _graphDataSet;

        private int _rowValue;
        private int _rowIncrement = 10;
        private int _standardMargin = 16;
        private float _tickMargin = 1.0F;

        private int _minGraphHeight;
        private int _minGraphWidth;
        private int _graphInnerHeight;
        private int _graphOuterHeight;
        private int _graphInnerWidth;
        private int _graphOuterWidth;
        private float _colInnerWidth;
        private float _colOuterWidth;
        private int _rowOuterHeight;
        private Brush _labelBrush;
        private Brush _columnBrush;
        private Brush _rowLabelBrush;
        private Bitmap _image;
        private Graphics _graphics;

        private readonly GraphDataSetChangedHandler _setupChangeHandler;
        private readonly GraphDataSetChangedHandler _dataChangeHandler;

        public MultiGraph()
        {
            InitializeComponent();
            _setupChangeHandler = ComputeDisplaySettings;
            _dataChangeHandler = DataChanged;
        }

        #region Public Properties
        public int RowIncrement
        {
            get { return _rowIncrement; }
            set
            {
                _rowIncrement = value;
                ComputeDisplaySettings();
            }
        }

        public int StandardMargin
        {
            get { return _standardMargin; }
            set
            {
                _standardMargin = value;
                ComputeDisplaySettings();
            }
        }

        public float TickMargin
        {
            get { return _tickMargin; }
            set
            {
                _tickMargin = value;
                ComputeDisplaySettings();
            }
        }

        public GraphDataSet GraphDataSet
        {
            get { return _graphDataSet; }
            set 
            {
                if (_graphDataSet != null)
                {
                    _graphDataSet.DataChanged -= _dataChangeHandler;
                    _graphDataSet.SetupChanged -= _setupChangeHandler;
                }

                _graphDataSet = value;

                if (_graphDataSet != null)
                {
                    ComputeDisplaySettings();
                    _graphDataSet.DataChanged += _dataChangeHandler;
                    _graphDataSet.SetupChanged += _setupChangeHandler;
                }
            }
        }

        #endregion

        #region Event Handlers
        private void MultiGraph_Load(object sender, EventArgs e)
        {
            _labelBrush = new SolidBrush(ForeColor);
            _rowLabelBrush = new SolidBrush(Color.White);
            ComputeDisplaySettings();
        }

        private void DataChanged()
        {
            RedrawGraphs();
            Invalidate();
        }

        private void MultiGraph_Resize(object sender, EventArgs e)
        {
            ComputeDisplaySettings();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (_graphDataSet == null || _graphDataSet.Count <= 0) return;

            lock (_graphDataSet.GraphLock)
            {
                if (_image != null)
                    e.Graphics.DrawImage(_image, 0, 0);
            }
        }

        #endregion

        #region Private Helper Methods
        private void ComputeDisplaySettings()
        {
            if (_graphDataSet != null && _graphDataSet.Count > 0)
            {
                lock (_graphDataSet.GraphLock)
                {
                    _minGraphHeight = 4 * _graphDataSet.Rows + 2 * _standardMargin;
                    _graphOuterHeight = Math.Max(_minGraphHeight, (ClientSize.Height - _standardMargin) / _graphDataSet.Count);
                    _minGraphWidth = 4 * _graphDataSet.Columns + 2 * _standardMargin;
                    _graphOuterWidth = Math.Max(_minGraphWidth, ClientSize.Width);

                    Location = new Point(0, 0);

                    _graphInnerHeight = _graphOuterHeight - 2 * _standardMargin;
                    _graphInnerWidth = _graphOuterWidth - 2 * _standardMargin;
                    _colOuterWidth = Convert.ToSingle(_graphInnerWidth) / Convert.ToSingle(_graphDataSet.Columns);
                    _colInnerWidth = _colOuterWidth - 2 * _tickMargin;

                    _rowOuterHeight = _graphInnerHeight / _graphDataSet.Rows;
                    //_logger.Debug("In ComputeDisplaySetting, leaving critical section");

                    int height = _graphDataSet.Count * _graphOuterHeight + _standardMargin;
                    _image = new Bitmap(_graphOuterWidth, height);
                    _graphics = Graphics.FromImage(_image);

                    if (ClientSize.Width != _graphOuterWidth || ClientSize.Height != height)
                        Size = new Size(_graphOuterWidth, height);
                }
                RedrawGraphs();
                Invalidate();
            }
        }

        private void RedrawGraphs()
        {
            if (_graphDataSet != null && _graphDataSet.Count > 0 && _labelBrush!=null)
            {
                lock (_graphDataSet.GraphLock)
                {
                    //_logger.Debug("In RedrawGraphs, entering critical section");
                    _graphics.Clear(BackColor);
                    for (int i = 0; i < _graphDataSet.Count; i++)
                    {
                        //_logger.DebugFormat("Draw graph {0}", i);
                        int xOffset = _standardMargin;
                        int yOffset = _standardMargin + i * _graphOuterHeight + _standardMargin;
                        DrawGraph(_graphDataSet[i], xOffset, yOffset);
                    }
                    //_logger.Debug("In RedrawGraphs, leaving critical section");
                }
            }
        }

        private void DrawGraph(GraphData data, int xOffset, int yOffset)
        {
            if (_graphDataSet.Rows <= 0) return;
            var maxValue = Math.Max(10, data.ComputeMaxValue);
            double tmp = maxValue / _rowIncrement;
            maxValue = Convert.ToSingle(Math.Floor(tmp)*_rowIncrement + (Math.Ceiling(tmp) - Math.Floor(tmp))*_rowIncrement);
            _rowValue = Convert.ToInt32(maxValue / _graphDataSet.Rows);

            var scale = _graphInnerHeight / maxValue;

            _graphics.DrawString(data.StatsLabel, Font, _labelBrush, xOffset, yOffset - Font.Height - 4);
            _graphics.FillRectangle(Brushes.Black, xOffset, yOffset, _graphInnerWidth, _graphInnerHeight);
            DrawGridLines(xOffset, yOffset);
            DrawData(data, xOffset, yOffset, scale);
        }

        private void DrawGridLines(int xOffset, int yOffset)
        {
            for (int i = 1; i < _graphDataSet.Rows; i++)
            {
                int y = yOffset + (_graphInnerHeight - i * _rowOuterHeight);
                _graphics.DrawLine(Pens.Gray, xOffset, y, xOffset + _graphInnerWidth - 1, y);

                int rowLabel = i * _rowValue;
                _graphics.DrawString(rowLabel.ToString(), Font, _rowLabelBrush, xOffset, y - Font.Height);
            }
        }

        private void DrawData(GraphData data, int xOffset, int yOffset, float scale)
        {
            for (int colIndex = 0; colIndex < _graphDataSet.Columns; colIndex++)
            {
                int fadeValue = 255-Convert.ToInt32(200*(_graphDataSet.Columns - colIndex)/_graphDataSet.Columns);
                DrawColumn(data[colIndex], fadeValue, xOffset + colIndex * _colOuterWidth + _tickMargin, yOffset, scale);
            }
        }

        private void DrawColumn(float colValue, int fadeValue, float xOffset, float yOffset, float scale)
        {
            if (!(colValue > 0)) return;
            var columnHeight = colValue * scale;
            var columnTop = Math.Max(0, _graphInnerHeight - columnHeight);

            Color barColor = Color.FromArgb(fadeValue, Color.YellowGreen);
            _columnBrush = new SolidBrush(barColor);

            _graphics.FillRectangle(_columnBrush, Convert.ToInt32(xOffset + _tickMargin),
                Convert.ToInt32(yOffset + columnTop),
                Convert.ToInt32(_colInnerWidth),
                Convert.ToInt32(columnHeight));
        }
        #endregion


    }
}
