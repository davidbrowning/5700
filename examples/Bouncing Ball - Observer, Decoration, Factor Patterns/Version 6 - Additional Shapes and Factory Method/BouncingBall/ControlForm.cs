using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

using Shapes;

namespace BouncingBall
{
    public partial class ControlForm : Form
    {
        // Data members to track known balls and obversers for UI. These are outside the observer pattern
        private readonly List<Shape> _knownShapes = new List<Shape>();
        private readonly List<ShapeObserver> _knownDisplays = new List<ShapeObserver>();
        private ShapeObserver _selectedObserver;

        public Box MyBox { get; set; }
        public ShapeFactory MyFactory { get; set; }

        public ControlForm()
        {
            InitializeComponent();
        }

        private void RefreshObversersListView()
        {
            observersListView.Items.Clear();
            foreach (ShapeObserver observer in _knownDisplays)
            {
                ListViewItem item = new ListViewItem(observer.Title);
                observersListView.Items.Add(item);
            }
        }

        private void RefreshShapeLists()
        {
            observedShapesListView.Items.Clear();
            otherShapesListView.Items.Clear();

            if (_selectedObserver != null)
                observedBallsLabel.Text = @"Subjects of " + _selectedObserver.Title;
            else
                observedBallsLabel.Text = @"No obverser selected";

            foreach (var shape in _knownShapes)
            {
                var item = new ListViewItem(new[]
                {
                    shape.Id.ToString(),
                    shape.Size.ToString(CultureInfo.InvariantCulture),
                    shape.Speed.ToString(CultureInfo.InvariantCulture)
                }) {Tag = shape};
                if (_selectedObserver != null && shape.Subscribers.Contains(_selectedObserver))
                    observedShapesListView.Items.Add(item);
                else
                    otherShapesListView.Items.Add(item);
            }
        }

        private void observersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (observersListView.SelectedIndices.Count == 1)
            {
                    _selectedObserver = _knownDisplays[observersListView.SelectedIndices[0]];
                    unscribeButton.Enabled = true;
                    subscribeButton.Enabled = true;
            }
            else
            {
                _selectedObserver = null;
                unscribeButton.Enabled = true;
                subscribeButton.Enabled = true;
            }

            RefreshShapeLists();
        }

        private void ControlForm_Load(object sender, EventArgs e)
        {
            RefreshObversersListView();
            RefreshShapeLists();
        }

        private void subscribeButton_Click(object sender, EventArgs e)
        {
            if (_selectedObserver != null)
            {
                foreach (ListViewItem item in otherShapesListView.SelectedItems)
                {
                    Subject subject = item.Tag as Subject;
                    subject?.Subscribe(_selectedObserver);
                }
                RefreshShapeLists();
            }
        }

        private void unscribeButton_Click(object sender, EventArgs e)
        {
            if (_selectedObserver != null)
            {
                foreach (ListViewItem item in observedShapesListView.SelectedItems)
                {
                    Subject subject = item.Tag as Subject;
                    subject?.Unsubscribe(_selectedObserver);
                }
                RefreshShapeLists();
            }
        }

        private void createShapeButton_Click(object sender, EventArgs e)
        {
            CustomShapeFactory.CustomSpecification specs = new CustomShapeFactory.CustomSpecification()
            {
                MyType = (ballOption.Checked ? ShapeFactory.Specification.ShapeType.Ball : (squareOption.Checked) ?
                                ShapeFactory.Specification.ShapeType.Square : ShapeFactory.Specification.ShapeType.Triangle),
                ChangeSize = changeSize.Checked,
                ChangeSpeed = changeSpeed.Checked,
                ChangeDirection = changeDirection.Checked,
                ChangeColor = changeColor.Checked
            };

            var shape = MyFactory.Create(specs);

            shape.Start();
            _knownShapes.Add(shape);

            RefreshShapeLists();
        }

        private void createObserverButton_Click(object sender, EventArgs e)
        {
            var modalDialogForm = new ObserverCreationForm
            {
                Text = @"New Observer",
                ObserverTitle = $"Observer #{_knownDisplays.Count + 1}"
            };
            if (modalDialogForm.ShowDialog() == DialogResult.OK)
            {
                ShapeObserver observer;
                if (modalDialogForm.ObserverType == "L")
                    observer = new ListDisplay();
                else
                    observer = new GraphicalDisplay() { MyBox =  MyBox};

                observer.Title = modalDialogForm.ObserverTitle;
                _knownDisplays.Add(observer);
                observer.Show();

                _selectedObserver = null;
                observersListView.SelectedIndices.Clear();
                RefreshObversersListView();
                RefreshShapeLists();
            }

        }
    }
}
