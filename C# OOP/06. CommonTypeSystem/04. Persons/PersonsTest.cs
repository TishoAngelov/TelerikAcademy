using System;

namespace _04.Persons
{
    // Write a program to test the functionality.
    public class PersonsTest
    {
        static void Main()
        {
            Person p1 = new Person();
            Console.WriteLine(p1);

            Person p2 = new Person("Pesho", 2);
            Console.WriteLine(p2);

            Console.WriteLine();
        }
    }
}