using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Tests
{
    [TestClass()]
    public class AthleteTests
    {
        [TestMethod()]
        public void AthleteTest()
        {
            AthleteUpdate au = new RegistrationUpdate
            {
            FirstName = "Bob",
            LastName = "Brown",
            BibNumber = 2
            };
            Athlete a = new Athlete(au as RegistrationUpdate);
            ObservedAthletes.GetInstance().AddAthlete(a);
            var list = ObservedAthletes.GetInstance().GetList();
            var list2 = ObservedAthletes.GetInstance().GetList();
            Assert.AreEqual(list[0], list2[0]);
            return;
            Assert.Fail();
        }
    }
}