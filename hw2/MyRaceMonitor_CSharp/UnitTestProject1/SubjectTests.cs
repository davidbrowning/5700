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
    public class SubjectTests
    {
        [TestMethod]
        public void SubscribeTest()
        {
            Subject s = new Subject();
            AthleteObserver athleteObserver = new AthleteObserver();
            s.Subscribe(athleteObserver);
            Assert.AreEqual(s.Subscribers.Contains(athleteObserver), true);
        }
        [TestMethod]
        public void UnsubscribeTest()
        {
            Subject s = new Subject();
            AthleteObserver athleteObserver = new AthleteObserver();
            s.Subscribe(athleteObserver);
            s.Unsubscribe(athleteObserver);
            Assert.AreEqual(s.Subscribers.Contains(athleteObserver), false);
        }

        [TestMethod]
        public void NotifyTest()
        {
            Subject s = new Subject();
            AthleteObserver athleteObserver = new AthleteObserver();
            s.Subscribe(athleteObserver);
            s.Notify();
        }
    }
}