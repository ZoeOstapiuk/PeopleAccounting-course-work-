using System;

namespace PeopleAccounting
{
    public class ColumnNameAttribute : Attribute
    {
        public ColumnNameAttribute(string name)
        {
            ColumnName = name;
        }

        // Назва стовпця, що відображатиметься при наповненні таблиці
        public string ColumnName { get; set; }
    }
}
