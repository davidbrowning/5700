using System;

namespace RaceData.Messages
{
    public class FinishedUpdate :AthleteUpdate
    {
        public DateTime OfficialEndTime { get; set; }

        public FinishedUpdate() : base(AthleteRaceStatus.Finished) { }

        public FinishedUpdate(string[] properties) : base(AthleteRaceStatus.Finished, properties)
        {
            if (properties.Length != 4 || properties[0] != AthleteRaceStatus.Finished.ToString())
                throw new ApplicationException("Invalid properties");

            OfficialEndTime = Convert.ToDateTime(properties[3]);
        }

        public override string ToString()
        {
            return $"{base.ToString()},{OfficialEndTime}";
        }
    }

}
