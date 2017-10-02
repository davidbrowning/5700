using System.Collections.Generic;
using System.IO;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using RaceData;
using RaceData.Messages;

namespace RaceDataTesting
{
    [TestClass]
    public class SimulatedDataSourceTest
    {
        [TestMethod]
        public void SimluatedDataSource_Everything()
        {
            var fileWriter = new StreamWriter("SimulatedDataSourceTest.csv");
            fileWriter.WriteLine("Registered,1,8/15/2017 7:00:00 AM,FN_F_1,LN_1,F,16");
            fileWriter.WriteLine("Registered,2,8/15/2017 7:00:00 AM,FN_M_2,LN_2,M,56");
            fileWriter.WriteLine("---");
            fileWriter.WriteLine("Started,1,8/15/2017 7:02:00 AM,8/15/2017 7:02:00 AM");
            fileWriter.WriteLine("---");
            fileWriter.WriteLine("OnCourse,1,8/15/2017 7:02:30 AM,276.098203867211");
            fileWriter.WriteLine("Started,2,8/15/2017 7:02:30 AM,8/15/2017 7:02:30 AM");
            fileWriter.Close();

            var testHandler = new TestHandler();

            var ds = new SimulatedDataSource
            {
                InputFilename = "SimulatedDataSourceTest.csv",
                Handler = testHandler
            };

            ds.Start();

            // Wait for something about 1/2 second
            Thread.Sleep(500);

            // Two messages should have come in
            Assert.AreEqual(2, testHandler.NumberRecieved);
            Assert.AreEqual(AthleteRaceStatus.Registered, testHandler[0].UpdateType);
            Assert.AreEqual(AthleteRaceStatus.Registered, testHandler[1].UpdateType);

            // Wait for something less than a second
            Thread.Sleep(1000);

            // Another message should have some in
            Assert.AreEqual(3, testHandler.NumberRecieved);
            Assert.AreEqual(AthleteRaceStatus.Started, testHandler[2].UpdateType);

            // Wait for something less than a second
            Thread.Sleep(2000);

            // Another message should have some in
            Assert.AreEqual(5, testHandler.NumberRecieved);
            Assert.AreEqual(AthleteRaceStatus.OnCourse, testHandler[3].UpdateType);
            Assert.AreEqual(AthleteRaceStatus.Started, testHandler[4].UpdateType);

            ds.Stop();
            Thread.Sleep(1000);
            Assert.AreEqual(5, testHandler.NumberRecieved);

        }

        class TestHandler : IAthleteUpdateHandler
        {
            private readonly List<AthleteUpdate> _receivedMessages = new List<AthleteUpdate>();

            public void ProcessUpdate(AthleteUpdate updateMessage)
            {
                _receivedMessages.Add(updateMessage);
            }

            public int NumberRecieved => _receivedMessages.Count;

            public AthleteUpdate this[int index] => _receivedMessages[index];
        }

    }    
}
