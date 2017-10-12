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
            this.age = rp.Age;
            this.bib_number = rp.BibNumber;
            this.FirstName = rp.FirstName;
            this.LastName = rp.LastName;
            this.Gender = rp.Gender;
            this.raceStatus = rp.UpdateType;
        }
        public int bib_number { get; set; }

        internal void Unsubscribe(Observer observer)
        {
            throw new NotImplementedException();
        }
        public AthleteRaceStatus raceStatus { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Gender { get; set; }
        private int age { get; set; }
    }
}
