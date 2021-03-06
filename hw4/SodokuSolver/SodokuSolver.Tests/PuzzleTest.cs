// <copyright file="PuzzleTest.cs">Copyright ©  2017</copyright>
using System;
using System.Collections.Generic;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SodokuSolver;

namespace SodokuSolver.Tests
{
    /// <summary>This class contains parameterized unit tests for Puzzle</summary>
    [PexClass(typeof(Puzzle))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class PuzzleTest
    {
        /// <summary>Test stub for Block(Int32, Int32)</summary>
        [PexMethod]
        public bool BlockTest(
            [PexAssumeUnderTest]Puzzle target,
            int x,
            int y
        )
        {
            bool result = target.Block(x, y);
            return result;
            // TODO: add assertions to method PuzzleTest.BlockTest(Puzzle, Int32, Int32)
        }

        /// <summary>Test stub for Column(Int32)</summary>
        [PexMethod]
        public bool ColumnTest([PexAssumeUnderTest]Puzzle target, int offset)
        {
            bool result = target.Column(offset);
            return result;
            // TODO: add assertions to method PuzzleTest.ColumnTest(Puzzle, Int32)
        }

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public Puzzle ConstructorTest()
        {
            Puzzle target = new Puzzle();
            return target;
            // TODO: add assertions to method PuzzleTest.ConstructorTest()
        }

        /// <summary>Test stub for GetEmptyCellPossibilities(Tuple`2&lt;Int32,Int32&gt;)</summary>
        [PexMethod]
        public List<string> GetEmptyCellPossibilitiesTest([PexAssumeUnderTest]Puzzle target, Tuple<int, int> t)
        {
            List<string> result = target.GetEmptyCellPossibilities(t);
            return result;
            // TODO: add assertions to method PuzzleTest.GetEmptyCellPossibilitiesTest(Puzzle, Tuple`2<Int32,Int32>)
        }

        /// <summary>Test stub for GetEmptyCells()</summary>
        [PexMethod]
        public List<Tuple<int, int>> GetEmptyCellsTest([PexAssumeUnderTest]Puzzle target)
        {
            List<Tuple<int, int>> result = target.GetEmptyCells();
            return result;
            // TODO: add assertions to method PuzzleTest.GetEmptyCellsTest(Puzzle)
        }

        /// <summary>Test stub for Get_Block(Tuple`2&lt;Int32,Int32&gt;)</summary>
        [PexMethod]
        public Tuple<int, int> Get_BlockTest([PexAssumeUnderTest]Puzzle target, Tuple<int, int> t)
        {
            Tuple<int, int> result = target.Get_Block(t);
            return result;
            // TODO: add assertions to method PuzzleTest.Get_BlockTest(Puzzle, Tuple`2<Int32,Int32>)
        }

        /// <summary>Test stub for IsSolved()</summary>
        [PexMethod]
        public bool IsSolvedTest([PexAssumeUnderTest]Puzzle target)
        {
            bool result = target.IsSolved();
            return result;
            // TODO: add assertions to method PuzzleTest.IsSolvedTest(Puzzle)
        }

        /// <summary>Test stub for Row(Int32)</summary>
        [PexMethod]
        public bool RowTest([PexAssumeUnderTest]Puzzle target, int offset)
        {
            bool result = target.Row(offset);
            return result;
            // TODO: add assertions to method PuzzleTest.RowTest(Puzzle, Int32)
        }

        /// <summary>Test stub for ToString()</summary>
        [PexMethod]
        public string ToStringTest([PexAssumeUnderTest]Puzzle target)
        {
            string result = target.ToString();
            return result;
            // TODO: add assertions to method PuzzleTest.ToStringTest(Puzzle)
        }

        /// <summary>Test stub for in_block(Int32, Int32, String)</summary>
        [PexMethod]
        public bool in_blockTest(
            [PexAssumeUnderTest]Puzzle target,
            int row,
            int column,
            string symbol
        )
        {
            bool result = target.in_block(row, column, symbol);
            return result;
            // TODO: add assertions to method PuzzleTest.in_blockTest(Puzzle, Int32, Int32, String)
        }

        /// <summary>Test stub for in_col(Int32, String)</summary>
        [PexMethod]
        public bool in_colTest(
            [PexAssumeUnderTest]Puzzle target,
            int col_num,
            string symbol
        )
        {
            bool result = target.in_col(col_num, symbol);
            return result;
            // TODO: add assertions to method PuzzleTest.in_colTest(Puzzle, Int32, String)
        }

        /// <summary>Test stub for in_row(Int32, String)</summary>
        [PexMethod]
        public bool in_rowTest(
            [PexAssumeUnderTest]Puzzle target,
            int row_num,
            string symbol
        )
        {
            bool result = target.in_row(row_num, symbol);
            return result;
            // TODO: add assertions to method PuzzleTest.in_rowTest(Puzzle, Int32, String)
        }
    }
}
