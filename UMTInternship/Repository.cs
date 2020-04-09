using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMTInternship
{
    
    public class Repository
    {
        public Repository(String file)
        {
            firstone  = new ArrayList();
             secondone = new ArrayList();
            firstrange = new ArrayList();
            secondrange = new ArrayList();

            read(file);
        }
        public string file;

        //minimum time in minutes a meeting can last
        public int minimum { get; set; }
        //list of meeting objects corresponding to the first person's calendar
        public ArrayList firstone { get; }

        //list of meeting objects corresponding to the second person's calendar
        public ArrayList secondone { get; }
        //list of meeting objects corresponding to the first person's free time
        public ArrayList firstrange { get; }
        //list of meeting objects corresponding to the second person's free time
        public ArrayList secondrange { get; }

        public ArrayList Availeblefirst()
        {
            return Availeble(this.firstrange, this.firstone);
        }

        public ArrayList Availeblesecond()
        {
            return Availeble(this.secondrange, this.secondone);
        }

        /*
         * firsone-list of meetings for a person's calendar
         * firstrange-the range of time availeble for a person in a day, a list with one meeting object
         * returns a list with the intervals of free time for a person
         * taking into account any free time that remains in range
         * after last meeting or before first meeting
         */
        public ArrayList Availeble(ArrayList firstrange,ArrayList firstone)
        {
            ArrayList av = new ArrayList();
            meeting m1 = (meeting)firstrange[0];
            meeting m2= (meeting)firstone[0];
            if (DateTime.Compare( m1.start, m2.start)<0)
            {
                meeting a = new meeting(m1.start, m2.start);
                av.Add(a);
            }
            for (int i = 1; i < firstone.Count; i++)
            {
                m1 = (meeting)firstone[i-1];
                m2= (meeting)firstone[i];
                if (DateTime.Compare(m1.end, m2.start) < 0)
                {
                    meeting a = new meeting(m1.end, m2.start);
                    av.Add(a);
                }
            }

            m1 = (meeting)firstrange[0];
            if (DateTime.Compare(m2.end, m1.end) < 0)
            {
                meeting a = new meeting(m2.end, m1.end);
                av.Add(a);
            }

            return av;
        }


        /*
         * filename- string object, the name of a file
         * reads the data form a txt file and stores it in corresponding lists
         * 
         */ 
        private void read(string filename)
        {
            string line;
            DateTime dt, dt2;
            meeting m;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@filename);
            //read the number of ranges for the first
            //person
            int n = int.Parse(file.ReadLine());

            //read the dates and compute ranges(meeting object)
            //add ranges to list
            for (int i = 0; i < n; i++)
            {

                line = file.ReadLine();
                dt = DateTime.ParseExact(line, "HH:mm", CultureInfo.InvariantCulture);
                line = file.ReadLine();
                dt2 = DateTime.ParseExact(line, "HH:mm", CultureInfo.InvariantCulture);


                m = new meeting(dt, dt2);
                firstone.Add(m);

            }
            line = file.ReadLine();
            dt = DateTime.ParseExact(line, "HH:mm", CultureInfo.InvariantCulture);
            line = file.ReadLine();
            dt2 = DateTime.ParseExact(line, "HH:mm", CultureInfo.InvariantCulture);


            m = new meeting(dt, dt2);
            //add the range time for meetings in a day for the first person
            firstrange.Add(m);

            //read same data for the second person
            n = int.Parse(file.ReadLine());
            for (int i = 0; i < n; i++)
            {

                line = file.ReadLine();
                dt = DateTime.ParseExact(line, "HH:mm", CultureInfo.InvariantCulture);
                line = file.ReadLine();
                dt2 = DateTime.ParseExact(line, "HH:mm", CultureInfo.InvariantCulture);


                m = new meeting(dt, dt2);
                secondone.Add(m);

            }
            line = file.ReadLine();
            dt = DateTime.ParseExact(line, "HH:mm", CultureInfo.InvariantCulture);
            line = file.ReadLine();
            dt2 = DateTime.ParseExact(line, "HH:mm", CultureInfo.InvariantCulture);


            m = new meeting(dt, dt2);

            secondrange.Add(m);

            //read the minimmum amount of time for a meeting in minutes
            minimum = int.Parse(file.ReadLine());
            file.Close();
        }
    }
}
