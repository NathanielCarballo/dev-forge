using System;

namespace Mosh
{
    class Program
    {
        static void Main(string[] args)
        {
            var firstName = "Nathaniel";
            var lastName = "Carballo";

            var fullName = firstName + " " + lastName;

            var myFullName = string.Format("My Name is {0] {1}", firstName, lastName);

            var names = new string[3] { "John", "Jack", "Mary" };
            var formattedNames = string.Join(",", names);
            Console.WriteLine(formattedNames);
        }
    }
}