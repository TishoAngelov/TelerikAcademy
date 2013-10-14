using System;

class IntArray
{
    /*
    Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. 
    Print the obtained array on the console.
    */

    static void Main()
    {
        int[] intArray = new int[20];

        for (int i = 0; i < intArray.Length; i++)
        {
            intArray[i] = i * 5;

            Console.WriteLine(intArray[i]);
        }

        Console.WriteLine();
    }
}