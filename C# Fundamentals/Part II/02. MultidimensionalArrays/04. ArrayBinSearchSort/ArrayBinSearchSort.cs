using System;

class ArrayBinSearchSort
{
    // Write a program, that reads from the console an array of N integers and 
    // an integer K, sorts the array and using the method Array.BinSearch() 
    // finds the largest number in the array which is ≤ K. 

    public static void PrintArray(int[] anyArray, int someLength)
    {
        Console.WriteLine("\nYou have entered the array");
        Console.WriteLine(new string('=', 40));

        for (int i = 0; i < someLength; i++)
        {
            if (i < someLength - 1)
            {
                Console.Write(anyArray[i] + ", ");
            }
            else
            {
                Console.Write(anyArray[i] + ".");
            }
        }

        Console.WriteLine();
        Console.WriteLine(new string('=', 40));
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("Enter length (N) of array");
        Console.WriteLine(new string('=', 40));

        Console.Write("N = ");
        int length = int.Parse(Console.ReadLine());

        // fill the array
        Console.WriteLine("\nEnter {0} integer elements for the array", length);
        Console.WriteLine(new string('=', 50));
        
        int[] intArray = new int[length];

        for (int i = 0; i < length; i++)
        {
            Console.Write("element[{0}] = ", i);
            intArray[i] = int.Parse(Console.ReadLine());
        }
        //////////////////////////////////////////

        Console.WriteLine("\nUnsorted array");
        PrintArray(intArray, length);

        Console.WriteLine("\nSorted array");

        Array.Sort(intArray);
        PrintArray(intArray, length);

        Console.Write("Enter 1 integer number (K): ");
        int k = int.Parse(Console.ReadLine());

        if (intArray[0] > k)
        {
            Console.WriteLine("There is no number that is less than or equal to k.");
        }
        else
        {
            int binSearchIndex = Array.BinarySearch(intArray, k);
            int largestNumLowerThanK = 0;

            if (binSearchIndex >= 0)
            {
                largestNumLowerThanK = intArray[binSearchIndex];   // or largestNumLowerThanK = k;
            }
            else
            {
                largestNumLowerThanK = intArray[~binSearchIndex - 1];                
            }

            Console.WriteLine("The largest number lower than (or equal to) {0} in the array is {1}.", k, largestNumLowerThanK);
        }

        Console.WriteLine();
    }
}