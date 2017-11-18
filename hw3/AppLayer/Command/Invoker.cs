using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace AppLayer.Command
{
    /// <summary>
    /// This class is responsible for executing, undoing, and redoing commands.  It performs this actions on a separate thread.
    /// 
    /// Note: this class does not depend on the Drawing Components, any concrete command classes or the GUI.  Therefore, it is
    /// highly reusable and easy to test.
    /// 
    /// </summary>
    public class Invoker
    {
        private Thread _worker;
        private bool _keepGoing;

        private readonly ConcurrentQueue<Command> _todoQueue = new ConcurrentQueue<Command>();
        private readonly AutoResetEvent _enqueueOccurred = new AutoResetEvent(false);

        private readonly Stack<Command> _undoStack = new Stack<Command>();
        private readonly Stack<Command> _redoStack = new Stack<Command>();

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

        public bool EnqueueCommandForExecution(Command cmd)
        {
            if (cmd != null)
            {
                _todoQueue.Enqueue(cmd);
                _enqueueOccurred.Set();
                return true;
            }
            return false;
        }

        public void Undo()
        {
            EnqueueCommandForExecution(new UndoCommand());
        }

        public void Redo()
        {
            EnqueueCommandForExecution(new RedoCommand());
        }

        private void Run()
        {
            while (_keepGoing)
            {
                Command cmd;
                if (_todoQueue.TryDequeue(out cmd))
                {
                    if (cmd is UndoCommand)
                        ExecuteUndo();
                    else if (cmd is RedoCommand)
                        ExecuteRedo();
                    else
                    {
                        if (cmd.Execute())
                            _undoStack.Push(cmd);
                    }
                }
                else
                    _enqueueOccurred.WaitOne(100);
            }
        }

        private void ExecuteUndo()
        {
            if (_undoStack.Count <= 0) return;

            var cmd = _undoStack.Pop();
            cmd.Undo();
            _redoStack.Push(cmd);
        }

        private void ExecuteRedo()
        {
            if (_redoStack.Count <= 0) return;

            var cmd = _redoStack.Pop();
            cmd.Redo();
            _undoStack.Push(cmd);
        }

    }
}
