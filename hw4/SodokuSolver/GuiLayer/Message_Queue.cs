using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiLayer
{
    public class Message_Queue
    {
        private static Message_Queue _instance;
        private static readonly object MyLock = new object();
        private Message_Queue()
        {
            MessageQueue = new ConcurrentQueue<string>();
            PuzzleMessageQueue = new ConcurrentQueue<string[,]>();
        }
        public ConcurrentQueue<string> MessageQueue;
        public ConcurrentQueue<string[,]> PuzzleMessageQueue;
        public static Message_Queue Instance
        {
            get
            {
                lock (MyLock)
                {
                    if(_instance == null)
                    {
                        _instance = new Message_Queue();
                    }
                    return _instance;
                }
            }
        }
    }
}
