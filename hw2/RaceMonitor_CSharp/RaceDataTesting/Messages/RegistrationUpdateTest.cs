using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RaceData;
using RaceData.Messages;

namespace RaceDataTesting.Messages
{
    [TestClass]
    public class RegistrationUpdateTest
    {
        [TestMethod]
        public void RegistrationUpdate_Create()
        {
            RegistrationUpdate rUpdate = (RegistrationUpdate)AthleteUpdate.Create("Registered,14,8/15/2017 7:02:05 AM,Jane,Jones,F,16");
            Assert.IsNotNull(rUpdate);

            Assert.AreEqual(AthleteRaceStatus.Registered, rUpdate.UpdateType);
            Assert.AreEqual(14, rUpdate.BibNumber);
            Assert.AreEqual(new DateTime(2017, 8, 15, 7, 2, 5), rUpdate.Timestamp);
            Assert.AreEqual("Jane", rUpdate.FirstName);
            Assert.AreEqual("Jones", rUpdate.LastName);
            Assert.AreEqual("F", rUpdate.Gender);
            Assert.AreEqual(16, rUpdate.Age);

            try
            {
                var msg = AthleteUpdate.Create("Registered,14,8/15/2017 7:02:05 AM,Jane,Jones,F");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("Registered,14,8/15/2017 7:02:05 AM,Jane,Jones");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("Registered,14,8/15/2017 7:02:05 AM,Jane");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("Registered,14,8/15/2017 7:02:05 AM");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("Registered,14");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("Registered");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("Registered,14,8/15/2017 7:02:05 AM,Jane,Jones,F,16,bad");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

        }

        [TestMethod]
        public void RegistrationUpdate_ToString()
        {
            RegistrationUpdate rUpdate = new RegistrationUpdate
            {
                BibNumber = 14,
                Timestamp = new DateTime(2017, 8, 15, 7, 2, 5),
                FirstName = "Jane",
                LastName = "Jones",
                Gender = "F",
                Age = 16
            };

            Assert.AreEqual("Registered,14,8/15/2017 7:02:05 AM,Jane,Jones,F,16", rUpdate.ToString());
        }


        [TestMethod]
        public void RegistrationUpdate_GetterAndSetters()
        {
            RegistrationUpdate rUpdate = new RegistrationUpdate
            {
                BibNumber = 14,
                Timestamp = new DateTime(2017, 8, 15, 7, 2, 5),
                FirstName = "Jane",
                LastName = "Jones",
                Gender = "F",
                Age = 16
            };

            Assert.AreEqual(AthleteRaceStatus.Registered, rUpdate.UpdateType);
            Assert.AreEqual(14, rUpdate.BibNumber);
            Assert.AreEqual(new DateTime(2017, 8, 15, 7, 2, 5), rUpdate.Timestamp);
            Assert.AreEqual("Jane", rUpdate.FirstName);
            Assert.AreEqual("Jones", rUpdate.LastName);
            Assert.AreEqual("F", rUpdate.Gender);
            Assert.AreEqual(16, rUpdate.Age);

        }
    }
}
