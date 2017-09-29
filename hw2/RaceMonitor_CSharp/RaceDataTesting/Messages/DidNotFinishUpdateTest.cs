using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RaceData;
using RaceData.Messages;

namespace RaceDataTesting.Messages
{
    [TestClass]
    public class DidNotFinishUpdateTest
    {
        [TestMethod]
        public void DidNotFinishUpdate_Create()
        {
            var dnfUpdate = (DidNotFinishUpdate)AthleteUpdate.Create("DidNotFinish,45,8/15/2017 10:52:00 AM");
            Assert.IsNotNull(dnfUpdate);

            Assert.AreEqual(AthleteRaceStatus.DidNotFinish, dnfUpdate.UpdateType);
            Assert.AreEqual(45, dnfUpdate.BibNumber);
            Assert.AreEqual(new DateTime(2017, 8, 15, 10, 52, 0), dnfUpdate.Timestamp);

            try
            {
                var msg = AthleteUpdate.Create("DidNotFinish,45");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("DidNotFinish");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("DidNotFinish,45,bad,8/15/2017 10:52:00 AM");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }
        }

        [TestMethod]
        public void DidNotFinishUpdate_ToString()
        {
            var dnfUpdate = new DidNotFinishUpdate
            {
                BibNumber = 45,
                Timestamp = new DateTime(2017, 8, 15, 10, 52, 0)
            };
            Assert.AreEqual("DidNotFinish,45,8/15/2017 10:52:00 AM", dnfUpdate.ToString());
        }


        [TestMethod]
        public void DidNotFinishUpdate_GetterAndSetters()
        {
            DidNotFinishUpdate dnfUpdate = new DidNotFinishUpdate
            {
                BibNumber = 45,
                Timestamp = new DateTime(2017, 8, 15, 10, 52, 0)
            };

            Assert.AreEqual(AthleteRaceStatus.DidNotFinish, dnfUpdate.UpdateType);
            Assert.AreEqual(45, dnfUpdate.BibNumber);
            Assert.AreEqual(new DateTime(2017, 8, 15, 10, 52, 0), dnfUpdate.Timestamp);

        }
    }
}
