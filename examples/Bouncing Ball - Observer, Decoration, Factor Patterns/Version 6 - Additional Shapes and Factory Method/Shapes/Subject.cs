using System.Collections.Generic;

namespace Shapes
{
    public class Subject
    {
        private readonly object _myLock = new object();
        private readonly List<ShapeObserver> _subscribers = new List<ShapeObserver>();

        public List<ShapeObserver> Subscribers => _subscribers;

        public void Subscribe(ShapeObserver observer)
        {
            lock (_myLock)
            {
                if (observer != null && !_subscribers.Contains(observer))
                    _subscribers.Add(observer);
            }
        }

        public void Unsubscribe(ShapeObserver observer)
        {
            lock (_myLock)
            {
                if (_subscribers.Contains(observer))
                    _subscribers.Remove(observer);
            }
        }

        public void Notify()
        {
            lock (_myLock)
            {
                foreach (ShapeObserver observer in _subscribers)
                    observer.Update(Clone());
            }
        }

        public virtual Subject Clone()
        {
            return MemberwiseClone() as Subject;
        }
    }
}
