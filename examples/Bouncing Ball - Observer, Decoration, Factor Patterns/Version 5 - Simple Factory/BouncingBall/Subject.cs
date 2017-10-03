using System.Collections.Generic;

namespace BouncingBall
{
    public class Subject
    {
        private readonly object _myLock = new object();

        public List<ShapeObserver> Subscribers { get; } = new List<ShapeObserver>();

        public void Subscribe(ShapeObserver observer)
        {
            lock (_myLock)
            {
                if (observer != null && !Subscribers.Contains(observer))
                    Subscribers.Add(observer);
            }
        }

        public void Unsubscribe(ShapeObserver observer)
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
                foreach (ShapeObserver observer in Subscribers)
                    observer.Update(Clone());
            }
        }

        public virtual Subject Clone()
        {
            return MemberwiseClone() as Subject;
        }
    }
}
