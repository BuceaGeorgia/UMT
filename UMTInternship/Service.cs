using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//do the gap between second also, finish service part with gap function
//do unit tests


namespace UMTInternship
{
    public class Service
    {
        public Service(Repository r)
        {
            this.r = r;
        }

        /*
         * returns a list with the intervals of time when two people can meet in a day
         * based on their calendar
         */
      
        public ArrayList solve()
        {
            int iterator = 0;

            ArrayList availeblemutual=new ArrayList();
            ArrayList availiblefirst = r.Availeblefirst();
            ArrayList availiblesecond = r.Availeblesecond();
            meeting me;

            //loop the first person's free time 
            foreach (meeting m in availiblefirst)
            {

                    //iterate the second person's free time until the current range 
                    //intersects with m(first person current range)
                    while (iterator < availiblesecond.Count)
                    {
                       
                        me = (meeting)availiblesecond[iterator];
                    if (DateTime.Compare(me.end, m.start) < 0)
                        iterator = iterator + 1;
                    else
                        break;
                    }


                    //iterate the second person's free time until the ranges still
                    //intersect and compute the common interval of time for two ranges
                    //add the interval to final list
                int ok = 1;
                    while ( ok==1&& iterator < availiblesecond.Count)
                    {
                        DateTime st, en;
                    me = (meeting)availiblesecond[iterator];
                    //if the intervals intersect
                    if (DateTime.Compare(me.start, m.end) < 0)
                    {
                        ok = 0;
                        //take the latest start time
                        if (DateTime.Compare(me.start, m.start) < 0)
                            st = m.start;
                        else
                            st = me.start;
                        //take the earliest finish time
                        if (DateTime.Compare(me.end, m.end) < 0)
                            en = me.end;
                        else
                            en = m.end;

                        TimeSpan range = en - st;
                        double tot = range.TotalMinutes;
                        int total = (int)tot;
                        //verify if the start time is earlier than finish time or if the
                        //meeting is long enough
                        if (DateTime.Compare(st, en) < 0&&total>=r.minimum)
                        {
                            meeting mutualav = new meeting(st, en);
                            //add range to list
                            availeblemutual.Add(mutualav);
                        }
                        if (iterator < availiblesecond.Count -1)
                        {
                            ok = 1;
                            iterator = iterator + 1;
                            me = (meeting)availiblesecond[iterator];
                        }
                    }
                    else
                    {
                        if (ok == 1)
                            iterator--;
                        break;
                    }
                    }
                
            }
            return availeblemutual;
        }
        Repository r;

    }
}
