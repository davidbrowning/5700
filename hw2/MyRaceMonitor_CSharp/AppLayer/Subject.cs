using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer
{
    public abstract class Subject
    {
        private List<AthleteObserver> AthleteObserverList;

        //internal List<AthleteObserver> AthleteObserverList { get => AthleteObserverList; set => AthleteObserverList = value; }

        public bool Subscribe()
        {
            return false;
        }
        public bool Unsubscribe(AthleteObserver ao) => true;
    }
}
