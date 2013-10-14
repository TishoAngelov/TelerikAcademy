/*
 * Write a program that prints the first 10 
 * members of the sequence: 2, -3, 4, -5, 6, -7, ...
*/
using System;

class PrintFirstTenMembOfSequence
{
    static void Main()
    {
        string sequence = null;

        Console.WriteLine("Print the first ten members of the sequence: 2, -3, 4, -5, 6, -7, ...");
        for (int i = 2; i < 12; i++)
        {
            if (i % 2 == 0)
            {
                sequence += i + " ";
            }
            else
            {
                sequence += -i + " ";
            }
        }
        Console.WriteLine("The full sequence is: " + sequence);
    }
}