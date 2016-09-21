using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PeopleAccounting
{
    public class PhoneNumber : IEquatable<PhoneNumber>
    {
        public const string CountryCode = "+380";
        private string number;

        public PhoneNumber(string number)
        {
            if (!IsValid(number))
            {
                throw new InvalidNumberException(number);
            }
            Number = number;
        }

        public string Number
        {
            get
            {
                return CountryCode + number;
            }
            set
            {
                if (!IsValid(value))
                {
                    throw new InvalidNumberException(value);
                }

                number = value.Substring(4);
            }
        }

        public static bool IsValid(string number)
        {
            if (String.IsNullOrWhiteSpace(number))
            {
                return false;
            }
            
            if (number.Length != 13 || !number.StartsWith(CountryCode))
            {
                return false;
            }

            uint tryParse;
            return uint.TryParse(number.Substring(4), out tryParse);
        }

        public bool Equals(PhoneNumber other)
        {
            return this.number == other.number;
        }

        public override string ToString()
        {
            return Number;
        }
    }
}
