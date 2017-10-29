using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer;
using RaceData;
using RaceData.Messages;

namespace UnitTestProject1
{
    [TestClass]
    public class ObservedAthletesTest
    {
        [TestMethod]
        public void SingletonTest()
        {
            //Test Singleton capability
            AthleteUpdate au = new RegistrationUpdate
            {
            FirstName = "Bob",
            LastName = "Brown",
            BibNumber = 2
            };
            Athlete a = new Athlete(au as RegistrationUpdate);
            AppLayer.ObservedAthletes.GetInstance().AddAthlete(a);
            var list = AppLayer.ObservedAthletes.GetInstance().GetList();
            var list2 = AppLayer.ObservedAthletes.GetInstance().GetList();
            Assert.AreEqual(list[0], list2[0]);
            return;
        }
    }
}
