using System;

namespace PeopleAccounting
{
    public class Person : IEquatable<Person>
    {
        private string firstName;
        private string lastName;
        private PhoneNumber number;
        private Address address;

        public Person() { }

        public Person(string lname, string fname, int id, PhoneNumber num, Address addr)
        {
            ID = id;
            LastName = lname;
            FirstName = fname;
            Number = num;
            Address = addr;
        }

        [ColumnName("№")]
        public int ID { get; set; }

        [ColumnName("Прiзвіще")]
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(lastName));
                }
                lastName = value;
            }
        }

        [ColumnName("Ім'я")]
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(firstName));
                }
                firstName = value;
            }
        }

        [ColumnName("Номер телефону")]
        public PhoneNumber Number
        {
            get
            {
                return number;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(number));
                }

                number = value;
            }
        }

        [ColumnName("Адреса")]
        public Address Address
        {
            get
            {
                return address;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(address));
                }

                address = value;
            }
        }

        public bool Equals(Person other)
        {
            return this.FirstName == other.FirstName &&
                   this.LastName == other.LastName &&
                   this.Address.Equals(other.Address) &&
                   this.Number.Equals(other.Number);
        }

        public override string ToString()
        {
            return String.Format("{0} {1} {2} {3}", LastName, FirstName, Number.ToString(), Address.ToString());
        }
    }
}
