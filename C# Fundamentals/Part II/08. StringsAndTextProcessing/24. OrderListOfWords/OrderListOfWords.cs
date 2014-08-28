using System;
using System.Text.RegularExpressions;

class OrderListOfWords
{
    // Write a program that reads a list of words, separated by 
    // spaces and prints the list in an alphabetical order.

    static void Main()
    {
        Console.Write("Enter a string: ");
        string someStr = Console.ReadLine();

        string[] words = Regex.Split(someStr, " ");

        Array.Sort(words);

        Console.WriteLine("After sorting:");

        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }

        Console.WriteLine();
    }
}