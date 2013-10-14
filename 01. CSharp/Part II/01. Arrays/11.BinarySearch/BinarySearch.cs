using System;
using System.Linq;

class BinarySearch
{
    // Write a program that finds the index of given element in a sorted array of integers 
    // by using the binary search algorithm (find it in Wikipedia).

    static void Main()
    {
        Console.Write("What is the number : ");
        int numberForSearch = int.Parse(Console.ReadLine());

        int size = 0;

        do
        {
            Console.Write("How many elements does the array have : ");
            size = int.Parse(Console.ReadLine());
        } while (size < 1);

        int[] sortedArray = new int[size];

        Console.WriteLine("\nEnter the elements of the array : ");

        for (int i = 0; i < size; i++)
        {
            Console.Write("Element [{0}] = ", i);
            sortedArray[i] = int.Parse(Console.ReadLine());
        }


        int[] withOutDuplicates = sortedArray.Distinct().ToArray(); // Remove duplicated numbers

        bool isSorted = true;
        
        // Check if the array is not sorted ascending

        for (int i = 0; i < withOutDuplicates.Length - 1; i++)
        {
            if (withOutDuplicates[i] > withOutDuplicates[i + 1])
            {
                Console.WriteLine("\nThe array is not sorted!");
                isSorted = false;
                break;
            }
        }

        if (!isSorted)
        {
            Array.Sort(withOutDuplicates);
        }

        Console.WriteLine();

        Console.WriteLine("The sorted array : ");

        for (int i = 0; i < withOutDuplicates.Length; i++)
        {
            Console.WriteLine("Element [{0}] = {1}", i, withOutDuplicates[i]);
        }

        // First solution with stored method 

        int index = Array.BinarySearch(withOutDuplicates, numberForSearch);
        if (index < 0)
        {
            Console.WriteLine("The element {0} is not in the array!!!", numberForSearch);
        }
        else
        {
            Console.WriteLine("The element's index is {0}.", index);
        }
        
        Console.WriteLine();
    }

    static int BinarySearchElement(int[] array, int value)
    {
        int low = 0, high = array.Length - 1, midpoint = 0;

        while (low <= high)
        {
            midpoint = low + (high - low) / 2;

            // Check if the element is on the current position

            if (value == array[midpoint])
            {
                return midpoint;
            }
            else if (value < array[midpoint])
                high = midpoint - 1;
            else
                low = midpoint + 1;
        }

        return -1;          // Return -1 when element was not found
    }
}
