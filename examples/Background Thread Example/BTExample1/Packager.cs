using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Common;

namespace BTExample1
{
    class Packager : BackgroundThread
    {
        private Random randomizer = new Random();

        public MonitoredQueue InputQueue { get; set; }
        public MonitoredQueue OutputQueue { get; set; }
        public int SimulatedWorkTime { get; set; }

        public Packager(MonitoredQueue inputQueue, MonitoredQueue outputQueue, int simulatedWorkTime)
        {
            InputQueue = inputQueue;
            OutputQueue = outputQueue;
            SimulatedWorkTime = simulatedWorkTime;
        }

        public override string ThreadName()
        {
            return "Packager";
        }

        protected override void Process()
        {
            while (keepGoing)
            {
                while (keepGoing && !Suspended)
                {
                    // Goto Sleep for the simulated work time
                    int workTime = randomizer.Next(Math.Max(0, SimulatedWorkTime - 10), SimulatedWorkTime + 10);
                    Thread.Sleep(workTime);

                    Widget widget = InputQueue.Dequeue();
                    if (widget != null)
                    {
                        widget.IsPackaged = true;
                        OutputQueue.Enqueue(widget);
                    }
                    else
                        break;
                }

                // Wait for something to be placed into the input queue or 1 second
                InputQueue.StateChanged.WaitOne(1000);
            }
        }

    }
}
