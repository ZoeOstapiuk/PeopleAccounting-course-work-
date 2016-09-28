namespace PeopleAccounting.UI.PersonDisplayHelpers
{
    public class NameAndStreet
    {
        // Клас, необхідний для фільтрації результату функції 
        // пошуку лише імені та вулиці за певним критерієм
        [ColumnName("Ім'я")]
        public string FirstName { get; set; }

        [ColumnName("Вулиця")]
        public string Street { get; set; }
    }
}
