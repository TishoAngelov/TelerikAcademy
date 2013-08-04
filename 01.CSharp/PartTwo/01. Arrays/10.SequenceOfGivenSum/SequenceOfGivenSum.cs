using System;
using System.Text;

class SequenceOfGivenSum
{
    // Write a program that finds in given array of integers a sequence of given sum S (if present). 
    // Example: {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}	

    static void Main()
    {
        int length = 0;

        Console.Write("Enter sum : ");
        int sum = int.Parse(Console.ReadLine());

        do
        {
            Console.Write("Enter the length of the array (positive number) : ");
            length = int.Parse(Console.ReadLine());
        } while (length < 1);

        int[] array = new int[length];

        Console.WriteLine("\nEnter the elements of the array : ");

        for (int i = 0; i < length; i++)
        {
            Console.Write("Elemetn [{0}] = ", i);
            array[i] = int.Parse(Console.ReadLine());
        }
        
        StringBuilder elements = new StringBuilder();
        int tempSum = 0;
        bool hasSum = false;

        for (int i = 0; i < length; i++)
        {
            for (int j = i; j < length; j++)
            {
                tempSum += array[j];
                elements.Append(array[j]);
                elements.Append(", ");

                if (tempSum == sum)
                {
                    Console.Write("\nThe following sequences has sum = {0} :  {1}", sum, elements);
                    hasSum = true;
                }
            }
            tempSum = 0;
            elements = new StringBuilder();
        }

        if (!hasSum)
        {
            Console.WriteLine("\nThere are no sequences with sum = {0}!!!", sum);
        }

        Console.WriteLine();
    }
}

