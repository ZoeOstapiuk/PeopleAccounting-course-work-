using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PeopleAccounting.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotAssignEmptyName()
        {
            Person person = new Person(null, "", 0, new PhoneNumber("+380509121374"), new Address());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotAssignEmptyPhoneAndAddress()
        {
            Person person = new Person("Zoe", "Ostapyuk", 0, null, null);
        }

        [TestMethod]
        public void ChecksEqualityCorrectly()
        {
            Person person1 = new Person
            {
                FirstName = "fName",
                LastName = "lName",
                ID = 25,
                Address = new Address(),
                Number = new PhoneNumber("+380509121374")
            };

            Person person2 = new Person
            {
                FirstName = "fName",
                LastName = "lName",
                ID = 25,
                Address = new Address(),
                Number = new PhoneNumber("+380509121374")
            };

            Assert.AreEqual(true, person1.Equals(person2));
        }
    }
}
