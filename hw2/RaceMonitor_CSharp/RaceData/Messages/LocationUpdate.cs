using System;

namespace RaceData.Messages
{

    public class LocationUpdate : AthleteUpdate
    {
        public double LocationOnCourse { get; set; }

        public LocationUpdate() : base(AthleteRaceStatus.OnCourse) { }

        public LocationUpdate(string[] properties) : base(AthleteRaceStatus.OnCourse, properties)
        {
            if (properties.Length != 4 || properties[0] != AthleteRaceStatus.OnCourse.ToString())
                throw new ApplicationException("Invalid properties");

            LocationOnCourse = Convert.ToDouble(properties[3]);
        }

        public override string ToString()
        {
            return $"{base.ToString()},{LocationOnCourse}";
        }
    }
}
