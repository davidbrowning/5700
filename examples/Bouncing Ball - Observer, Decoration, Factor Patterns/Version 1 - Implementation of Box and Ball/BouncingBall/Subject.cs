using System.Collections.Generic;

namespace BouncingBall
{
    public class Subject
    {
        private readonly object _myLock = new object();
        private readonly List<BallObserver> _subscribers = new List<BallObserver>();

        public List<BallObserver> Subscribers { get { return _subscribers; } }

        public void Subscribe(BallObserver observer)
        {
            lock (_myLock)
            {
                if (observer != null && !_subscribers.Contains(observer))
                    _subscribers.Add(observer);
            }
        }

        public void Unsubscribe(BallObserver observer)
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
                foreach (BallObserver observer in _subscribers)
                    observer.Update(Clone());
            }
        }

        public virtual Subject Clone()
        {
            return MemberwiseClone() as Subject;
        }
    }
}
