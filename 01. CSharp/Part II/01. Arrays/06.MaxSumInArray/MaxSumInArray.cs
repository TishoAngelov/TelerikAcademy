using System;

class MaxSumInArray
{
    // Write a program that reads two integer numbers N and K and an array of N elements from the console. 
    // Find in the array those K elements that have maximal sum.

    static void Main()
    {
        int k = 0;
        
        do
        {
            Console.Write("How many elements you want to be in the sum: ");
            k = int.Parse(Console.ReadLine());
        } while (k < 1);

        int size = 0;

        do
        {
            Console.Write("What is the size of the array : ");
            size = int.Parse(Console.ReadLine());
        } while (size < 1 || size < k);

        int[] intArray = new int[size];

        Console.WriteLine("\nEnter the elements of the array :");

        for (int i = 0; i < size; i++)
        {
            Console.Write("Element [{0}] = ", i);
            intArray[i] = int.Parse(Console.ReadLine());
        }        

        Array.Sort(intArray); // Sort the array ascending

        Console.WriteLine("\nThe elements with the maximal sum are: ");

        for (int i = size - 1; i >= size - k; i--)
        {
            Console.WriteLine(intArray[i]);
        }

        Console.WriteLine();
    }
}