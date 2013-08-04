using System;

class Combination
{
    /*
    Write a program that reads two numbers N and K and generates all the 
    combinations of K distinct elements from the set [1..N]. Example:
	N = 5, K = 2 -> {1, 2}, {1, 3}, {1, 4}, {1, 5}, {2, 3}, {2, 4}, {2, 5}, {3, 4}, {3, 5}, {4, 5}
    */

    static void PrintCombination(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(" {0}", array[i]);
        }
        Console.WriteLine();
    }

    static void Combinate(int[] array, int numbers, int position, int nextPosition)
    {
        if (position == array.Length)
        {
            PrintCombination(array);
            return;
        }
        else
        {
            for (int element = nextPosition; element < numbers; element++)
            {
                array[position] = element + 1;
                Combinate(array, numbers, position + 1, element + 1);
            }
        }
    }

    static void Main()
    {
        int numbers = 0;
        int numbersInCombination = 0;

        do
        {
            Console.Write("How many numbers does the array have : ");
            numbers = int.Parse(Console.ReadLine());
        } while (numbers < 1);

        do
        {
            Console.Write("How many numbers does each combination have : ");
            numbersInCombination = int.Parse(Console.ReadLine());
        } while (numbersInCombination < 1 || numbersInCombination > numbers);


        int[] array = new int[numbersInCombination];

        Console.WriteLine("\nHere are the combinations : ");
        
        Combinate(array, numbers, 0, 0);
        
        Console.WriteLine();
    }
}