using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonClassLibrary
{
    public class BirthMatcher : Matcher
    {
        public override Dictionary<string, List<Person>> FindMatches(List<Person> list)
        {
            Dictionary<string, List<Person>> results = new Dictionary<string, List<Person>>();

            /*
             * Thought process: If I use a dictionary, I can add more than
             *  Just two people that "match", so the algorithm goes as 
             *  follows.
             *  
             *  For every person in the list I've been given,
             *   create a list of person objects. 
             *   add my person to that list. 
             *   For every person in the list I've been given,
             *    if I find a match, add it to my list. 
             *   save the results in the Dictionary
             *  return the dictionary.
             *
             */
            foreach (Person p in list){
                List<Person> pairs = new List<Person>();
                pairs.Add(p);
                foreach (Person q in list)
                {
                    if (p.ObjectId != q.ObjectId)
                    {
                        if (p.MothersFirstName == q.MothersFirstName && p.LastName == q.MothersLastName)
                        {
                            if (p.BirthYear == q.BirthYear && p.BirthMonth == q.BirthMonth && p.BirthDay == q.BirthDay)
                            {
                                pairs.Add(q);
                            }
                        }
                    }
                }
                results[p.LastName+","+p.FirstName] = pairs ;
            }
            return results;
            throw new NotImplementedException();
        }
    }
}
