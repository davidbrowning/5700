using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RaceData;
using RaceData.Messages;

namespace AppLayer
{
    public class DataProcessor : IAthleteUpdateHandler
    {
        public void ProcessUpdate(AthleteUpdate updateMessage)
        {
            Athlete a;
            switch (updateMessage.UpdateType)
            {
                case (AthleteRaceStatus.Registered):
                    a = new Athlete(updateMessage as RegistrationUpdate);
                    ObservedAthletes.GetInstance().AddAthlete(a);
                    a.Notify();
                    break;
                case (AthleteRaceStatus.Started):
                    a = ObservedAthletes.GetInstance().GetDictionary()[updateMessage.BibNumber];
                    var msg = updateMessage as StartedUpdate;
                    a.StartTime = msg.OfficialStartTime;
                    a.raceStatus = updateMessage.UpdateType;
                    a.Notify();
                    break;
                case (AthleteRaceStatus.DidNotStart):
                    a = ObservedAthletes.GetInstance().GetDictionary()[updateMessage.BibNumber];
                    a.raceStatus = (updateMessage as DidNotStartUpdate).UpdateType;
                    a.Notify();
                    break;
                case (AthleteRaceStatus.OnCourse):
                    a = ObservedAthletes.GetInstance().GetDictionary()[updateMessage.BibNumber];
                    a.raceStatus = (updateMessage as LocationUpdate).UpdateType;
                    a.Location = (updateMessage as LocationUpdate).LocationOnCourse;
                    a.Notify();
                    break;
                case (AthleteRaceStatus.Finished):
                    a = ObservedAthletes.GetInstance().GetDictionary()[updateMessage.BibNumber];
                    a.raceStatus = (updateMessage as FinishedUpdate).UpdateType;
                    a.FinishTime = (updateMessage as FinishedUpdate).OfficialEndTime;
                    a.Notify();
                    break;
                case (AthleteRaceStatus.DidNotFinish):
                    a = ObservedAthletes.GetInstance().GetDictionary()[updateMessage.BibNumber];
                    a.raceStatus = (updateMessage as DidNotFinishUpdate).UpdateType;
                    a.Notify();
                    break;
                default:
                    Console.WriteLine("Error unrecognized AthleteRaceStatus.Registered");
                    break;
            }
            Console.WriteLine(updateMessage.ToString());
        }
    }
}
