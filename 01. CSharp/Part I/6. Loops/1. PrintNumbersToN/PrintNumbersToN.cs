using System;

class PrintNumbersToN
{
    // Write a program that prints all the numbers from 1 to N.

    static void Main()
    {
        Console.Write("Enter 1 integer number (positive): ");
        int intNum = int.Parse(Console.ReadLine());

        Console.WriteLine("All numbers to {0} are:", intNum);
        for (int i = 1; i <= intNum; i++)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine();
    }
}