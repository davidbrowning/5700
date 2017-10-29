using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer;
using RaceData.Messages;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            AthleteUpdate au = new RegistrationUpdate
            {
                FirstName = "Bob",
                LastName = "Brown",
                BibNumber = 2
            };
            Athlete athlete = new Athlete(au as RegistrationUpdate);

            AthleteUpdate lu = new LocationUpdate
            {
                LocationOnCourse = 2700
            };
            athlete.Location = (lu as LocationUpdate).LocationOnCourse;
            Assert.AreEqual(2700, athlete.Location);
        }
    }
}
