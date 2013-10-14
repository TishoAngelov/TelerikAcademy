using System;

class AddStarsToString
{
    // Write a program that reads from the console a string of maximum 20 characters. 
    // If the length of the string is less than 20, the rest of the characters should
    // be filled with '*'. Print the result string into the console.

    static void Main()
    {
        string text = string.Empty;
        int maxLength = 20;

        while (true)
        {
            Console.WriteLine("Enter some text with maximum of 20 characters");
            Console.Write("Text: ");
            text = Console.ReadLine();

            if (text.Length > maxLength)
            {
                Console.WriteLine("\nThe entered text is too long!\n");
            }
            else
            {
                break;
            }
        }

        Console.WriteLine(text.PadRight(maxLength, '*'));

        Console.WriteLine();
    }
}