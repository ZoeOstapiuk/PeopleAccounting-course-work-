using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PeopleAccounting.Tests
{
    [TestClass]
    public class RepositoryTests
    {
        private IPeopleRepository repo = new PeopleRepository
        {
            new Person ("Людина1", "Людина1", 1, new PhoneNumber("+380509121374"), new Address("c", "r", "l", "s", 1, 1)),
            new Person ("Людина1", "Людина1", 2, new PhoneNumber("+380509121374"), new Address("c", "r", "l", "s", 1, 1)),
            new Person ("Людина1", "Людина1", 3, new PhoneNumber("+380509121374"), new Address("c1", "r1", "l1", "s1", 1, 1))
        };

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotAddSameIDs()
        {
            repo.Add(new Person { ID = 1 });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CannotUpdateSameIDs()
        {
            repo.Update(0, new Person { ID = 2 });
        }

        [TestMethod]
        public void FindsAddressesByLastName()
        {
            var result = repo.FindPeopleByLastname("Людина1");

            Assert.IsTrue(result.Count == 3);
            Assert.IsTrue(result[2].Address.Country == "c1");
        }

        [TestMethod]
        public void FindsPeopleByAddress()
        {
            var result = repo.FindPeopleByAddress(new Address("c", "r", "l", "s", 1, 1));

            Assert.IsTrue(result.Count == 2);
        }

        [TestMethod]
        public void FindsPeopleByPhoneNumber()
        {
            var result = repo.FindPeopleByPhoneNumber(new PhoneNumber("+380509121374"));

            Assert.IsTrue(result.Count == 3);
        }

        [TestMethod]
        public void FindsSameNamesStreetsByPhoneNumber()
        {
            var result = repo.FindSameNamesStreetsByPhoneNumber(new PhoneNumber("+380509121374"));

            Assert.IsTrue(result.Count == 2);
        }
    }
}
