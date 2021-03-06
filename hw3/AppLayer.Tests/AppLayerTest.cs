// <copyright file="AppLayerTest.cs">Copyright ©  2016</copyright>
using System;
using AppLayer.Command;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppLayer.Tests
{
    /// <summary>This class contains parameterized unit tests for Invoker</summary>
    [PexClass(typeof(Invoker))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class AppLayerTest
    {
        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public Invoker InvokerTest()
        {
            Invoker target = new Invoker();
            return target;
            // TODO: add assertions to method AppLayerTest.InvokerTest()
        }

        /// <summary>Test stub for EnqueueCommandForExecution(Command)</summary>
        [PexMethod]
        public void InvokerTest01([PexAssumeUnderTest]Invoker target, global::AppLayer.Command.Command cmd)
        {
            bool success = target.EnqueueCommandForExecution(cmd);
            if(cmd == null)
            {
                Assert.AreEqual(success, false);
            }
            else
            {
                Assert.AreEqual(success, true);
            }
        }

        /// <summary>Test stub for Redo()</summary>
        [PexMethod]
        public void InvokerTest02([PexAssumeUnderTest]Invoker target)
        {
            target.Redo();
            // TODO: add assertions to method AppLayerTest.InvokerTest02(Invoker)
        }

        /// <summary>Test stub for Start()</summary>
        [PexMethod]
        public void InvokerTest03([PexAssumeUnderTest]Invoker target)
        {
            target.Start();
            // TODO: add assertions to method AppLayerTest.InvokerTest03(Invoker)
        }

        /// <summary>Test stub for Stop()</summary>
        [PexMethod]
        public void InvokerTest04([PexAssumeUnderTest]Invoker target)
        {
            target.Stop();
            // TODO: add assertions to method AppLayerTest.InvokerTest04(Invoker)
        }

        /// <summary>Test stub for Undo()</summary>
        [PexMethod]
        public void InvokerTest05([PexAssumeUnderTest]Invoker target)
        {
            target.Undo();
            // TODO: add assertions to method AppLayerTest.InvokerTest05(Invoker)
        }
    }
}
