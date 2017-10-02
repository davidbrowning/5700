using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonClassLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class SimpleNameMatcher_Test
    {
        [TestMethod]
        public void TestNameMatch()
        {
            Person a = new Person { FirstName = "Bob", MiddleName = "Trent", LastName = "Johnson" };
            Person b = new Person { FirstName = "Bob", MiddleName = "Trent", LastName = "Johnson" };
            Person c = new Person { FirstName = "Rob", MiddleName = "Trent", LastName = "Johnson" };
            Person d = new Person { FirstName = "Bob", MiddleName = "Trey", LastName = "Johnson" };
            Person e = new Person { FirstName = "Bob", MiddleName = "Trent", LastName = "Johnsen" };

            SimpleNameMatcher bm = new SimpleNameMatcher();

            PersonPair p = new PersonPair(a, b);
            Assert.AreEqual(true, bm.IsMatchedPair(p));
            p = new PersonPair(a, c);
            Assert.AreNotEqual(true, bm.IsMatchedPair(p));
            p = new PersonPair(a, d);
            Assert.AreNotEqual(false, bm.IsMatchedPair(p));
            p = new PersonPair(a, e);
            Assert.AreNotEqual(true, bm.IsMatchedPair(p));
        }
    }
}
