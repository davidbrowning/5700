﻿using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using AppLayer.Command;
using AppLayer.DrawingComponents;

namespace Forests
{
    // NOTE: There some design problems with this class

    public partial class MainForm : Form
    {
        private readonly Drawing _drawing;
        private string _currentTreeResource;
        private float _currentScale = 1;

        private enum PossibleModes
        {
            None,
            TreeDrawing,
            Selection
        };

        private PossibleModes _mode = PossibleModes.None;

        private Bitmap _imageBuffer;
        private Graphics _imageBufferGraphics;
        private Graphics _panelGraphics;
       
        public MainForm()
        {
            InitializeComponent();

            TreeFactory.Instance.ResourceNamePattern = @"Forests.Graphics.{0}.png";
            TreeFactory.Instance.ReferenceType = typeof(Program);

            _drawing = new Drawing();
            CommandFactory.Instance.TargetDrawing = _drawing;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ComputeDrawingPanelSize();
            refreshTimer.Start();
        }

        private void refreshTimer_Tick(object sender, EventArgs e)
        {
            DisplayDrawing();
        }

        private void DisplayDrawing()
        {
            if (_imageBuffer == null)
            {
                _imageBuffer = new Bitmap(drawingPanel.Width, drawingPanel.Height);
                _imageBufferGraphics = Graphics.FromImage(_imageBuffer);
                _panelGraphics = drawingPanel.CreateGraphics();
            }

            if (_drawing.Draw(_imageBufferGraphics))
                _panelGraphics.DrawImageUnscaled(_imageBuffer, 0, 0);
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            CommandFactory.Instance.Create("new").Execute();
            DisplayDrawing();
        }

        private void ClearOtherSelectedTools(ToolStripButton ignoreItem)
        {
            foreach (ToolStripItem item in drawingToolStrip.Items)
            {
                ToolStripButton toolButton = item as ToolStripButton;
                if (toolButton != null && item!=ignoreItem && toolButton.Checked )
                    toolButton.Checked = false;
            }
        }

        private void pointerButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button!=null && button.Checked)
            {
                _mode = PossibleModes.Selection;
                _currentTreeResource = string.Empty;
            }
            else
            {
                CommandFactory.Instance.Create("deselect").Execute();
                _mode = PossibleModes.None;
            }
        }

        private void treeButton_Click(object sender, EventArgs e)
        {
            ToolStripButton button = sender as ToolStripButton;
            ClearOtherSelectedTools(button);

            if (button != null && button.Checked)
                _currentTreeResource = button.Text;
            else
                _currentTreeResource = string.Empty;

            _mode = (_currentTreeResource != string.Empty) ? PossibleModes.TreeDrawing : PossibleModes.None;
        }

        private void drawingPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_mode == PossibleModes.TreeDrawing)
            {
                if (!string.IsNullOrWhiteSpace(_currentTreeResource))
                    CommandFactory.Instance.Create("add", _currentTreeResource, e.Location, _currentScale)
                        .Execute();
            }
            else if (_mode == PossibleModes.Selection)
                CommandFactory.Instance.Create("select", e.Location).Execute();
        }

        private void scale_Leave(object sender, EventArgs e)
        {
            _currentScale = ConvertToFloat(scale.Text, 0.01F, 99.0F, 1);
            scale.Text = _currentScale.ToString(CultureInfo.InvariantCulture);
        }

        private float ConvertToFloat(string text, float min, float max, float defaultValue)
        {
            float result = defaultValue;
            if (!string.IsNullOrWhiteSpace(text))
            {
                result = !float.TryParse(text, out result) ? defaultValue : Math.Max(min, Math.Min(max, result));
            }
            return result;
        }

        private void scale_TextChanged(object sender, EventArgs e)
        {
            _currentScale = ConvertToFloat(scale.Text, 0.01F, 99.0F, 1);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                CheckFileExists = true,
                DefaultExt = "json",
                Multiselect = false,
                RestoreDirectory = true,
                Filter = @"JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CommandFactory.Instance.Create("load", dialog.FileName).Execute();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog
            {
                DefaultExt = "json",
                RestoreDirectory = true,
                Filter = @"JSON files (*.json)|*.json|All files (*.*)|*.*"
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                CommandFactory.Instance.Create("save", dialog.FileName).Execute();
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ComputeDrawingPanelSize();
        }

        private void ComputeDrawingPanelSize()
        {
            int width = Width - drawingToolStrip.Width;
            int height = Height - fileToolStrip.Height;

            drawingPanel.Size = new Size(width, height);
            drawingPanel.Location = new Point(drawingToolStrip.Width, fileToolStrip.Height);

            _imageBuffer = null;
            if (_drawing != null)
                _drawing.IsDirty = true;
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            _drawing.RemoveSelectedTree();
        }
    }
}