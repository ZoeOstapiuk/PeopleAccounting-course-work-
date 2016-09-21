using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAccounting.UI.PersonDisplayHelpers
{
    public class NameAndStreet
    {
        [ColumnName("Ім'я")]
        public string FirstName { get; set; }

        [ColumnName("Вулиця")]
        public string Street { get; set; }
    }
}
