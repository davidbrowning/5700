using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Common;

namespace BTExample1
{
    public partial class MainForm : Form
    {
        private bool _producerStarted;
        private bool _producerSuspended;
        private bool _packagerStarted;
        private bool _packagerSuspended;
        private bool _consumerStarted;
        private bool _consumerSuspended;

        private Producer _producer;
        private Packager _packager;
        private Consumer _consumer;

        private readonly List<string> _queueNames = new List<string> { "Built", "Packaged" };
        private readonly List<string> _statsNames = new List<string>();
        private readonly List<IMonitorable> _queues = new List<IMonitorable>();

        private MonitorForm _monitorForm;

        public MainForm()
        {
            InitializeComponent();
        }

        private void SetupDisplaySettings(bool started, bool suspended, Button startButton, Button suspendButton)
        {
            startButton.Text = (started) ? "Stop" : "Start";
            if (started)
            {
                suspendButton.Visible = true;
                suspendButton.Text = (suspended) ? "Resume" : "Suspend";
            }
            else
                suspendButton.Visible = false;
        }

        private void producerStartStopButton_Click(object sender, EventArgs e)
        {
            _producerStarted = !_producerStarted;
            if (_producerStarted)
                _producer.Start();
            else
                _producer.Stop();
            SetupDisplaySettings(_producerStarted, _producerSuspended, producerStartStopButton, producerSuspendResumeButton);
        }

        private void producerSuspendResumeButton_Click(object sender, EventArgs e)
        {
            _producerSuspended = !_producerSuspended;
            if (_producerSuspended)
                _producer.Suspend();
            else
                _producer.Resume();
            SetupDisplaySettings(_producerStarted, _producerSuspended, producerStartStopButton, producerSuspendResumeButton);
        }

        private void packagerStartStopButton_Click(object sender, EventArgs e)
        {
            _packagerStarted = !_packagerStarted;
            if (_packagerStarted)
                _packager.Start();
            else
                _packager.Stop();
            SetupDisplaySettings(_packagerStarted, _packagerSuspended, packagerStartStopButton, packagerSuspendResumeButton);
        }

        private void packagerSuspendResumeButton_Click(object sender, EventArgs e)
        {
            _packagerSuspended = !_packagerSuspended;
            if (_packagerSuspended)
                _packager.Suspend();
            else
                _packager.Resume();
            SetupDisplaySettings(_packagerStarted, _packagerSuspended, packagerStartStopButton, packagerSuspendResumeButton);
        }

        private void consumingStartStopButton_Click(object sender, EventArgs e)
        {
            _consumerStarted = !_consumerStarted;
            if (_consumerStarted)
                _consumer.Start();
            else
                _consumer.Stop();
            SetupDisplaySettings(_consumerStarted, _consumerSuspended, consumingStartStopButton, consumingSuspendResumeButton);
        }

        private void consumingSuspendResumeButton_Click(object sender, EventArgs e)
        {
            _consumerSuspended = !_consumerSuspended;
            if (_consumerSuspended)
                _consumer.Suspend();
            else
                _consumer.Stop();
            SetupDisplaySettings(_consumerStarted, _consumerSuspended, consumingStartStopButton, consumingSuspendResumeButton);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (string name in _queueNames)
            {
                MonitoredQueue mQueue = new MonitoredQueue(name);
                _queues.Add(mQueue);
                _statsNames.Add(mQueue.StatName);
            }

            _monitorForm = new MonitorForm
            {
                MonitoredObjects = _queues,
                DisplayedStats = _statsNames
            };
            _monitorForm.Show();

            _producer = new Producer((MonitoredQueue) _queues[0], Convert.ToInt32(productionTime.Value));
            _packager = new Packager((MonitoredQueue) _queues[0], (MonitoredQueue) _queues[1], Convert.ToInt32(packagingTime.Value));
            _consumer = new Consumer((MonitoredQueue) _queues[1], Convert.ToInt32(consumingTime.Value));
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _monitorForm?.Close();
        }

        private void productionTime_ValueChanged(object sender, EventArgs e)
        {
            _producer.SimulatedWorkTime = Convert.ToInt32(productionTime.Value);
        }

        private void packagingTime_ValueChanged(object sender, EventArgs e)
        {
            _packager.SimulatedWorkTime = Convert.ToInt32(packagingTime.Value);
        }

        private void consumingTime_ValueChanged(object sender, EventArgs e)
        {
            _consumer.SimulatedWorkTime = Convert.ToInt32(consumingTime.Value);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
