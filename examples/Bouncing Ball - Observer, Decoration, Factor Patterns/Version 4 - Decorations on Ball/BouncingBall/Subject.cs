using System.Collections.Generic;

namespace BouncingBall
{
    public class Subject
    {
        private readonly object _myLock = new object();

        public List<BallObserver> Subscribers { get; } = new List<BallObserver>();

        public void Subscribe(BallObserver observer)
        {
            lock (_myLock)
            {
                if (observer != null && !Subscribers.Contains(observer))
                    Subscribers.Add(observer);
            }
        }

        public void Unsubscribe(BallObserver observer)
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
                foreach (BallObserver observer in Subscribers)
                    observer.Update(Clone());
            }
        }

        public virtual Subject Clone()
        {
            return MemberwiseClone() as Subject;
        }
    }
}
