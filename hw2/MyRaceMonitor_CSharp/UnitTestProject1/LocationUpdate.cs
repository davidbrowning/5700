using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer;
using RaceData.Messages;

namespace UnitTestProject1
{
    [TestClass]
    public class LocationUpdate
    {
        [TestMethod]
        public void LocationUpdateTest()
        {
            // Test Location Update
            AthleteUpdate au = new RegistrationUpdate
            {
                FirstName = "Bob",
                LastName = "Brown",
                BibNumber = 2
            };
            Athlete athlete = new Athlete(au as RegistrationUpdate);

            AthleteUpdate lu = new RaceData.Messages.LocationUpdate
            {
                LocationOnCourse = 2700
            };
            athlete.Location = (lu as RaceData.Messages.LocationUpdate).LocationOnCourse;
            Assert.AreEqual(2700, athlete.Location);
        }
    }
}
