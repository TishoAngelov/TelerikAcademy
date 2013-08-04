using System;

class CountNumbersInArray
{
    // Write a method that counts how many times given number appears in
    // given array. Write a test program to check if the method is working correctly.

    static int CountTimesNumAppears(int[] anyArray, int someNum)
    {
        int numAppear = 0;

        for (int i = 0; i < anyArray.Length; i++)
        {
            if (anyArray[i] == someNum)
            {
                numAppear++;
            }
        }

        return numAppear;
    }

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

    static void Main()
    {
        int[] givenArray = { 1, 3, 4, 1, 3, 2, 6, 7, 3, 4, 4, 3, 8, 9, 3 };

        PrintArray(givenArray);

        Console.Write("Enter one number: ");
        int chosenNum = int.Parse(Console.ReadLine());

        Console.WriteLine("\nThe number appears {0} times in the given array!", CountTimesNumAppears(givenArray, chosenNum));

        Console.WriteLine();
    }
}