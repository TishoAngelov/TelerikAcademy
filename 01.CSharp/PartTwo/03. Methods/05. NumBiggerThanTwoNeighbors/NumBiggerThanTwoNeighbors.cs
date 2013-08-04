using System;

class NumBiggerThanTwoNeighbors
{
    // Write a method that checks if the element at given position in given
    // array of integers is bigger than its two neighbors (when such exist).

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

    static bool IsNumBiggerThanTwoNeighbors(int[] anyArray, int elementPosition)
    {
        bool isNumBigger = false;

        if (elementPosition < 0 || elementPosition >= anyArray.Length)      // Checks if selected position exists
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("\nNo such element exists!\n");

            Console.ResetColor();

            return false;
        }
        else
        {
            if (elementPosition == 0)
            {
                Console.WriteLine("\nSelected element has only one neighbor (right)!\n");

                isNumBigger = anyArray[elementPosition] > anyArray[elementPosition + 1];
            }
            else if (elementPosition == (anyArray.Length - 1))
            {
                Console.WriteLine("\nSelected element has only one neighbor (left)!\n");

                isNumBigger = anyArray[elementPosition] > anyArray[elementPosition - 1];
            }
            else
            {
                Console.WriteLine("\nSelected element has two neighbors (left and right)!\n");

                isNumBigger = anyArray[elementPosition] > anyArray[elementPosition - 1] &&
                                anyArray[elementPosition] > anyArray[elementPosition + 1];
            }

            return isNumBigger;
        }
    }

    static void Main()
    {
        int[] givenArray = { 1, 3, 4, 1, 3, 2, 6, 7, 3, 4, 4, 3, 8, 9, 20 };

        PrintArray(givenArray);

        Console.Write("Choose one position (starts from 0): ");
        int chosenPos = int.Parse(Console.ReadLine());

        Console.WriteLine("Is the selected element bigger than its neighbors? -> {0}", IsNumBiggerThanTwoNeighbors(givenArray, chosenPos));

        Console.WriteLine();
    }
}