using System;

class SortStringArrayByElementLength
{
    // You are given an array of strings. Write a method that sorts the
    // array by the length of its elements (the number of characters composing them).

    static void Main()
    {
        string[] givenArray = { "a", "ss", "sss", "d", "aaa", "ssss", "tt", "r", "gg" };

        Console.WriteLine("Given array");
        Console.WriteLine(new string('=', 40));
        
        // print the given array (before sorting)
        for (int i = 0; i < givenArray.Length; i++)
        {
            if (i < givenArray.Length - 1)
            {
                Console.Write(givenArray[i] + ", "); 
            }
            else
            {
                Console.Write(givenArray[i] + ".\n"); 
            }
        }
        //////////////////////////////////////////////////

        // sorting the array by the length of its elements
        string[] sortedArray = new string[givenArray.Length];
        int currLength = 1;
        int sortedArrayIndex = 0;

        do
        {
            for (int i = 0; i < givenArray.Length; i++)
            {
                if (givenArray[i].Length == currLength)
                {
                    sortedArray[sortedArrayIndex] = givenArray[i];
                    sortedArrayIndex++;
                }
            }

            currLength++;

        } while (sortedArray[sortedArray.Length - 1] == null);
        ////////////////////////////////////////////////////

        // print the sorted array
        Console.WriteLine("\nThe array after sorting the array by the length of its elements");
        Console.WriteLine(new string('=', 65));

        for (int i = 0; i < sortedArray.Length; i++)
        {
            if (i < sortedArray.Length - 1)
            {
                Console.Write(sortedArray[i] + ", ");
            }
            else
            {
                Console.Write(sortedArray[i] + ".\n");
            }
        }
        ///////////////////////////////////////////////////

        Console.WriteLine();
    }
}