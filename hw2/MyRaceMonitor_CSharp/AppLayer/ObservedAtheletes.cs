using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppLayer
{
    public class ObservedAthletes
    {
        private ObservedAthletes(){}

        [MethodImpl(MethodImplOptions.Synchronized)]
        public static ObservedAthletes GetInstance()
        {
            if (oa == null)
            {
                oa = new ObservedAthletes();
            }
            return oa;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool AddAthlete(Athlete a)
        {
            try
            {
                oa._AthletesBeingObserved.Add(a.BibNumber, a);
                return true;
            }
            catch
            {
                MessageBox.Show("Could not add Athlete " + a.ToString(),"ERROR",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public bool UpdateAthlete(Athlete a)
        {
            if(!_AthletesBeingObserved.ContainsKey(a.BibNumber))
            {
                oa._AthletesBeingObserved.Add(a.BibNumber, a);
                return true;
            }
            else
            {
                oa._AthletesBeingObserved[a.BibNumber] = a;
            }
            return false;
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        public List<Athlete> GetList()
        {
            List<Athlete> AthleteList = new List<Athlete>();
            foreach (var pair in _AthletesBeingObserved)
            {
                AthleteList.Add(pair.Value);
            }
            return AthleteList;
        }
        
        [MethodImpl(MethodImplOptions.Synchronized)]
        public Dictionary<int, Athlete> GetDictionary()
        {
            return _AthletesBeingObserved;
        }

        private static ObservedAthletes oa;
        private readonly Dictionary<int, Athlete> _AthletesBeingObserved = new Dictionary<int, Athlete>();

    }
}
