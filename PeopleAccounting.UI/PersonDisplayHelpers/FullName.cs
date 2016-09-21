using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAccounting.UI.PersonDisplayHelpers
{
    public class FullName
    {
        [ColumnName("Ім'я")]
        public string FirstName { get; set; }

        [ColumnName("Прізвище")]
        public string LastName { get; set; }
    }
}
