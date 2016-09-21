using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PeopleAccounting.Tests
{
    [TestClass]
    public class AddressTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CannotAssingEmptyValues()
        {
            Address address = new Address(null, "", "", null, 1, 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CannotAssingNegativeNumbers()
        {
            Address address = new Address("Ukraine", "Lvivska", "Lviv", "Sychivska", -5, 0);
        }

        [TestMethod]
        public void ChecksEqualityCorrectly()
        {
            Address address1 = new Address
            {
                Country = "Uk",
                Region = "region",
                Locality = "loc",
                Street = "street",
                BuildingNumber = 2,
                ApartamentNumber = 3
            };

            Address address2 = new Address
            {
                Country = "Uk",
                Region = "region",
                Locality = "loc",
                Street = "street",
                BuildingNumber = 2,
                ApartamentNumber = 3
            };

            Assert.AreEqual(true, address1.Equals(address2));
        }
    }
}
