using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Common
{
    public abstract class BackgroundThread
    {
        #region Private data members
        protected Thread myThread = null;
        protected Timer parentCheckTimer = null;
        protected bool keepGoing = false;
        protected bool suspended = false;
        protected string errorMessage;
        #endregion

        #region Constructors and destruction
        public BackgroundThread() { }
        #endregion

        #region Public Methods
        public string ErrorMessage { get { return errorMessage; } }
        public virtual void Start()
        {
            parentCheckTimer = new Timer(new TimerCallback(ParentChecker), Thread.CurrentThread, 1000, 1000);

            try
            {
                keepGoing = true;
                suspended = false;
                myThread = new Thread(new ThreadStart(Process));
                myThread.Name = ThreadName();
                myThread.Start();
            }
            catch (Exception err)
            {
                errorMessage = string.Format("Aborted exception caught. {0}", err.Message);
            }
        }

        public virtual void Stop()
        {
            if (myThread != null)
            {
                errorMessage = string.Format("Stopping {0}", ThreadName());
                keepGoing = false;                      // Clear the flag that keep the background
                                                        // thread in its main loop
                myThread.Join();                        // Wait for background thread to terminate
                myThread = null;                        // deference the background thread so it will be
                                                        // garabage collected
            }
        }

        public abstract string ThreadName();

        public bool IsRunning
        {
            get { return (myThread != null && myThread.IsAlive); }
        }

        public virtual string Status
        {
            get
            {
                string result = "Not running";
                if (keepGoing)
                    result = (suspended) ? "Suspended" : "Running";
                return result;
            }
        }

        public virtual void Suspend()
        {
            if (Suspended == false)
                Suspended = true;
        }

        public virtual void Resume()
        {
            if (Suspended == true)
                Suspended = false;
        }

        public virtual bool Suspended
        {
            get { return suspended; }
            set { suspended = value; }
        }

        #endregion

        #region Private methods
        /// <summary>
        /// Main process method for background thread
        /// 
        /// This method should stop whatever it is doing and terminate whenever keepGoing becomes false. 
        /// Also, it should not actually do any process anything but stay alive, if suspend becomes true.
        /// </summary>
        protected abstract void Process();

        /// <summary>
        /// ParentChecker
        /// 
        /// This method will set the keepGoing to false, and there by stop the background processing, if
        /// the process that started the background thread is not longer alive.
        /// </summary>
        /// <param name="state">Parent Thread</param>
        protected void ParentChecker(object state)
        {
            Thread myParent = (Thread)state;
            if (keepGoing == true && myParent != null && !myParent.IsAlive)
                keepGoing = false;
        }

        #endregion

    }
}
