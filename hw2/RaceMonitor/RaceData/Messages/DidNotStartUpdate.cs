using System;

namespace RaceData.Messages
{
    public class DidNotStartUpdate : AthleteUpdate
    {
        public DidNotStartUpdate() : base(AthleteRaceStatus.DidNotStart) { }

        public DidNotStartUpdate(string[] properties) : base(AthleteRaceStatus.DidNotStart, properties)
        {
            if (properties.Length != 3 || properties[0] != AthleteRaceStatus.DidNotStart.ToString())
                throw new ApplicationException("Invalid properties");
        }

    }
}
