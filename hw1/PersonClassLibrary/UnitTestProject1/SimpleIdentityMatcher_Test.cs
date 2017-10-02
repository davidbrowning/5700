using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonClassLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class SimpleIdentityMatcher_Test
    {
        [TestMethod]
        public void TestIdentityMatch()
        {
            Person a = new Person { SocialSecurityNumber = "000-01-1234", StateFileNumber = "0001234" };
            Person b = new Person { SocialSecurityNumber = "000-01-1234", StateFileNumber = "0001234" };
            Person c = new Person { SocialSecurityNumber = "000-01-4321", StateFileNumber = "0004321" };
            Person d = new Person { SocialSecurityNumber = "000-01-1234", StateFileNumber = "0004321" };

            SimpleIdentityMatcher bm = new SimpleIdentityMatcher();

            PersonPair p = new PersonPair(a, b);
            Assert.AreEqual(true, bm.IsMatchedPair(p));
            p = new PersonPair(a, c);
            Assert.AreNotEqual(true, bm.IsMatchedPair(p));
            p = new PersonPair(a, d);
            Assert.AreEqual(true, bm.IsMatchedPair(p));
        }
    }
}
