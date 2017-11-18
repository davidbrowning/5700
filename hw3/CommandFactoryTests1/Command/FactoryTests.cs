using Microsoft.VisualStudio.TestTools.UnitTesting;
using AppLayer.Command;
using System.Threading;
using AppLayer.DrawingComponents;
using System.Drawing;
using System;

namespace AppLayer.Tests
{
    [TestClass()]
    public class CommandFactoryTests
    {
        public Invoker I = new Invoker();
        public CommandFactory CF = CommandFactory.Instance;
        public Point p = new Point(10, 10);
        public Point q = new Point(100, 100);
        public Drawing d = new Drawing();
        public Drawing x = new Drawing();
        
        [TestMethod()]
        public void CreateAndDoTest()
        {
            CF.Invoker = I;
            CF.TargetDrawing = d;
            CF.CreateAndDo("ADDBOX","hi",p,new Size(q));
            new Thread(() =>
           {
               Thread.CurrentThread.IsBackground = true;
               I.Start();
           }).Start();
            Thread.Sleep(1000);
            I.Stop();
            Assert.AreNotEqual(d, x); 
        }
        public TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        [TestMethod()]
        public void CreateAndDoTestNew()
        {
            CF.Invoker = I;
            CF.TargetDrawing = d;
            CF.CreateAndDo("ADDBOX","hi",p,new Size(q));
            CF.CreateAndDo("NEW");
            new Thread(() =>
           {
               Thread.CurrentThread.IsBackground = true;
               I.Start();
           }).Start();
            Thread.Sleep(1000);
            I.Stop();
            Assert.AreEqual(d, CF.TargetDrawing); 

        }
        [TestMethod()]
        public void CreateAndDoTestGetElement()
        {
            CF.Invoker = I;
            CF.TargetDrawing = d;
            CF.CreateAndDo("ADDBOX","hi",p,new Size(q));
            new Thread(() =>
           {
               Thread.CurrentThread.IsBackground = true;
               I.Start();
           }).Start();
            Thread.Sleep(1000);
            I.Stop();
            //Assert.AreEqual(d, CF.TargetDrawing); 
            var r = (ClassBox)d.FindElementAtPosition(new Point(50, 50));
            var r2 = new ClassBox
            {
                Corner = (Point) p,
                Size = (Size) q,
                Label = "hi" 
            };           
            Assert.AreEqual(r.Size, r2.Size);
            Assert.AreEqual(r.Label, r2.Label);
            Assert.AreEqual(r.Corner, r2.Corner);
            
        }
        [TestMethod()]
        public void CreateAndDoTestElementClone()
        {
            CF.Invoker = I;
            d = new Drawing();
            CF.TargetDrawing = d;
            CF.CreateAndDo("ADDBOX","hi",p,new Size(q));
            CF.CreateAndDo("ADDBOX","hi",p,new Size(q));
            new Thread(() =>
           {
               Thread.CurrentThread.IsBackground = true;
               I.Start();
           }).Start();
            Thread.Sleep(1000);
            I.Stop();
            var r = d.GetCloneOfElements();
            Assert.AreEqual(r.Count, 2);
        }
        [TestMethod()]
        public void CreateAndDoTestSelect()
        {
            CF.Invoker = I;
            d = new Drawing();
            CF.TargetDrawing = d;
            CF.CreateAndDo("ADDBOX","hi",p,new Size(q));
            var sp = new Point(p.X + 10, p.Y + 10);
            CF.CreateAndDo("SELECT", sp);
            new Thread(() =>
           {
               Thread.CurrentThread.IsBackground = true;
               I.Start();
           }).Start();
            Thread.Sleep(1000);
            I.Stop();
            var cl = d.GetCloneOfElements();
            Assert.AreEqual(d.FindElementAtPosition(sp).IsSelected, true);

        }
        [TestMethod()]
        public void CreateAndDoTestSelectUndo()
        {
            CF.Invoker = I;
            d = new Drawing();
            CF.TargetDrawing = d;
            CF.CreateAndDo("ADDBOX","hi",p,new Size(q));
            var sp = new Point(p.X + 10, p.Y + 10);
            CF.CreateAndDo("SELECT", sp);
            new Thread(() =>
           {
               Thread.CurrentThread.IsBackground = true;
               I.Start();
           }).Start();
            Thread.Sleep(1000);
            var cl = d.GetCloneOfElements();
            Assert.AreEqual(d.FindElementAtPosition(sp).IsSelected, true);
            I.Undo();
            Thread.Sleep(1000);
            I.Stop();
            var c2 = d.GetCloneOfElements();
            Assert.AreNotEqual(d.FindElementAtPosition(sp).IsSelected, true);

        }
        [TestMethod()]
        public void CreateAndDoTestSelectUndoRedo()
        {
            CF.Invoker = I;
            d = new Drawing();
            CF.TargetDrawing = d;
            CF.CreateAndDo("ADDBOX","hi",p,new Size(q));
            var sp = new Point(p.X + 10, p.Y + 10);
            CF.CreateAndDo("SELECT", sp);
            new Thread(() =>
           {
               Thread.CurrentThread.IsBackground = true;
               I.Start();
           }).Start();
            Thread.Sleep(1000);
            var cl = d.GetCloneOfElements();
            Assert.AreEqual(d.FindElementAtPosition(sp).IsSelected, true);
            I.Undo();
            Thread.Sleep(1000);
            var c2 = d.GetCloneOfElements();
            Assert.AreNotEqual(d.FindElementAtPosition(sp).IsSelected, true);
            I.Redo();
            Thread.Sleep(1000);
            var c3 = d.GetCloneOfElements();
            Assert.AreEqual(d.FindElementAtPosition(sp).IsSelected, true);
            I.Stop();

        }
        [TestMethod()]
        public void RelationshipFactoryTestA()
        {
            var rf = RelationshipFactory.Instance;
            rf.ResourceNamePattern = @"{0}";
            var res = new RelationshipExtrinsicState();
            res.RelationshipType = "aggregation";
            var r = rf.GetRelationship(res);
            string resourceName = string.Format(rf.ResourceNamePattern, res.RelationshipType);
            Assert.AreEqual(resourceName, "aggregation");
        }
        [TestMethod()]
        public void RelationshipFactoryTestI()
        {
            var rf = RelationshipFactory.Instance;
            rf.ResourceNamePattern = @"{0}";
            var res = new RelationshipExtrinsicState();
            res.RelationshipType = "inheritance";
            var r = rf.GetRelationship(res);
            string resourceName = string.Format(rf.ResourceNamePattern, res.RelationshipType);
            Assert.AreEqual(resourceName, "inheritance");
        }
        [TestMethod()]
        public void RelationshipFactoryTestD()
        {
            var rf = RelationshipFactory.Instance;
            rf.ResourceNamePattern = @"{0}";
            var res = new RelationshipExtrinsicState();
            res.RelationshipType = "dependancy";
            var r = rf.GetRelationship(res);
            string resourceName = string.Format(rf.ResourceNamePattern, res.RelationshipType);
            Assert.AreEqual(resourceName, "dependancy");
        }
        [TestMethod()]
        public void RelationshipFactoryTestC()
        {
            var rf = RelationshipFactory.Instance;
            rf.ResourceNamePattern = @"{0}";
            var res = new RelationshipExtrinsicState();
            res.RelationshipType = "composition";
            var r = rf.GetRelationship(res);
            string resourceName = string.Format(rf.ResourceNamePattern, res.RelationshipType);
            Assert.AreEqual(resourceName, "composition");
        }
    }
}