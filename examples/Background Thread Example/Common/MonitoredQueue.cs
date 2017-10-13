using System.Collections.Concurrent;
using System.Threading;

namespace Common
{
    public class MonitoredQueue : IMonitorable
    {
        private readonly ConcurrentQueue<Widget> _myQueue = new ConcurrentQueue<Widget>();

        private readonly MonitoringStat _monitoringStats;
        private MonitoringStat _tmpStats;

        public event MonitoringStatHandler MonitorEvent;

        public MonitoredQueue(string name)
        {
            _monitoringStats = new MonitoringStat($"{name} Queue Size", 0, false);
            SendMonitoringStates();
        }

        public AutoResetEvent StateChanged { get; } = new AutoResetEvent(false);

        public string StatName => _monitoringStats.Name;

        public void Enqueue(Widget widget)
        {
            if (widget == null) return;

            _myQueue.Enqueue(widget);
            _monitoringStats.Value = _myQueue.Count;
            SendMonitoringStates();
            StateChanged.Reset();
        }

        public Widget Dequeue()
        {
            Widget result;

            if (!_myQueue.TryDequeue(out result))
                result = null;
            else
            {
                _monitoringStats.Value = _myQueue.Count;
                SendMonitoringStates();
                StateChanged.Reset();
            }

            return result;
        }

        private void SendMonitoringStates()
        {
            if (MonitorEvent!=null)
            {
                _tmpStats = new MonitoringStat(_monitoringStats);
                MonitorEvent(_tmpStats);
            }
        }
    }
}
