using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodokuSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SodokuSolver.Tests
{
    [TestClass()]
    public class PuzzleTests
    {
        [TestMethod()]
        public void GetEmptyCellsTest()
        {
            Puzzle p = new Puzzle();
            PlainText plt = new PlainText();
            plt.Read(p, "D:/School/CS/5700/cs5700f17-shared/hw4/SamplePuzzles/Input/Puzzle-4x4-0002.txt");
            var ec = p.GetEmptyCells();
            Assert.AreEqual(ec.Contains(new Tuple<int, int>(0, 1)),true);
            Assert.AreEqual(ec.Contains(new Tuple<int, int>(1, 2)),true);
            Assert.AreEqual(ec.Contains(new Tuple<int, int>(2, 3)),true);
            Assert.AreEqual(ec.Contains(new Tuple<int, int>(3, 0)),true);
        }

        [TestMethod()]
        public void in_rowTest()
        {
            Puzzle p = new Puzzle();
            PlainText plt = new PlainText();
            plt.Read(p, "D:/School/CS/5700/cs5700f17-shared/hw4/SamplePuzzles/Input/Puzzle-4x4-0002.txt");
            Assert.AreEqual(p.in_row(0, "B"),true);
            Assert.AreEqual(p.in_row(0, "C"),true);
            Assert.AreEqual(p.in_row(0, "A"),true);
        }

        [TestMethod()]
        public void in_colTest()
        {
            Puzzle p = new Puzzle();
            PlainText plt = new PlainText();
            plt.Read(p, "D:/School/CS/5700/cs5700f17-shared/hw4/SamplePuzzles/Input/Puzzle-4x4-0002.txt");
            Assert.AreEqual(p.in_col(0, "B"), true);
            Assert.AreEqual(p.in_col(0, "A"), true);
            Assert.AreEqual(p.in_col(0, "C"), true);
        }

        [TestMethod()]
        public void in_blockTest()
        {
            Puzzle p = new Puzzle();
            PlainText plt = new PlainText();
            plt.Read(p, "D:/School/CS/5700/cs5700f17-shared/hw4/SamplePuzzles/Input/Puzzle-4x4-0002.txt");
            Assert.AreEqual(p.in_block(0, 0, "A"), true);
            Assert.AreEqual(p.in_block(0, 0, "B"), true);
        }

        [TestMethod()]
        public void Get_BlockTest()
        {
            Puzzle p = new Puzzle();
            PlainText plt = new PlainText();
            plt.Read(p, "D:/School/CS/5700/cs5700f17-shared/hw4/SamplePuzzles/Input/Puzzle-4x4-0002.txt");
            var block = p.Get_Block(new Tuple<int, int>(0, 1));
            Assert.AreEqual(new Tuple<int, int>(0, 0), block);
            var block2 = p.Get_Block(new Tuple<int, int>(2, 3));
            Assert.AreEqual(new Tuple<int, int>(2, 2), block2);
            var block3 = p.Get_Block(new Tuple<int, int>(0, 3));
            Assert.AreEqual(new Tuple<int, int>(0, 2), block3);
            var block4 = p.Get_Block(new Tuple<int, int>(3, 0));
            Assert.AreEqual(new Tuple<int, int>(2, 0), block4);
        }

        [TestMethod()]
        public void GetEmptyCellPossibilitiesTest()
        {
            Puzzle p = new Puzzle();
            PlainText plt = new PlainText();
            plt.Read(p, "D:/School/CS/5700/cs5700f17-shared/hw4/SamplePuzzles/Input/Puzzle-4x4-0101.txt");
            var l = p.GetEmptyCellPossibilities(new Tuple<int, int>(0, 1));
            Assert.AreEqual(l.Contains("3"), true);
            Assert.AreEqual(l.Contains("4"), true);
            Assert.AreEqual(l.Count == 2, true);
        }

        [TestMethod()]
        public void ColumnTest()
        {
            Puzzle p = new Puzzle();
            PlainText plt = new PlainText();
            plt.Read(p, "D:/School/CS/5700/cs5700f17-shared/hw4/SamplePuzzles/Input/Puzzle-4x4-0101.txt");
            Assert.AreEqual(p.Column(0), false);
        }

        [TestMethod()]
        public void RowTest()
        {
            Puzzle p = new Puzzle();
            PlainText plt = new PlainText();
            plt.Read(p, "D:/School/CS/5700/cs5700f17-shared/hw4/SamplePuzzles/Input/Puzzle-4x4-0101.txt");
            Assert.AreEqual(p.Row(0), false);
        }

        [TestMethod()]
        public void BlockTest()
        {
            Puzzle p = new Puzzle();
            PlainText plt = new PlainText();
            plt.Read(p, "D:/School/CS/5700/cs5700f17-shared/hw4/SamplePuzzles/Input/Puzzle-4x4-0101.txt");
            Assert.AreEqual(p.Block(0, 0), false);
        }

        [TestMethod()]
        public void IsSolvedTest()
        {
            Puzzle p = new Puzzle();
            PlainText plt = new PlainText();
            plt.Read(p, "D:/School/CS/5700/cs5700f17-shared/hw4/SamplePuzzles/Input/Puzzle-4x4-0101.txt");
            Assert.AreEqual(p.IsSolved(), false);
        }
    }
}