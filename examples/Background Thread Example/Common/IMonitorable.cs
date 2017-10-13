namespace Common
{
    public delegate void MonitoringStatHandler(MonitoringStat stats);

    public interface IMonitorable
    {
        event MonitoringStatHandler MonitorEvent;
    }
}
