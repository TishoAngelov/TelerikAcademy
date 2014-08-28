using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;

class ExtractDates
{    
    // Write a program that extracts from a given text all dates that match the format DD.MM.YYYY. 
    // Display them in the standard date format for Canada.

    static void Main()
    {
        Console.Write("Enter a text: ");
        string someStr = Console.ReadLine();

        string pattern = @"(\b[0-9]{2}\b).(\b[0-9]{2}\b).(\b[0-9]{4}\b)";

        Console.WriteLine("\nThe dates in the text are:");

        MatchCollection matches = Regex.Matches(someStr, pattern);

        foreach (Match match in matches)
        {
            DateTime dateInCanada;

            if (DateTime.TryParseExact(match.Value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateInCanada))
            {
                Console.WriteLine(dateInCanada.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
            }
        }

        Console.WriteLine();
    }
}