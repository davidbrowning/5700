using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;

namespace AppLayer.Command
{
    public class Invoker
    {
        private Thread _worker;
        private readonly Stack<Command> _undoStack = new Stack<Command>();
        private readonly ConcurrentQueue<Command> _todoQueue = new ConcurrentQueue<Command>();
        private bool _keepGoing;
        private readonly AutoResetEvent _enqueueOccurred = new AutoResetEvent(false);

        public void Start()
        {
            _keepGoing = true;
            _worker = new Thread(Run);
            _worker.Start();
        }

        public void Stop()
        {
            _keepGoing = false;
        }

        public void EnqueueCommandForExecution(Command cmd)
        {
            if (cmd != null)
            {
                _todoQueue.Enqueue(cmd);
                _enqueueOccurred.Set();
            }
        }

        public void Undo()
        {
            if (_undoStack.Count > 0)
            {
                Command cmd = _undoStack.Pop();
                cmd.Undo();
            }
        }

        private void Run()
        {
            while (_keepGoing)
            {
                Command cmd;
                if (_todoQueue.TryDequeue(out cmd))
                {
                    cmd.Execute();
                    _undoStack.Push(cmd);
                }
                else
                    _enqueueOccurred.WaitOne(100);
            }
        }

    }
}
