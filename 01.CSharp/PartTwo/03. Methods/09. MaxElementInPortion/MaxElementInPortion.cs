using System;

class MaxElementInPortion
{
    // Write a method that return the maximal element in a portion of array
    // of integers starting at given index. Using it write another method
    // that sorts an array in ascending / descending order.

    static void PrintArray(int[] anyArray)
    {
        Console.WriteLine("The given array");
        Console.WriteLine(new string('=', 50));

        for (int i = 0; i < anyArray.Length; i++)
        {
            if (i < anyArray.Length - 1)
            {
                Console.Write(anyArray[i] + ", ");
            }
            else
            {
                Console.Write(anyArray[i] + ". \n");
            }
        }

        Console.WriteLine(new string('=', 50));
        Console.WriteLine();
    }

    static int GetMaxElementInPortion(int[] anyArray, int startIndex, char ascDescOrder)
    {
        int maxElementIndex = startIndex;

        // asceding order
        if (ascDescOrder.Equals('a'))
        {
            for (int i = startIndex + 1; i < anyArray.Length; i++)
            {
                if (anyArray[maxElementIndex] < anyArray[i])
                {
                    maxElementIndex = i;
                }
            }
        }

        // descending order
        if (ascDescOrder.Equals('d'))
        {
            for (int i = startIndex - 1; i >= 0; i--)
            {
                if (anyArray[maxElementIndex] < anyArray[i])
                {
                    maxElementIndex = i;
                }
            }
        }
        

        return maxElementIndex;
    }

    static int[] SortArrayByMaxElementMethod(int[] anyArray, char sortOrder)
    {
        int[] sortedArray = new int[anyArray.Length];

        // descending order
        if (sortOrder.Equals('d'))
        {
            for (int i = 0; i < anyArray.Length; i++)
            {
                int tempNum = anyArray[i];

                sortedArray[i] = anyArray[GetMaxElementInPortion(anyArray, i, 'a')];
                anyArray[GetMaxElementInPortion(anyArray, i, 'a')] = tempNum;
            }
        }
        // ascending order
        else if (sortOrder.Equals('a'))
        {
            for (int i = anyArray.Length - 1; i >= 0 ; i--)
            {
                int tempNum = anyArray[i];

                sortedArray[i] = anyArray[GetMaxElementInPortion(anyArray, i, 'd')];
                anyArray[GetMaxElementInPortion(anyArray, i, 'd')] = tempNum;
            }
        }
        

        return sortedArray;
    }

    static void Main()
    {
        int[] givenArr = { 11, 12, 13, 1, 5, 6, 1, 2, 3, 1, 22, 33, 2, 5, 9 };

        PrintArray(givenArr);

        Console.WriteLine("Select one index from 0 - {0} to find" +
                            "\nthe maximal element in that portion.", givenArr.Length - 1);

        Console.Write("Index = ");
        int selectedIndex = int.Parse(Console.ReadLine());

        Console.Write("Select order - enter \"a\" for ascending" +
            "\nor \"d\" for descending: ");
        char sortOrder = char.Parse(Console.ReadLine());

        Console.WriteLine("\nThe maximal element has index: {0}\n", GetMaxElementInPortion(givenArr, selectedIndex, sortOrder));        

        Console.WriteLine("\nAfter {0} sort:\n", sortOrder.Equals('a') ? "ascending" : "descending");
        PrintArray(SortArrayByMaxElementMethod(givenArr, sortOrder));

        Console.WriteLine();
    }
}