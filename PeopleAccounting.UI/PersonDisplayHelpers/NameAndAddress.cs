using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAccounting.UI.PersonDisplayHelpers
{
    public class NameAndAddress
    {
        [ColumnName("Ім'я")]
        public string FirstName { get; set; }

        [ColumnName("Адреса")]
        public Address Address { get; set; }
    }
}
