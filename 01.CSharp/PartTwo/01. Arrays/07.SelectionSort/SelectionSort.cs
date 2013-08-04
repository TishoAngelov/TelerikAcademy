using System;

class SelectionSort
{
    /*
    Sorting an array means to arrange its elements in increasing order. 
    Write a program to sort an array. Use the "selection sort" algorithm: 
    Find the smallest element, move it at the first position, find the smallest from the rest,
    move it at the second position, etc.
    */

    static void printArray(int[] array, int i, int j)
    {
        for (int k = 0; k < array.Length; k++)
        {
            if (k == j || k == i)
            {
                Console.WriteLine("Element [{0}] = {1} <-------", k, array[k]);
            }
            else
            {
                Console.WriteLine("Element [{0}] = {1} ", k, array[k]);
            }
        }
    }

    static void Main()
    {
        int n = 0;

        do
        {
            Console.Write("Enter count of elements: ");
            n = int.Parse(Console.ReadLine());
        } while (n < 1);

        int[] arrayToSort = new int[n];

        Console.WriteLine("\nEnter the elements of the array:");

        for (int i = 0; i < n; i++)
        {
            Console.Write("Element [{0}] = ", i);
            arrayToSort[i] = int.Parse(Console.ReadLine());
        }
        
        int min = int.MaxValue;
        int index = 0;

        for (int i = 0; i < n - 1; i++)
        {
            min = int.MaxValue;
            index = 0;
            for (int j = i + 1; j < n; j++)
            {
                if (min > arrayToSort[j])
                {
                    min = arrayToSort[j]; // Get minimal value from the remaining elements
                    index = j;
                }
            }

            printArray(arrayToSort, i, index); // Show the array and the elements that are going to be swap

            if (min < arrayToSort[i]) // Check if the two elements are not sorted  and swap them
            {
                arrayToSort[index] = arrayToSort[i];
                arrayToSort[i] = min;
            }
        }

        Console.Write("\nThe sorted array is : ");

        for (int i = 0; i < n; i++) // Printing the sorted array
        {
            Console.Write("{0}, ", arrayToSort[i]);
        }
        Console.WriteLine("\n");
    }
}