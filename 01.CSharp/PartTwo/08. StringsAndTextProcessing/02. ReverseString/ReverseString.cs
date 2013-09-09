using System;

class ReverseString
{
    // Write a program that reads a string, reverses it and prints the result at the console.
    //     Example: "sample" -> "elpmas".

    static void Main()
    {
        Console.Write("Enter some text: ");
        string someStr = Console.ReadLine();

        Console.Write("Reversed text: ");
        for (int i = someStr.Length - 1; i >= 0; i--)
        {
            Console.Write(someStr[i]);
        }

        Console.WriteLine();
        Console.WriteLine();
    }
}