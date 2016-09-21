using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PeopleAccounting.Tests
{
    [TestClass]
    public class PhoneTests
    {
        [TestMethod]
        public void CannotAssignWrongFormat()
        {
            Assert.IsFalse(PhoneNumber.IsValid(""));
            Assert.IsFalse(PhoneNumber.IsValid("abcdabcdabcds"));
            Assert.IsFalse(PhoneNumber.IsValid("0509121374"));
        }

        [TestMethod]
        public void ChecksEqualityCorrectly()
        {
            PhoneNumber num1 = new PhoneNumber("+380509121374");
            PhoneNumber num2 = new PhoneNumber("+380509121374");

            Assert.IsTrue(num1.Equals(num2));
        }
    }
}
