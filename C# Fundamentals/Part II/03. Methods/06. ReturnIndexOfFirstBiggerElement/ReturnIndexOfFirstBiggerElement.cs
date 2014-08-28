using System;

class ReturnIndexOfFirstBiggerElement
{
    /*
        Write a method that returns the index of the first element in array
        that is bigger than its neighbors, or -1, if there’s no such element.
            * Use the method from the previous exercise.
    */

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

    static int BiggerNumIndex(int[] anyArray)
    {
        int firstBiggerNumIndex = -1;

        for (int i = 1; i < anyArray.Length - 1; i++)
		{
			 firstBiggerNumIndex = (anyArray[i] > anyArray[i - 1]) &&                   // Gets the index (i) if the both neighbors
                                        (anyArray[i] > anyArray[i + 1]) ? i : -1;       // are smaller. If they are not gets -1.

             if (firstBiggerNumIndex != -1)     // break when the first bigger num is found
             {
                 break;
             }
        }

        return firstBiggerNumIndex;
    }

    static void Main()
    {
        int[] givenArray = { 1, 3, 4, 1, 3, 2, 6, 7, 3, 4, 4, 3, 8, 9, 20 };

        PrintArray(givenArray);

        Console.Write("Index of the first element that is biggers than its 2 neighbors: {0}", BiggerNumIndex(givenArray));

        Console.WriteLine();
        Console.WriteLine();
    }
}