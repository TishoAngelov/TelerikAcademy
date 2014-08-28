using System;

class PrintNumbersToN
{
    // Write a program that reads an integer number n from the console and
    // prints all the numbers in the interval [1..n], each on a single line.

    static void Main()
    {
        Console.Write("Enter 1 number: ");
        int intNum = int.Parse(Console.ReadLine());

        for (int i = 1; i <= intNum; i++)
        {
            Console.WriteLine(i);
        }
        Console.WriteLine();
    }
}

