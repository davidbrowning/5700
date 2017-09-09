using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using MyClasses;

namespace MyClassesTest
{
    [TestClass]
    public class GadgetTester
    {
        [TestMethod]
        public void Gadget_TestCostProperty()
        {
            Gadget gadget = new Gadget() {Id = 1, Length = 10, Width = 5, Name = "First Gadget"};

            Assert.AreEqual(100, gadget.Cost);
        }

        [TestMethod]
        public void Gadget_Typical_ToString()
        {
            Gadget gadget = new Gadget() { Id = 1, Length = 10, Width = 5, Name = "First Gadget" };

            Assert.AreEqual("Gadget: Id=1, Name=First Gadget, width=5, length=10, cost=100", gadget.ToString());
        }

        [TestMethod]
        public void Gadget_WithNoName_ToString()
        {
            Gadget gadget = new Gadget() { Id = 1, Length = 10, Width = 5 };

            Assert.AreEqual("Gadget: Id=1, Name=, width=5, length=10, cost=100", gadget.ToString());
        }

        [TestMethod]
        public void Gadget_NoLengthOrWidth_ToString()
        {
            Gadget gadget = new Gadget() { Id = 1, Name = "First Gadget" };

            Assert.AreEqual("Gadget: Id=1, Name=First Gadget, width=0, length=0, cost=0", gadget.ToString());
        }

        [TestMethod]
        public void Gadget_NoId_ToString()
        {
            Gadget gadget = new Gadget() { Length = 10, Width = 5, Name = "First Gadget" };

            Assert.AreEqual("Gadget: Id=0, Name=First Gadget, width=5, length=10, cost=100", gadget.ToString());
        }
    }
}
