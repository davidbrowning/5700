using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RaceData;
using RaceData.Messages;

namespace RaceDataTesting.Messages
{
    [TestClass]
    public class LocationUpdateTest
    {
        [TestMethod]
        public void LocationUpdate_Create()
        {
            var locationUpdate = (LocationUpdate)AthleteUpdate.Create("OnCourse,47,8/15/2017 10:26:00 AM,680.067495971265");
            Assert.IsNotNull(locationUpdate);

            Assert.AreEqual(AthleteRaceStatus.OnCourse, locationUpdate.UpdateType);
            Assert.AreEqual(47, locationUpdate.BibNumber);
            Assert.AreEqual(new DateTime(2017, 8, 15, 10, 26, 0), locationUpdate.Timestamp);
            Assert.AreEqual(680.067495971265, locationUpdate.LocationOnCourse, 0.0001);

            try
            {
                var msg = AthleteUpdate.Create("OnCourse,47,8/15/2017 10:26:00 AM");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("OnCourse,47");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("OnCourse");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }

            try
            {
                var msg = AthleteUpdate.Create("OnCourse,47,8/15/2017 10:26:00 AM,680.067495971265,bad");
                Assert.Fail($"Exception expected when creating: msg={msg}");
            }
            catch { /* ignore */ }
        }

        [TestMethod]
        public void LocationUpdate_ToString()
        {
            var locationUpdate = new LocationUpdate
            {
                BibNumber = 47,
                Timestamp = new DateTime(2017, 8, 15, 10, 26, 0),
                LocationOnCourse = 680.067495971265
            };

            Assert.AreEqual("OnCourse,47,8/15/2017 10:26:00 AM,680.067495971265", locationUpdate.ToString());
        }


        [TestMethod]
        public void LocationUpdate_GetterAndSetters()
        {
            var locationUpdate = new LocationUpdate
            {
                BibNumber = 47,
                Timestamp = new DateTime(2017, 8, 15, 10, 26, 0),
                LocationOnCourse = 680.067495971265
            };

            Assert.AreEqual(AthleteRaceStatus.OnCourse, locationUpdate.UpdateType);
            Assert.AreEqual(47, locationUpdate.BibNumber);
            Assert.AreEqual(new DateTime(2017, 8, 15, 10, 26, 0), locationUpdate.Timestamp);
            Assert.AreEqual(680.067495971265, locationUpdate.LocationOnCourse, 0.0001);
        }
    }
}
