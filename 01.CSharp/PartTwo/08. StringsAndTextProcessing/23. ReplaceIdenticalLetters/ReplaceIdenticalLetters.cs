using System;
using System.Text;

class ReplaceIdenticalLetters
{
    // Write a program that reads a string from the console and replaces all series of
    // consecutive identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa" -> "abcdedsa".

    static void Main()
    {
        string givenStr = "aaaaabbbbbcdddeeeedssaa";
        Console.WriteLine("Given string: {0}\n", givenStr);

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < givenStr.Length - 1; i++)
        {
            result.Append(givenStr[i]);

            while (givenStr[i] == givenStr[i + 1] && i < givenStr.Length - 2)
            {
                i++;
            }
        }

        Console.WriteLine("After replacing: {0}", result);

        Console.WriteLine();
    }
}