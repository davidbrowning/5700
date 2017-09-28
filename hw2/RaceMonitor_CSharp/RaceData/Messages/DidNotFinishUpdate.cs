using System;

namespace RaceData.Messages
{
    public class DidNotFinishUpdate : AthleteUpdate
    {
        public DidNotFinishUpdate() : base(AthleteRaceStatus.DidNotFinish) { }

        public DidNotFinishUpdate(string[] properties) : base(AthleteRaceStatus.DidNotFinish, properties)
        {
            if (properties.Length != 3 || properties[0] != AthleteRaceStatus.DidNotFinish.ToString())
                throw new ApplicationException("Invalid properties");
        }

    }
}
