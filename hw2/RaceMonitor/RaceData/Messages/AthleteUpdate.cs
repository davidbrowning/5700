using System;

namespace RaceData.Messages
{
    public abstract class AthleteUpdate
    {
        public AthleteRaceStatus UpdateType { get; set; }
        public int BibNumber { get; set; }
        public DateTime Timestamp { get; set; }

        protected AthleteUpdate(AthleteRaceStatus type)
        {
            UpdateType = type;
        }

        protected AthleteUpdate(AthleteRaceStatus type, string[] properties)
        {
            UpdateType = type;
            BibNumber = Convert.ToInt32(properties[1]);
            Timestamp = Convert.ToDateTime(properties[2]);
        }

        public static AthleteUpdate Create(string simulationData)
        {
            if (string.IsNullOrWhiteSpace(simulationData))
                return null;

            string[] fields = simulationData.Split(',');
            AthleteRaceStatus objectType = (AthleteRaceStatus) Convert.ToInt32(fields[0]);

            AthleteUpdate result=null;
            switch (objectType)
            {
                case AthleteRaceStatus.Registered:
                    result = new RegistrationUpdate(fields);
                    break;
                case AthleteRaceStatus.DidNotStart:
                    result = new DidNotStartUpdate(fields);
                    break;
                case AthleteRaceStatus.Started:
                    result = new StartedUpdate(fields);
                    break;
                case AthleteRaceStatus.OnCourse:
                    result = new LocationUpdate(fields);
                    break;
                case AthleteRaceStatus.DidNotFinish:
                    result = new DidNotFinishUpdate(fields);
                    break;
                case AthleteRaceStatus.Finished:
                    break;
            }
            return result;
        }

        public override string ToString()
        {
            return $"{UpdateType},{BibNumber},{Timestamp}";
        }
    }
}
