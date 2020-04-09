using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Globalization;
using UMTInternship;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestSolve()
        {
            Repository r = new Repository("test1.txt");
            Service s = new Service(r);

            ArrayList t= s.solve();
            Assert.AreEqual(t.Count, 4);

            r = new Repository("test2.txt");
            s = new Service(r);
            Assert.AreEqual(s.solve().Count, 3);

        }

        [TestMethod]
        public void TestRepository()
        {
            Repository r = new Repository("test1.txt");
            Assert.AreEqual(r.firstone.Count, 3);
            Assert.AreEqual(r.secondone.Count, 3);
            Assert.AreEqual(r.Availeblefirst().Count,4);
            Assert.AreEqual(r.Availeblesecond().Count, 4);
            Assert.AreEqual(r.minimum, 30);
        }

        [TestMethod]
        public void TestDomain()
        {
    
            meeting m = new meeting(DateTime.ParseExact("09:30", "HH:mm", CultureInfo.InvariantCulture), DateTime.ParseExact("22:30", "HH:mm", CultureInfo.InvariantCulture));
            Assert.AreEqual(DateTime.Compare(DateTime.ParseExact("09:30", "HH:mm", CultureInfo.InvariantCulture),m.start),0);
            Assert.AreEqual(DateTime.Compare(DateTime.ParseExact("22:30", "HH:mm", CultureInfo.InvariantCulture), m.end), 0);
        }
    }
}
