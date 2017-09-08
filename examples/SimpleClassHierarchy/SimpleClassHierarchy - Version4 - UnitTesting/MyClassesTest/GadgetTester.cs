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
        public void Gadget_ToString()
        {
            Gadget gadget = new Gadget() { Id = 1, Length = 10, Width = 5, Name = "First Gadget" };

            Assert.AreEqual("Gadget: Id=1, Name=First Gadget, width=5, length=10, cost=100", gadget.ToString());
        }
    }
}
