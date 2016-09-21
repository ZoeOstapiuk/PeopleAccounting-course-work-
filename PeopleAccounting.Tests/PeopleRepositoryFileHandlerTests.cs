using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PeopleAccounting.Tests
{
    [TestClass]
    public class PeopleRepositoryFileHandlerTests
    {
        [TestMethod]
        public void InvalidStringDenied()
        {
            string str = "-8|Ostapyuk|Zoe|+38050912137d|ukr|lv|lviv|syxiv|2|2";

            PeopleRepositoryFileHandler handler = new PeopleRepositoryFileHandler();
            Person result;

            Assert.IsFalse(handler.TryParseFromString(str, out result));
            Assert.IsNull(result);
        }

        [TestMethod]
        public void ReporsWorkCorrectly()
        {
            string[] lines = new string[]
            {
                "-8|Ostapyuk|Zoe|+38050912137d|ukr|lv|lviv|syxiv|2|2",
                "1|Koval|Roman|+380509121374|ukr|lv|lviv|syxiv|2|2",
                "1|Koval|Roman|+380509121374|ukr|lv|lviv|syxiv|2|2",
                "6|Koval|Vova|+380669121374|ukr|Odesska|Odessa|deribas|2|2"
            };

            PeopleRepositoryFileHandler handler = new PeopleRepositoryFileHandler();
            handler.PeopleRepoFromStrings(lines);

            Assert.IsTrue(handler.Report.Count == 2);
        }
    }
}
