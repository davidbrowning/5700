using System;
using System.IO;
using System.Threading;

using RaceData.Messages;

namespace RaceData
{
    public class SimluatedDataSource : IRaceDataSource
    {
        private StreamReader _reader;
        private Thread _myThread;
        private bool _keepGoing;

        public string InputFilename { get; set; }
        public IAthleteUpdateHandler Handler { get; set; }
        public int SleepTimeForSimulatedSecond { get; set; } = 1000;

        public void Start()
        {
            if (string.IsNullOrWhiteSpace(InputFilename))
                throw new ApplicationException("Before starting a SimulatedDataSource, you must set InputFilename to path of the race data");

            if (Handler==null)
                throw new ApplicationException("You must set Handler to an object in your software that can process AthleteUpdate messages before starting a simulation");

            _reader = new StreamReader(InputFilename);
            _myThread = new Thread(Run);
            _keepGoing = true;
            _myThread.Start();
        }

        public void Stop()
        {
            _keepGoing = false;
        }

        private void Run()
        {
            while (_keepGoing && !_reader.EndOfStream)
            {
                SimulateOneSecondOfData();
                Thread.Sleep(SleepTimeForSimulatedSecond);
            }
        }

        private void SimulateOneSecondOfData()
        {
            string line = _reader.ReadLine();
            while (line != "---" && !_reader.EndOfStream)
            {
                var message = AthleteUpdate.Create(line);
                Handler.ProcessUpdate(message);
                line = _reader.ReadLine();
            }
        }
    }
}
