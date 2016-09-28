using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PeopleAccounting
{
    public class PeopleRepository : IPeopleRepository
    {
        private IList<Person> people;

        public PeopleRepository()
        {
            people = new List<Person>();
        }

        public Person this[int index]
        {
            get
            {
                if (index < 0 || index >= people.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index));
                }
                
                return people[index];
            }
        }

        public int Count { get { return people.Count; } }

        public void Add(Person person)
        {
            var peopleWithId = people.Where(p => p.ID == person.ID).FirstOrDefault();
            if (peopleWithId != null)
            {
                throw new ArgumentException(person.ID.ToString());
            }

            people.Add(person);
        }

        public bool Delete(Person person)
        {
            if (people.Contains(person))
            {
                people.Remove(person);
                return true;
            }
            return false;
        }

        public void Update(int index, Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            var peopleWithId = people.Where(p => p.ID == person.ID).FirstOrDefault();
            if (person.ID != people[index].ID && peopleWithId != null)
            {
                throw new ArgumentException(person.ID.ToString());
            }

            people[index] = person;
        }

        public void Clear()
        {
            people.Clear();
        }

        public IList<Person> FindPeopleByLastname(string lastname)
        {
            if (String.IsNullOrWhiteSpace(lastname))
            {
                throw new ArgumentNullException();
            }

            // Використання LINQ для фільтрування записів
            return people.Where(p => p.LastName == lastname).ToList();
        }

        public IList<Person> FindPeopleByAddress(Address address)
        {
            if (address == null)
            {
                throw new ArgumentNullException();
            }

            // Використання LINQ для фільтрування записів
            return people.Where(p => p.Address.Equals(address)).ToList();
        }

        public IList<Person> FindPeopleByPhoneNumber(PhoneNumber number)
        {
            if (number == null)
            {
                throw new ArgumentNullException();
            }

            // Використання LINQ для фільтрування записів
            return people.Where(p => p.Number.Equals(number)).ToList();
        }

        public IList<Person> FindSameNamesStreetsByPhoneNumber(PhoneNumber number)
        {
            var sameNumber = FindPeopleByPhoneNumber(number);
            if (sameNumber == null)
            {
                return null;
            }

            var sameNameGroups = sameNumber.GroupBy(p => p.FirstName);

            // Знайти найбільшу групу людей з однаковими іменами
            var group = sameNameGroups.First();

            foreach (var item in sameNameGroups)
            {
                if (item.Count() > group.Count())
                {
                    group = item;
                }
            }

            // Знайти найбільшу групу людей з однаковими іменами і,
            // що проживають на тих самих вулицях
            var sameStreetGroups = group.Select(g => g).GroupBy(p => p.Address.Street);
            var resultGroup = sameStreetGroups.First();

            foreach (var item in sameStreetGroups)
            {
                if (item.Count() > resultGroup.Count())
                {
                    resultGroup = item;
                }
            }

            return resultGroup.Select(g => g).ToList();
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return people.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return people.GetEnumerator();
        }
    }
}
