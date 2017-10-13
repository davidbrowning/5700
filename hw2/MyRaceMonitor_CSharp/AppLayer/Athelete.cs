using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RaceData;
using RaceData.Messages;

namespace AppLayer
{
    public class Athlete : Subject
    {
        public Athlete(RegistrationUpdate rp)
        {
            this.Age = rp.Age;
            this.BibNumber = rp.BibNumber;
            this.FirstName = rp.FirstName;
            this.LastName = rp.LastName;
            this.Gender = rp.Gender;
            this.raceStatus = rp.UpdateType;
        }
        public int BibNumber { get; set; }

        internal void Unsubscribe(Observer observer)
        {
            throw new NotImplementedException();
        }
        public AthleteRaceStatus raceStatus { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
