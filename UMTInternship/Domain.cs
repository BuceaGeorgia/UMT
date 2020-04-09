using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMTInternship
{
    public class meeting
    {
        /* class used to store an interval
         * s-DateTime object corresponding to the beginning of the interval
         * e-DateTime object corresponding to the end of the interval
         */
        public meeting(DateTime s, DateTime e) { start = s; end = e; }
        public DateTime start { get; }
        public DateTime end { get; }
        public override string ToString() => $"[{start.ToString("HH:mm", CultureInfo.InvariantCulture)}, {end.ToString("HH:mm", CultureInfo.InvariantCulture)}]";
    }
}
