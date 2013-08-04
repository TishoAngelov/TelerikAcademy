﻿using System;
using System.Collections.Generic;

class SortedArray
{
    /*
    Write a program that reads an array of integers and removes from it a minimal number of elements
    in such way that the remaining array is sorted in increasing order. Print the remaining sorted array. 
    Example: {6, 1, 4, 3, 0, 3, 6, 4, 5} -> {1, 3, 3, 4, 5}
    */

    static bool isSorted(List<int> array)
    {
        for (int i = 0; i < array.Count - 1; i++)
        {
            if (array[i] > array[i + 1])
            {
                return false;
            }
        }
        return true;
    }
    
    static void Main()
    {
        int n = 0;

        do
        {
            Console.Write("How many elements does the array have - ");
            n = int.Parse(Console.ReadLine());
        } while (n < 1);

        int[] array = new int[n];

        Console.WriteLine("\nEnter the elements of the array:");

        for (int i = 0; i < n; i++)
        {
            Console.Write("Element [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }

        int length = 0;
        List<int> maxSortedArray = new List<int>();

        for (int i = 1; i < Math.Pow(2, array.Length); i++)
        {
            List<int> currentArray = new List<int>();
            int currentLength = 0;

            for (int j = 0; j < array.Length; j++)
            {
                int bit = ((1 << j) & i) >> j;

                if (bit == 1)
                {
                    currentLength++;
                    currentArray.Add(array[j]);
                }
            }

            if (isSorted(currentArray))
            {
                if (length < currentLength)
                {
                    length = currentLength;
                    maxSortedArray = currentArray;
                }
            }
        }

        Console.Write("\nMaximal sorted array is: ");

        foreach (var item in maxSortedArray)
        {
            Console.Write("{0} ", item);
        }

        Console.WriteLine();
    }
}
