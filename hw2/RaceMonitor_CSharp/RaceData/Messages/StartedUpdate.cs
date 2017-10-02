using System;

namespace RaceData.Messages
{
    public class StartedUpdate : AthleteUpdate
    {
        public DateTime OfficialStartTime { get; set; }

        public StartedUpdate() : base(AthleteRaceStatus.Started) { }

        public StartedUpdate(string[] properties) : base(AthleteRaceStatus.Started, properties)
        {
            if (properties.Length != 4 || properties[0] != AthleteRaceStatus.Started.ToString())
                throw new ApplicationException("Invalid properties");

            OfficialStartTime = Convert.ToDateTime(properties[3]);
        }

        public override string ToString()
        {
            return $"{base.ToString()},{OfficialStartTime}";
        }
    }
}
