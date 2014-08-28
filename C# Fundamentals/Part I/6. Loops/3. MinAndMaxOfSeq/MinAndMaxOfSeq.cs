using System;

class MinAndMaxOfSeq
{
    // Write a program that reads from the console a sequence of N 
    // integer numbers and returns the minimal and maximal of them.

    static void Main()
    {
        Console.Write("Enter lenght of a sequance (positive): ");
        int seqLength = int.Parse(Console.ReadLine());

        int [] seqNumbers = new int[seqLength];
        string sequance = "";
        int minNum = 0;
        int maxNum = 0;

        for (int i = 0; i < seqLength; i++)
        {
            Console.Write("Enter 1 integer number: ");
            seqNumbers[i] = int.Parse(Console.ReadLine());

            if (i == 0)
            {
                minNum = seqNumbers[i];
            }
            else if (minNum > seqNumbers[i])
            {
                minNum = seqNumbers[i];
            }

            if (maxNum < seqNumbers[i])
            {
                maxNum = seqNumbers[i];
            }

            sequance += seqNumbers[i] + " ";
        }
        Console.WriteLine("You have entered the sequance: {0}", sequance);
        Console.WriteLine("The minimal number is: {0}", minNum);
        Console.WriteLine("The maximal number is: {0}", maxNum);

        Console.WriteLine();
    }
}