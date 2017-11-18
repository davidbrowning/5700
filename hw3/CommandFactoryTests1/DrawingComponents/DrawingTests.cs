using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.DrawingComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.Tests
{
    [TestClass()]
    public class DrawingTests
    {
        [TestMethod()]
        public void GetCloneOfElementsTest()
        {
            var d = new Drawing();
            var cb = new ClassBox()
            {
                Label = "hi mom",
                Corner = new System.Drawing.Point(10, 10)
            };
            d.Add(cb);
            var ce = d.GetCloneOfElements();
            Assert.AreEqual(ce.Count,1);
        }

        [TestMethod()]
        public void ClearTest()
        {
            var d = new Drawing();
            var cb = new ClassBox() { Label = "hi mom"};
            d.Add(cb);
            d.Clear();
            var ce = d.GetCloneOfElements();
            Assert.AreEqual(ce.Count,0);
        }


        [TestMethod()]
        public void AddTest()
        {
            var d = new Drawing();
            var cb = new ClassBox()
            {
                Label = "hi mom",
                Corner = new System.Drawing.Point(10,10),
                Size = new System.Drawing.Size(20,20)
            };
            d.Add(cb);
            var p = d.FindElementAtPosition(new System.Drawing.Point(15, 15));
            Assert.AreEqual(p, cb);
        }

        [TestMethod()]
        public void DeleteAllSelectedTest()
        {
            var d = new Drawing();
            var cb = new ClassBox()
            {
                Label = "hi mom",
                Corner = new System.Drawing.Point(10,10),
                Size = new System.Drawing.Size(20,20)
            };
            cb.IsSelected = true;
            d.Add(cb);
            d.DeleteAllSelected();
            var p = d.FindElementAtPosition(new System.Drawing.Point(15, 15));
            Assert.AreEqual(p, null);
        }

        [TestMethod()]
        public void DeleteElementTest()
        {
            var d = new Drawing();
            var cb = new ClassBox()
            {
                Label = "hi mom",
                Corner = new System.Drawing.Point(10,10),
                Size = new System.Drawing.Size(20,20)
            };
            cb.IsSelected = true;
            d.Add(cb);
            d.DeleteElement(cb);
            var p = d.FindElementAtPosition(new System.Drawing.Point(15, 15));
            Assert.AreEqual(p, null);
        }

        [TestMethod()]
        public void FindElementAtPositionTest()
        {
            var d = new Drawing();
            var cb = new ClassBox()
            {
                Label = "hi mom",
                Corner = new System.Drawing.Point(10,10),
                Size = new System.Drawing.Size(20,20)
            };
            cb.IsSelected = true;
            d.Add(cb);
            var p = d.FindElementAtPosition(new System.Drawing.Point(15, 15));
            Assert.AreEqual(p, cb);
        }

        [TestMethod()]
        public void DeselectAllTest()
        {
            var d = new Drawing();
            var cb = new ClassBox()
            {
                Label = "hi mom",
                Corner = new System.Drawing.Point(10,10),
                Size = new System.Drawing.Size(20,20)
            };
            cb.IsSelected = true;
            d.Add(cb);
            d.DeselectAll();
            var p = d.FindElementAtPosition(new System.Drawing.Point(15, 15));
            Assert.AreEqual(p.IsSelected, false);
        }
    }
}