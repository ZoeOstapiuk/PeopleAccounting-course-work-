namespace PeopleAccounting.UI.PersonDisplayHelpers
{
    public class NameAndAddress
    {
        // Клас, необхідний для фільтрації результату функції 
        // пошуку лише імені та адреси за певним критерієм
        [ColumnName("Ім'я")]
        public string FirstName { get; set; }

        [ColumnName("Адреса")]
        public Address Address { get; set; }
    }
}
