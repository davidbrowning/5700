using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RaceData;

namespace RaceDataTesting
{
    [TestClass]
    public class RaceEventTest
    {
        [TestMethod]
        public void RaceEventTester_Everything()
        {
            var raceEvent = new RaceEvent()
            {
                Id = 1,
                StartDateTime = new DateTime(2017, 8, 10, 7, 10, 15),
                Title = "Test Event"
            };

            Assert.AreEqual(1, raceEvent.Id);
            Assert.AreEqual(new DateTime(2017, 8, 10, 7, 10, 15), raceEvent.StartDateTime);
            Assert.AreEqual("Test Event", raceEvent.Title);

            raceEvent.Id = 2;
            Assert.AreEqual(2, raceEvent.Id);

            raceEvent.StartDateTime = new DateTime(2017, 9, 12, 8, 15, 25);
            Assert.AreEqual(new DateTime(2017, 9, 12, 8, 15, 25), raceEvent.StartDateTime);

            raceEvent.Title = "New Event Title";
            Assert.AreEqual("New Event Title", raceEvent.Title);
        }
    }
}
