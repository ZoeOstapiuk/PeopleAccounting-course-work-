namespace PeopleAccounting.UI.PersonDisplayHelpers
{
    // Клас, необхідний для фільтрації результату функції 
    // пошуку лише імені та прізвища за певним критерієм
    public class FullName
    {
        [ColumnName("Ім'я")]
        public string FirstName { get; set; }

        [ColumnName("Прізвище")]
        public string LastName { get; set; }
    }
}
