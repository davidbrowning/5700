using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Common;

namespace BTExample1
{
    public class Consumer : BackgroundThread
    {
        private Random randomizer = new Random();

        public MonitoredQueue InputQueue { get; set; }
        public int SimulatedWorkTime { get; set; }

        public Consumer(MonitoredQueue inputQueue, int simulatedWorkTime)
        {
            InputQueue = inputQueue;
            SimulatedWorkTime = simulatedWorkTime;
        }

        public override string ThreadName()
        {
            return "Consumer";
        }

        protected override void Process()
        {
            while (keepGoing)
            {
                // Try to empty the input queue
                while (keepGoing)
                {
                    // Goto Sleep for the simulated work time
                    int workTime = randomizer.Next(Math.Max(0, SimulatedWorkTime - 10), SimulatedWorkTime + 10);
                    Thread.Sleep(workTime);

                    Widget widget = InputQueue.Dequeue();
                    if (widget != null)
                        Console.WriteLine("Consumed Widget with Dimensions ({0}, {1}, {2})", widget.WidgetWidth, widget.WidgetHeight, widget.WidgetDepth);
                    else
                        break;
                }

                // Wait for something to be placed in the input queue or a 1 second
                InputQueue.StateChanged.WaitOne(1000);
            }
        }

    }
}
