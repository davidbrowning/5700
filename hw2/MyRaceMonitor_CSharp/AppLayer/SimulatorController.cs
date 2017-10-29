
using System.Threading;
using RaceData;

namespace AppLayer
{
    public class SimulatorController
    {
        private SimulatedDataSource _simluatedData;
        public void Run(string inputFileName)
        {
            IAthleteUpdateHandler handler = new DataProcessor();
            _simluatedData = new SimulatedDataSource()
            {
                InputFilename = inputFileName,
                Handler = handler
            };

            // To speed up testing
            _simluatedData.SleepTimeForSimulatedSecond = 200;
            _simluatedData.Start();

            // Let the simulator run for 3 minutes
            Thread.Sleep(180000);

            _simluatedData.Stop();
        }
    }
}
