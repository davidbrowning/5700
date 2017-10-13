using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLayer
{
    public class Subject
    {
        private readonly object _myLock = new object();

        public List<AthleteObserver> Subscribers { get; } = new List<AthleteObserver>();

        public void Subscribe(AthleteObserver observer)
        {
            lock (_myLock)
            {
                if (observer != null && !Subscribers.Contains(observer))
                    Subscribers.Add(observer);
            }
        }

        public void Unsubscribe(AthleteObserver observer)
        {
            lock (_myLock)
            {
                if (Subscribers.Contains(observer))
                    Subscribers.Remove(observer);
            }
        }

        public void Notify()
        {
            lock (_myLock)
            {
                foreach (AthleteObserver observer in Subscribers)
                {
                    observer.Update(Clone());
                }
            }
        }

        public virtual Subject Clone()
        {
            return MemberwiseClone() as Subject;
        }
    }
}
