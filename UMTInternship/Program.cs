using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace UMTInternship
{
    // do some tests and check 
    class Program
    {
        static void Main(string[] args)
        {
            //Print the list of intervals when two people can meet
            Repository r = new Repository("data.txt");
            Service s = new Service(r);

            foreach (meeting el in s.solve()) { Console.WriteLine(el); }
        }
    }
}
