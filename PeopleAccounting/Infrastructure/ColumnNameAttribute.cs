using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleAccounting
{
    public class ColumnNameAttribute : Attribute
    {
        public ColumnNameAttribute(string name)
        {
            ColumnName = name;
        }

        public string ColumnName { get; set; }
    }
}
