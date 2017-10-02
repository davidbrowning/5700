using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PersonClassLibrary;

namespace UnitTestProject1
{
    [TestClass]
    public class SimpleBirthMatcher_Test
    {
        [TestMethod]
        public void TestBirthMatch()
        {
            Person a = new Person { BirthDay = 12, BirthMonth = 12, BirthYear = 1945 };
            Person b = new Person { BirthDay = 12, BirthMonth = 12, BirthYear = 1945 };
            Person c = new Person { BirthDay = 10, BirthMonth = 12, BirthYear = 1945 };
            Person d = new Person { BirthDay = 12, BirthMonth = 10, BirthYear = 1945 };
            Person e = new Person { BirthDay = 12, BirthMonth = 12, BirthYear = 1944 };

            SimpleBirthMatcher bm = new SimpleBirthMatcher();

            PersonPair p = new PersonPair(a, b);

            Assert.AreEqual(true, bm.IsMatchedPair(p));
            p = new PersonPair(a, c);
            Assert.AreNotEqual(true, bm.IsMatchedPair(p));
            p = new PersonPair(a, d);
            Assert.AreNotEqual(true, bm.IsMatchedPair(p));
            p = new PersonPair(a, e);
            Assert.AreNotEqual(true, bm.IsMatchedPair(p));
        }

    }
}
