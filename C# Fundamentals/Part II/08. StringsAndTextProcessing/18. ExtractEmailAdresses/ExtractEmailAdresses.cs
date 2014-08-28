using System;
using System.Text.RegularExpressions;

class ExtractEmailAdresses
{
    // Write a program for extracting all email addresses from given text. All substrings that 
    // match the format <identifier>@<host>…<domain> should be recognized as emails.

    static void Main()
    {
        Console.Write("Enter a text: ");
        string someStr = Console.ReadLine();

        string pattern = @"[a-zA-Z]+@[a-zA-Z]+\.[a-zA-Z]+";

        Console.WriteLine("\nThe email addresses in the text are");
        Console.WriteLine(new string('=', 50));

        MatchCollection matches = Regex.Matches(someStr, pattern);

        foreach (Match match in matches)
        {
            Console.WriteLine("{0}", match);
        }

        Console.WriteLine();
    }
}