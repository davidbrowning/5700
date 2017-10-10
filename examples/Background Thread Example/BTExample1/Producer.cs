using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Common;

namespace BTExample1
{
    class Producer : BackgroundThread
    {
        private Random randomizer = new Random();

        public MonitoredQueue OutputQueue { get; set; }
        public int SimulatedWorkTime { get; set; }

        public Producer(MonitoredQueue outputQueue, int simulatedWorkTime)
        {
            OutputQueue = outputQueue;
            SimulatedWorkTime = simulatedWorkTime;
        }

        public override string ThreadName()
        {
            return "Producer";
        }

        protected override void Process()
        {
            while (keepGoing)
            {
                // If not suspended do work
                if (!Suspended)
                {
                    // Goto Sleep for the simulated work time
                    int workTime = randomizer.Next(Math.Max(0, SimulatedWorkTime - 10), SimulatedWorkTime + 10);
                    Thread.Sleep(workTime);

                    Widget widget = new Widget();
                    widget.WidgetWidth = randomizer.Next(10, 20);
                    widget.WidgetHeight = randomizer.Next(10, 20);
                    widget.WidgetDepth = randomizer.Next(10, 20);
                    OutputQueue.Enqueue(widget);
                }
            }
        }
    }
}
