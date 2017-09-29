using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RaceData;
using RaceData.Messages;

namespace RaceDataTesting.Messages
{
    [TestClass]
    public class StartedUpdateTest
    {
        [TestMethod]
        public void StartedUpdate_Create()
        {
            var sUpdate = (StartedUpdate)AthleteUpdate.Create("Started,84,8/15/2017 2:34:00 PM,8/15/2017 2:33:45 PM");
            Assert.IsNotNull(sUpdate);

            Assert.AreEqual(AthleteRaceStatus.Started, sUpdate.UpdateType);
            Assert.AreEqual(84, sUpdate.BibNumber);
            Assert.AreEqual(new DateTime(2017, 8, 15, 14, 34, 0), sUpdate.Timestamp);
            Assert.AreEqual(new DateTime(2017, 8, 15, 14, 33, 45), sUpdate.OfficialStartTime);

            try
            {
                var msg = AthleteUpdate.Create("Started,84,8/15/2017 2:34:00 PM");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("Started,84");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("Started");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("Finished,84,bad,8/15/2017 2:34:00 PM,8/15/2017 2:33:45 PM");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }
        }

        [TestMethod]
        public void StartedUpdate_ToString()
        {
            StartedUpdate sUpdate = new StartedUpdate
            {
                BibNumber = 84,
                Timestamp = new DateTime(2017, 8, 15, 14, 34, 0),
                OfficialStartTime = new DateTime(2017, 8, 15, 14, 33, 45)
            };

            Assert.AreEqual("Started,84,8/15/2017 2:34:00 PM,8/15/2017 2:33:45 PM", sUpdate.ToString());
        }


        [TestMethod]
        public void StartedUpdate_GetterAndSetters()
        {
            StartedUpdate sUpdate = new StartedUpdate
            {
                BibNumber = 84,
                Timestamp = new DateTime(2017, 8, 15, 14, 34, 0),
                OfficialStartTime = new DateTime(2017, 8, 15, 14, 33, 45)
            };

            Assert.AreEqual(AthleteRaceStatus.Started, sUpdate.UpdateType);
            Assert.AreEqual(84, sUpdate.BibNumber);
            Assert.AreEqual(new DateTime(2017, 8, 15, 14, 34, 0), sUpdate.Timestamp);
            Assert.AreEqual(new DateTime(2017, 8, 15, 14, 33, 45), sUpdate.OfficialStartTime);

        }
    }
}
