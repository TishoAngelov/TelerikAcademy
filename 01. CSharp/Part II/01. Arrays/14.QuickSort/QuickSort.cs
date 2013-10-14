using System;
using System.Linq;
using System.Text;

class QuickSort
{
    // Write a program that sorts an array of strings using the quick sort algorithm (find it in Wikipedia).

    static void Quicksort(int[] input, int low, int high)
    {
        int pivot = 0;

        if (low < high)
        {
            pivot = Partition(input, low, high);
            Quicksort(input, low, pivot - 1);
            Quicksort(input, pivot + 1, high);
        }
    }

    static int Partition(int[] input, int low, int high)
    {
        int pivot = input[high];
        int i = low - 1;
        int tmp = 0;

        for (int j = low; j < high; j++)
        {
            if (input[j] <= pivot)
            {
                i++;
         
                tmp = input[i];
                input[i] = input[j];
                input[j] = tmp;
            }
        }
        
        tmp = input[i + 1];
        input[i + 1] = input[high];
        input[high] = tmp;

        return i + 1;
    }

    static void Main()
    {
        int n = 0;

        do
        {
            Console.Write("How many elements does the array have ? - ");
            n = int.Parse(Console.ReadLine());
        } while (n < 1);

        int[] numbers = new int[n];

        Console.WriteLine("\nEnter the elements of the array:");

        for (int i = 0; i < n; i++)
        {
            Console.Write("Element [{0}] = ", i);
            numbers[i] = int.Parse(Console.ReadLine());
        }

        Console.WriteLine("\n\nThe sorted array is : ");

        Quicksort(numbers, 0, n - 1); // You can read more about quick sorting here ---> http://en.wikipedia.org/wiki/Quicksort

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Element [{0}] = {1}", i, numbers[i]);
        }

        Console.WriteLine();
    }
}
