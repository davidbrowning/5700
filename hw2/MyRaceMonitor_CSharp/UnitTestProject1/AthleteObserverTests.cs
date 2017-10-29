using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaceData.Messages;

namespace AppLayer.Tests
{
    [TestClass()]
    public class AthleteObserverTests
    {
        [TestMethod()]
        public void UpdateTest()
        {
            AthleteUpdate au = new RegistrationUpdate
            {
                FirstName = "Bob",
                LastName = "Brown",
                BibNumber = 2
            };
            Athlete athlete = new Athlete(au as RegistrationUpdate);
            AthleteObserver ao = new AthleteObserver();
            ao.Update(athlete as Subject);
            Assert.AreEqual(ao._AthletesBeingObserved.ContainsKey(athlete.BibNumber), true);
        }
    }
}