using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppLayer.DrawingComponents;

namespace AppLayer.Command
{
    /// <summary>
    /// Base Command Class
    /// 
    /// This is the abstract Command class prescribed by the command pattern
    /// </summary>
    public abstract class Command
    {
        public Drawing TargetDrawing { get; set; }      // "Receiver" in the Command Pattern

        public abstract bool Execute();                 // This method does whatever is need to perform the commmand
                                                        // and returns true if and only if the command had an affect
                                                        // on the state of the drawing.  The method also needs to
                                                        // save enough state information that it can undo those
                                                        // affects later, if necessary.
        internal abstract void Undo();                  // Using the state information save by Execute, this
                                                        // method undoes the affects of have previous executed the
                                                        // command.  It is called by the Invoker.Undo method
        internal abstract void Redo();                  // The method re-executes the command effeciently, by using
                                                        // the state information saved by the Execute method.  If
                                                        // we were not worriying about effeciency, this Redo method
                                                        //  would not be needed and the Invoker.Redo method would
                                                        // just call Execute.
    }
}
