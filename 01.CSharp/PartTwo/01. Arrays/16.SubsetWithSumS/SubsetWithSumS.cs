using System;
using System.Collections.Generic;

class SubsetWithSumS
{
    // We are given an array of integers and a number S. Write a program to find if there exists a subset of the elements 
    // of the array that has a sum S. Example: arr={2, 1, 2, 4, 3, 5, 2, 6}, S=14 -> yes (1+2+5+6)

    static void Main()
    {
        int n = 0;

        do
        {
            Console.Write("How many elements does the array have ? - ");
            n = int.Parse(Console.ReadLine());
        } while (n < 1);

        int[] numbers = new int[n];

        Console.WriteLine("\nEnter the elements of the array:");

        for (int i = 0; i < n; i++)
        {
            Console.Write("Element [{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.Write("\nWhat is the sum : ");
        long wantedSum = long.Parse(Console.ReadLine());

        Console.WriteLine();

        List<long> sums = new List<long>();
        List<string> subSet = new List<string>();

        for (int i = 0; i < n; i++)
        {
            for (int j = 0, len = sums.Count; j < len; j++)
            {
                sums.Add(sums[j] + numbers[i]);
                subSet.Add(subSet[j] + ", " + numbers[i]);
            }
            sums.Add(numbers[i]);
            subSet.Add(numbers[i].ToString());
        }

        bool hasSum = false;

        for (int i = 0; i < sums.Count; i++)
        {
            if (sums[i] == wantedSum)
            {
                hasSum = true;
                Console.Write("This subset has sum = {0} ---> ", wantedSum);
                Console.WriteLine("{0}", subSet[i]);
            }
        }

        if (!hasSum)
        {
            Console.WriteLine("There are no subsets with sum = {0} !!!", wantedSum);
        }

        Console.WriteLine();
    }
}
