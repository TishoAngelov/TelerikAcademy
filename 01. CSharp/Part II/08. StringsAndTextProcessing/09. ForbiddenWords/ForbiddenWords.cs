using System;
using System.Text;
using System.Text.RegularExpressions;

class ForbiddenWords
{
    /*
        We are given a string containing a list of forbidden words and a text containing
        some of these words. Write a program that replaces the forbidden words with asterisks.
            Example:
                Microsoft announced its next generation PHP compiler today. It is based on .NET
                Framework 4.0 and is implemented as a dynamic language in CLR.

            Words: "PHP, CLR, Microsoft"

		    The expected result:
                ********* announced its next generation *** compiler today. It is based on .NET
                Framework 4.0 and is implemented as a dynamic language in ***.
    */

    static void Main()
    {
        string givenText = "Microsoft announced its next generation PHP compiler today. It is based"
                            + "on .NET Framework 4.0 and is implemented as a dynamic language in CLR.";
        Console.WriteLine("Given text:\n{0}\n", givenText);

        string[] forbiddenWords = { "PHP", "CLR", "Microsoft" };
        char replaceSymbol = '*';

        string asterixText = givenText;

        Console.WriteLine("Asterix text:");
        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            asterixText = Regex.Replace(asterixText, @"\b" + forbiddenWords[i] + @"\b",
                                                    new string(replaceSymbol, forbiddenWords[i].Length));         
        }

        Console.WriteLine(asterixText);

        Console.WriteLine();
    }
}