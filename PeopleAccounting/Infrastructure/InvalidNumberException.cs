using System;

namespace PeopleAccounting
{
    public class InvalidNumberException : Exception
    {
        public InvalidNumberException() : base("The number provided had invalid format or it is null") { }

        public InvalidNumberException(string invNum, string message) : base(message)
        {
            InvalidValue = invNum;
        }

        public InvalidNumberException(string invNum)
        {
            InvalidValue = invNum;
        }

        public InvalidNumberException(string message, Exception inner) : base(message, inner) { }

        // Стрічка, що не інтерпретується коректно як номер телефону
        public string InvalidValue { get; set; }
    }
}
