using System;

namespace RaceData.Messages
{
    public class RegistrationUpdate : AthleteUpdate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }

        public RegistrationUpdate() : base(AthleteRaceStatus.Registered) {}

        public RegistrationUpdate(string[] properties) : base(AthleteRaceStatus.Registered, properties)
        {
            if (properties.Length!=7 || properties[0] != AthleteRaceStatus.Registered.ToString())
                throw new ApplicationException("Invalid properties");

            FirstName = properties[1];
            LastName = properties[2];
            Gender = properties[3];
            Age = Convert.ToInt32(properties[4]);
        }


        public override string ToString()
        {
            return $"{base.ToString()},{FirstName},{LastName},{Gender},{Age}";
        }

    }
}
