using System;

class CalcWorkdays
{
    /*
        Write a method that calculates the number of workdays between
        today and given date, passed as parameter. Consider that workdays
        are all days from Monday to Friday except a fixed list of public 
        holidays specified preliminary as array.
    */
    
    static int WorkdaysLeftTo(DateTime givenDate)
    {
        DateTime today = DateTime.Today;
        Console.WriteLine("Today is {0}.", today.ToLongDateString());

        // check if the given date is correct
        if (today > givenDate)
        {
            Console.WriteLine("\nIncorrect date! Please don't enter past date!\n");

            return 0;
        }

        DateTime[] holidays = {
                                  new DateTime(today.Year, 1, 1),           // New Year
                                  new DateTime(today.Year, 3, 3),           // Day of Liberation of Bulgaria from Ottoman rule
                                  new DateTime(today.Year, 5, 1),           // Labor Day and International Workers' Solidarity
                                  new DateTime(today.Year, 5, 6),           // St. George's Day, Day of the Bulgarian Army
                                  new DateTime(today.Year, 5, 24),          // Day of Bulgarian Education and Culture and Slavonic Literature
                                  new DateTime(today.Year, 9, 6),           // Unification Day
                                  new DateTime(today.Year, 9, 22),          // Independence Day of Bulgaria
                                  new DateTime(today.Year, 11, 1),          // Day Enlightenment Leaders
                                  new DateTime(today.Year, 12, 24),         // Christmas Eve
                                  new DateTime(today.Year, 12, 25),         // Christmas
                                  new DateTime(today.Year, 12, 26)          // Christmas
                              };
        int workdays = 0;

        for (; today <= givenDate; today = today.AddDays(1))
        {
            for (int i = 0; i < holidays.Length; i++)
            {
                if (today.Year > holidays[i].Year)
                {
                    holidays[i] = holidays[i].AddYears(1);
                }

                if (today.Equals(holidays[i]))
                {
                    workdays--;
                }
            }

            if (today.DayOfWeek != DayOfWeek.Saturday && today.DayOfWeek != DayOfWeek.Sunday)
            {
                workdays++;
            }
        }

        return workdays;
    }

    static void Main()
    {
        Console.Write("Enter a date (YYYY MM DD): ");
        DateTime givenDate = new DateTime();

        try
        {
            givenDate = DateTime.Parse(Console.ReadLine());
        }
        catch (FormatException)
        {
            Console.WriteLine("Incorrect date format!\n");

            return;
        }

        Console.WriteLine("Workdays left to {0} - {1}.", givenDate.ToLongDateString(), WorkdaysLeftTo(givenDate));

        Console.WriteLine();
    }
}