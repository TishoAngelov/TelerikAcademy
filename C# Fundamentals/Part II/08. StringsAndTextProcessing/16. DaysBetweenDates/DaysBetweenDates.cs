using System;
using System.Globalization;
using System.Threading;

class DaysBetweenDates
{
    /*
        Write a program that reads two dates in the format: day.month.year
        and calculates the number of days between them. Example:
            Enter the first date: 27.02.2006
            Enter the second date: 3.03.2004
            Distance: 4 days
    */

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");

        Console.Write("Enter the first date (day.month.year) ex.: 01.01.2012: ");
        DateTime firstDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

        Console.Write("Enter the second date: ");
        DateTime secondDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);

        Console.WriteLine("Distance: {0} days.", (secondDate - firstDate).TotalDays);

        Console.WriteLine();
    }
}