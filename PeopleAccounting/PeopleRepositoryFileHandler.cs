using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PeopleAccounting
{
    public class PeopleRepositoryFileHandler
    {
        private const int lineEntriesCount = 10;

        public PeopleRepositoryFileHandler()
        {
            Report = new InvalidLinesDictionary(10);
        }

        public bool TryParseFromString(string line, out Person person)
        {
            string[] entries = line.Trim(' ', '\t').Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            if (!IsLineCorrectForParsing(entries))
            {
                person = null;
                return false;
            }

            PhoneNumber number = new PhoneNumber(entries[3]);
            Address address = new Address
            {
                Country = entries[4],
                Region = entries[5],
                Locality = entries[6],
                Street = entries[7],
                BuildingNumber = int.Parse(entries[8]),
                ApartamentNumber = int.Parse(entries[9])
            };
            person = new Person(entries[1], entries[2], int.Parse(entries[0]), number, address);

            return true;
        }

        private bool IsLineCorrectForParsing(string[] line)
        {
            if (line.Length != lineEntriesCount)
            {
                return false;
            }

            uint tryParse;
            if (!uint.TryParse(line[0], out tryParse) || // Cheking ID
                !uint.TryParse(line[8], out tryParse) || // Checking building number
                !uint.TryParse(line[9], out tryParse) || // CHecking apartment number
                !PhoneNumber.IsValid(line[3]))           // Checking phone number
            {
                return false;
            }

            return true;
        }

        public IPeopleRepository ReadFromTextFile(string path)
        {
            if (String.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("path", "Please, provide this instance with a path to a file");
            }

            string[] lines = null;
            try
            {
                lines = File.ReadAllText(path).Split('\n');
            }
            catch (Exception e)
            {
                throw new ArgumentOutOfRangeException("Invalid path or file", e);
            }

            Report.Clear();
            return PeopleRepoFromStrings(lines);
        }

        public IPeopleRepository PeopleRepoFromStrings(string[] lines)
        {
            IPeopleRepository repo = new PeopleRepository();
            for (int i = 0; i < lines.Length; i++)
            {
                // 1 Остапюк Зоя +380937538109 Україна Львівська Львів Гнатюка 20 9
                Person result;
                if (!TryParseFromString(lines[i], out result))
                {
                    Report.Add(i, lines[i]);
                    continue;
                }
                
                try
                {
                    repo.Add(result);
                }
                catch (ArgumentException)
                {
                    Report.Add(i + 1, lines[i]);
                    continue;
                }
            }

            return repo;
        }

        public void WriteToFile(string path, IPeopleRepository repo)
        {
            StringBuilder lines = new StringBuilder();
            for (int i = 0; i < repo.Count; i++)
            {
                lines.Append(String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}", repo[i].ID, repo[i].LastName, repo[i].FirstName, repo[i].Number,
                                         repo[i].Address.Country, repo[i].Address.Region, repo[i].Address.Locality,
                                         repo[i].Address.Street, repo[i].Address.BuildingNumber, repo[i].Address.ApartamentNumber));
                if (i < repo.Count - 1)
                {
                    lines.Append("\n");
                }
            }


            File.WriteAllText(path, lines.ToString());
        }

        public InvalidLinesDictionary Report { get; private set; }
    }
}
