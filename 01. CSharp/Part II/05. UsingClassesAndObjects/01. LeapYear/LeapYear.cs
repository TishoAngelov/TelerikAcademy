using System;

class LeapYear
{
    // Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

    static void Main()
    {
        Console.Write("Enter year: ");
        ushort anyYear = ushort.Parse(Console.ReadLine());

        bool isYearLeap = DateTime.IsLeapYear(anyYear);

        if (isYearLeap)
        {
            Console.WriteLine("The year {0} is leap.", anyYear);
        }
        else
        {
            Console.WriteLine("The year {0} is not leap.", anyYear);
        }

        Console.WriteLine();
    }
}