using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceData
{
    public class IRaceDataSource
    {
        public string InputFilename { get; set; }
        public IAthleteUpdateHandler Handler { get; set; }
        public int SleepTimeForSimulatedSecond { get; set; } = 1000;

        public void Start() { }

        public void Stop() { }
    }
}
