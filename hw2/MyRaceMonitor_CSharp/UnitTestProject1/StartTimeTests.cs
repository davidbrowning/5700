using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer;
using RaceData;
using RaceData.Messages;

namespace UnitTestProject1
{
    [TestClass]
    public class StartTimeTests
    {
        [TestMethod]
        //Test Start Time
        public void StartTimeTest()
        {
            AthleteUpdate au = new RegistrationUpdate
            {
                FirstName = "Bob",
                LastName = "Brown",
                BibNumber = 2
            };
            Athlete athlete = new Athlete(au as RegistrationUpdate);


            AthleteUpdate lu = new StartedUpdate
            {
                OfficialStartTime = new DateTime(2017, 10, 13)
            };
            athlete.StartTime = (lu as StartedUpdate).OfficialStartTime;
            Assert.AreEqual(new DateTime(2017,10,13), athlete.StartTime);
        }
    }
}
