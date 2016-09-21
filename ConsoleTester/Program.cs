using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PeopleAccounting;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {
            PeopleRepositoryFileHandler reader = new PeopleRepositoryFileHandler();
            var r = reader.ReadFromTextFile("test.txt");
            foreach (var item in r.FindSameNamesStreetsByPhoneNumber(r[0].Number))
            {
                Console.WriteLine(item);
            }
            PhoneNumber n = new PhoneNumber("+380669121374");
            Console.WriteLine(n.Number);

            Console.Read();
        }
    }
}
