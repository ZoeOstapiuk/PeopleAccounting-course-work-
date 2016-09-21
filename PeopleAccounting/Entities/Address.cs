using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAccounting
{
    public class Address : IEquatable<Address>
    {
        private string country;
        private string region;
        private string locality;
        private string street;
        private int buildNumber;
        private int apartNumber;

        public Address() { }

        public Address(string country, string region, string locality, string street, int buildNum, int apNum)
        {
            Country = country;
            Locality = locality;
            Region = region;
            Street = street;
            BuildingNumber = buildNum;
            ApartamentNumber = apNum;
        }

        [ColumnName("Країна")]
        public string Country
        {
            get
            {
                return country;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("country");
                }
                country = value;
            }
        }

        [ColumnName("Область")]
        public string Region
        {
            get
            {
                return region;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("region");
                }
                region = value;
            }
        }

        [ColumnName("Місто/село/смт")]
        public string Locality
        {
            get
            {
                return locality;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("locality");
                }
                locality = value;
            }
        }

        [ColumnName("Вулиця")]
        public string Street
        {
            get
            {
                return street;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("street");
                }
                street = value;
            }
        }

        [ColumnName("Номер будинку")]
        public int BuildingNumber
        {
            get
            {
                return buildNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(buildNumber));
                }

                buildNumber = value;
            }
        }

        [ColumnName("Номер квартири")]
        public int ApartamentNumber
        {
            get
            {
                return apartNumber;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(apartNumber));
                }

                apartNumber = value;
            }
        }

        public bool Equals(Address other)
        {
            return this.Country == other.Country &&
                   this.Region == other.Region &&
                   this.Locality == other.Locality &&
                   this.Street == other.Street &&
                   this.BuildingNumber == other.BuildingNumber &&
                   this.ApartamentNumber == other.ApartamentNumber;
        }

        public override string ToString()
        {
            return String.Format("{0}, {1} обл., {2}, вул. {3} буд.{4}, кв.{5}", Country, Region,
                                 Locality, Street, BuildingNumber, ApartamentNumber);
        }
    }
}
