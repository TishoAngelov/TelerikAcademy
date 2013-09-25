using System;
using System.Globalization;
using System.Threading;

class PrintDateAfterTime
{
    // Write a program that reads a date and time given in the format: day.month.year 
    // hour:minute:second and prints the date and time after 6 hours and 30 minutes
    // (in the same format) along with the day of week in Bulgarian.

    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        
        Console.WriteLine("Enter a date (day.month.year) and time (HH:mm:ss). Example: 01.01.2013 01:02:03");
        Console.Write("Date and time: ");
        DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);

        TimeSpan later = new TimeSpan(6, 30, 0);
        date = date.Add(later);

        Console.WriteLine("\nThe date after 6 hours and 30 minutes is: {0} {1:dd.MM.yyyy hh:mm:ss}", date.ToString("dddd"), date);

        Console.WriteLine();
    }
}