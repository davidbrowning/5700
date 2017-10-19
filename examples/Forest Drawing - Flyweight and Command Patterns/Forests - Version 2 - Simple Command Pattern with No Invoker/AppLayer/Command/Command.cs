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

        public abstract void Execute();
    }
}
