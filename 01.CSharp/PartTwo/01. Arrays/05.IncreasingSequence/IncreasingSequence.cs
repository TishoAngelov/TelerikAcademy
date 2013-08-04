using System;

class IncreasingSequence
{
    // Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

    static void printSequence(int[] intArray, int endPoint, int maxElements) // print the increasing sequence
    {
        Console.WriteLine("\nThe sequence looks like :");

        for (int i = endPoint - maxElements; i < endPoint; i++)
        {
            Console.WriteLine("Element[{0}] = {1}", i, intArray[i]);
        }
    }

    static void Main()
    {
        int length = 0;

        do
        {
            Console.Write("How many elements you want to has the array : ");
            length = int.Parse(Console.ReadLine());
        } while (length < 1);

        int[] intArray = new int[length];

        Console.WriteLine("\nEnter the elements of the array:");

        // Initializing the array

        for (int i = 0; i < length; i++)
        {
            Console.Write("Element [{0}] = ", i);
            intArray[i] = int.Parse(Console.ReadLine());
        }

        int maxElements = 1;
        int currentElements = 1;
        int endPoint = 0;

        // Find the maximal sequence
        for (int j = 1; j < length; j++)
        {
            if (intArray[j - 1] == intArray[j] - 1)
            {
                currentElements++;
                if (maxElements < currentElements)
                {
                    maxElements = currentElements;
                }
            }
            else
            {
                currentElements = 1;
            }
        }

        // Check if there are no sequences with increasing elements

        if (maxElements == 1)
        {
            Console.WriteLine("\nThere are no sequences with increasing elements!!!");
            Console.WriteLine();
            return;
        }

        Console.WriteLine("\nThe maximal sequence is with {0} elements.", maxElements);

        currentElements = 1;

        // Check if there are more than one sequence with maximal length

        for (int j = 1; j < length; j++)
        {
            if (intArray[j - 1] == intArray[j] - 1)
            {
                currentElements++;
                if (maxElements == currentElements)
                {
                    endPoint = j + 1;
                    printSequence(intArray, endPoint, maxElements);
                }
            }
            else
            {
                currentElements = 1;
            }
        }

        if (length == 1)
        {
            printSequence(intArray, 1, 1);
        }

        Console.WriteLine();
    }
}