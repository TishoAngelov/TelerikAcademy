using System;
using System.Text.RegularExpressions;

class CountSubstrings
{
    /*
        Write a program that finds how many times a substring is contained
        in a given text (perform case insensitive search). 
            Example: The target substring is "in". The text is as follows:

        We are living in an yellow submarine. We don't have anything else. 
        Inside the submarine is very tight. So we are drinking all the day.
        We will move out of it in 5 days.

            The result is: 9.
    */

    static void Main()
    {
        string substring = "in";
        string givenText = "We are living in an yellow submarine. We don't have anything else.\n"
                               + "Inside the submarine is very tight. So we are drinking all the day.\n"
                               + "We will move out of it in 5 days.";
        Console.WriteLine("Given text:\n{0}", givenText);

        int counter = Regex.Matches(givenText, @"(?i)" + substring).Count;      // (?i) - Use case-insensitive matching.
        Console.WriteLine("\nThe result is: {0}", counter);

        Console.WriteLine();
    }
}