using System;

class DayOfWeekToday
{
    // Write a program that prints to the console which day of the week is today. Use System.DateTime.

    static void Main()
    {
        string weekDayToday = DateTime.Today.DayOfWeek.ToString();

        Console.WriteLine("Today is {0}.", weekDayToday);
        Console.WriteLine();
    }
}