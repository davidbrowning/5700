using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RaceData;
using RaceData.Messages;

namespace RaceDataTesting.Messages
{
    [TestClass]
    public class DidNotStartUpdateTest
    {
        [TestMethod]
        public void DidNotStartUpdate_Create()
        {
            var dnsUpdate = (DidNotStartUpdate)AthleteUpdate.Create("DidNotStart,35,8/15/2017 8:51:00 AM");

            Assert.AreEqual(AthleteRaceStatus.DidNotStart, dnsUpdate.UpdateType);
            Assert.AreEqual(35, dnsUpdate.BibNumber);
            Assert.AreEqual(new DateTime(2017, 8, 15, 8, 51, 0), dnsUpdate.Timestamp);

            try
            {
                var msg = AthleteUpdate.Create("DidNotStart,35");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("DidNotStart");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("DidNotStart,35,bad,8/15/2017 8:51:00 AM");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }
        }

        [TestMethod]
        public void DidNotStartUpdate_ToString()
        {
            DidNotStartUpdate dnsUpdate = new DidNotStartUpdate
            {
                BibNumber = 35,
                Timestamp = new DateTime(2017, 8, 15, 8, 51, 0)
            };

            Assert.AreEqual("DidNotStart,35,8/15/2017 8:51:00 AM", dnsUpdate.ToString());
        }


        [TestMethod]
        public void DidNotStartUpdate_GetterAndSetters()
        {
            DidNotStartUpdate dnsUpdate = new DidNotStartUpdate
            {
                BibNumber = 35,
                Timestamp = new DateTime(2017, 8, 15, 8, 51, 0)
            };

            Assert.AreEqual(AthleteRaceStatus.DidNotStart, dnsUpdate.UpdateType);
            Assert.AreEqual(35, dnsUpdate.BibNumber);
            Assert.AreEqual(new DateTime(2017, 8, 15, 8, 51, 0), dnsUpdate.Timestamp);
        }
    }    
}
