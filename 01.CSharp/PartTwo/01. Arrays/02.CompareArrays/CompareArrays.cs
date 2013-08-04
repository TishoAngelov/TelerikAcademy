using System;

class CompareArrays
{
    // Write a program that reads two arrays from the console and compares them element by element.

    static void Main()
    {
        int[] firstArray = new int[5];     // There is no length required so
        int[] secondArray = new int[5];    // I will allocate 5 elements.

        for (int i = 0; i < firstArray.Length; i++)
        {
            Console.Write("First array[{0}] = ", i);
            firstArray[i] = int.Parse(Console.ReadLine());

            Console.Write("Second array[{0}] = ", i);
            secondArray[i] = int.Parse(Console.ReadLine());

            Console.WriteLine();
        }

        for (int i = 0; i < firstArray.Length; i++)
        {
            Console.WriteLine("First array[{0}] >= Second array[{0}] - {1}", i, firstArray[i] >= secondArray[i]);
        }

        Console.WriteLine();
    }
}