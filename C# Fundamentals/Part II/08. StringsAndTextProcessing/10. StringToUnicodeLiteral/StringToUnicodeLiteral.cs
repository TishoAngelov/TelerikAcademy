using System;

class StringToUnicodeLiteral
{
    /*
        Write a program that converts a string to a sequence of C# 
        Unicode character literals. Use format strings. Sample input:
            Hi!
        Expected output:
            \u0048\u0069\u0021
    */

    static void Main()
    {
        string givenString = "Hi! What's up?";
        Console.WriteLine("Given string: {0}\n", givenString);

        Console.WriteLine("Unicode character literals:");
        for (int i = 0; i < givenString.Length; i++)
        {
            Console.Write(@"\u{0:X4}", (int)givenString[i]);
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}