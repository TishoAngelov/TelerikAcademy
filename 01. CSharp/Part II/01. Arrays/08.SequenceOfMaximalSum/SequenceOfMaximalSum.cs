﻿using System;



class SequenceOfMaximalSum
{
    /*
    Write a program that finds the sequence of maximal sum in given array. Example:
    {2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
    Can you do it with only one loop (with single scan through the elements of the array)?
    */

    static void Main()
    {
        int length = 0;

        do
        {
            Console.Write("Enter the length of the array : ");
            length = int.Parse(Console.ReadLine());
        } while (length < 1);

        int[] array = new int[length];

        Console.WriteLine("\nEnter the elements of the array:");

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Element [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int max = array[0];
        int maxEnd = array[0];
        int longSequence = 1;
        int currentSequence = 1;
        int start = 0;
        int startTemp = 0;

        // Kadane's algorithm see more here : http://en.wikipedia.org/wiki/Maximum_subarray_problem

        for (int i = 1; i < array.Length; ++i)
        {
            if (array[i] + maxEnd > array[i])
            {
                maxEnd = array[i] + maxEnd;
                currentSequence++;
            }
            else
            {
                maxEnd = array[i];
                startTemp = i;
                currentSequence = 1;
            }
            if (maxEnd > max)
            {
                max = maxEnd;
                longSequence = currentSequence;
                start = startTemp;
            }
        }

        // Print the sequence of maximal sum

        Console.Write("\nThe maximal sum is made from this elements : ");

        for (int i = start; i < start + longSequence; ++i)
        {
            Console.Write("{0} ", array[i]);
        }

        Console.WriteLine();
    }
}