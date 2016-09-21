using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAccounting
{
    public interface IPeopleRepository : IEnumerable<Person>
    {
        Person this[int index] { get; }

        int Count { get;  }

        void Add(Person person);

        bool Delete(Person person);

        void Update(int index, Person person);

        void Clear();

        IList<Person> FindAddressesByLastname(string lastname);

        IList<Person> FindPeopleByPhoneNumber(PhoneNumber number);

        IList<Person> FindPeopleByAddress(Address address);

        IList<Person> FindSameNamesStreetsByPhoneNumber(PhoneNumber number);
    }
}
