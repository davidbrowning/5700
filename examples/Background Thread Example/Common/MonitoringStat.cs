namespace Common
{
    public class MonitoringStat
    {
        public string Name { get; set; }
        public float Value { get; set; }
        public bool IsDelta { get; set; }

        public MonitoringStat()
        {
            Name = "";
            Value = 0;
            IsDelta = false;
        }

        public MonitoringStat(string name, float value, bool isDelta)
        {
            Name = name;
            Value = value;
            IsDelta = isDelta;
        }

        public MonitoringStat(MonitoringStat orig)
        {
            Name = orig.Name;
            Value = orig.Value;
            IsDelta = orig.IsDelta;
        }
    }
}
