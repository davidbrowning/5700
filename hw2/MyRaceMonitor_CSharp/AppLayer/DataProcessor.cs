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
            switch (updateMessage.UpdateType)
            {
                case (AthleteRaceStatus.Registered):
                    Athlete a = new Athlete(updateMessage as RegistrationUpdate);
                    ObservedAthletes.GetInstance().AddAthlete(a);
                    a.Notify();
                    break;
                case (AthleteRaceStatus.Started):
                    foreach (var pair in ObservedAthletes.GetInstance().GetDictionary())
                    {
                        pair.Value.Notify();
                    }
                    break;
                case (AthleteRaceStatus.DidNotStart):
                    break;
                case (AthleteRaceStatus.OnCourse):
                    break;
                case (AthleteRaceStatus.Finished):
                    break;
                case (AthleteRaceStatus.DidNotFinish):
                    break;
                default:
                    Console.WriteLine("Error unrecognized AthleteRaceStatus.Registered");
                    break;
            }
            Console.WriteLine(updateMessage.ToString());
        }
    }
}
