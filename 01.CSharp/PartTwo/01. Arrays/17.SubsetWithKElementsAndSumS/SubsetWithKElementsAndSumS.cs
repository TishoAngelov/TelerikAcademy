using System;

class SubsetWithKElementsAndSumS
{
    // Write a program that reads three integer numbers N, K and S and an array of N elements from the console. 
    // Find in the array a subset of K elements that have sum S or indicate about its absence.

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

        int elements = 0;
        do
        {
            Console.Write("\nHow many elements you want the subset has : ");
            elements = int.Parse(Console.ReadLine());
        } while (elements < 1);

        Console.WriteLine();

        string currentSubset = "";
        bool hasSum = false;

        for (int i = 1; i < Math.Pow(2, n); i++)
        {
            currentSubset = "";
            int currentElements = 0;
            long currentSum = 0;

            for (int j = 0; j < n; j++)
            {
                int mask = 1 << j;
                int iAndMask = i & mask;
                int bit = iAndMask >> j;

                if (bit == 1)
                {
                    currentSubset += " " + numbers[j];
                    currentElements++;
                    currentSum += numbers[j];
                }
             }

            if (currentElements == elements && currentSum == wantedSum)
            {
                hasSum = true;

                Console.Write("This subset with {0} elements has sum {1} ---> ", currentElements, currentSum);
                Console.WriteLine("{0}", currentSubset);
            }
        }

        if (!hasSum)
        {
            Console.Write("There is no subset with {0} elements, that has sum {1} !!!", elements, wantedSum);
        }

        Console.WriteLine();
    }
}