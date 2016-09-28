using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PeopleAccounting
{
    public class InvalidLinesDictionary : IEnumerable<KeyValuePair<int, string>>
    {
        private IDictionary<int, string> errorDictionary;

        // Максимальна кількість записів, необхідна, бо файли можуть бути 
        // дуже великими, тому немає необхідності в збереженні 
        // кожного неправильного запису
        private int maxSize;

        public InvalidLinesDictionary(int max)
        {
            if (max < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            maxSize = max;
            errorDictionary = new Dictionary<int, string>();
        }

        public int Count { get { return errorDictionary.Count; } }

        public int MaxSize { get { return maxSize; } }

        // В словник додається KeyValuePair<int, string>
        public void Add(int line, string record)
        {
            if (errorDictionary.Count == maxSize)
            {
                // Remove last record
                errorDictionary.Remove(errorDictionary.Keys.Min());
            }

            errorDictionary.Add(line, record);
        }

        public void Clear()
        {
            errorDictionary.Clear();
        }

        public IEnumerator<KeyValuePair<int, string>> GetEnumerator()
        {
            return errorDictionary.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return errorDictionary.GetEnumerator();
        }
    }
}
