using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RaceData;
using RaceData.Messages;

namespace RaceDataTesting.Messages
{
    [TestClass]
    public class FinishedUpdateTest
    {
        [TestMethod]
        public void FinishedUpdate_Create()
        {
            var fUpdate = (FinishedUpdate)AthleteUpdate.Create("Finished,84,8/15/2017 2:34:00 PM,8/15/2017 2:33:45 PM");
            Assert.IsNotNull(fUpdate);

            Assert.AreEqual(AthleteRaceStatus.Finished, fUpdate.UpdateType);
            Assert.AreEqual(84, fUpdate.BibNumber);
            Assert.AreEqual(new DateTime(2017, 8, 15, 14, 34, 0), fUpdate.Timestamp);
            Assert.AreEqual(new DateTime(2017, 8, 15, 14, 33, 45), fUpdate.OfficialEndTime);

            try
            {
                var msg = AthleteUpdate.Create("Finished,84,8/15/2017 2:34:00 PM");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("Finished,84");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("Finished");
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
        public void FinishedUpdate_ToString()
        {
            FinishedUpdate fUpdate = new FinishedUpdate
            {
                BibNumber = 84,
                Timestamp = new DateTime(2017, 8, 15, 14, 34, 0),
                OfficialEndTime = new DateTime(2017, 8, 15, 14, 33, 45)
            };

            Assert.AreEqual("Finished,84,8/15/2017 2:34:00 PM,8/15/2017 2:33:45 PM", fUpdate.ToString());
        }


        [TestMethod]
        public void FinishedUpdate_GetterAndSetters()
        {
            FinishedUpdate fUpdate = new FinishedUpdate
            {
                BibNumber = 84,
                Timestamp = new DateTime(2017, 8, 15, 14, 34, 0),
                OfficialEndTime = new DateTime(2017, 8, 15, 14, 33, 45)
            };

            Assert.AreEqual(AthleteRaceStatus.Finished, fUpdate.UpdateType);
            Assert.AreEqual(84, fUpdate.BibNumber);
            Assert.AreEqual(new DateTime(2017, 8, 15, 14, 34, 0), fUpdate.Timestamp);
            Assert.AreEqual(new DateTime(2017, 8, 15, 14, 33, 45), fUpdate.OfficialEndTime);

        }
    }
}
