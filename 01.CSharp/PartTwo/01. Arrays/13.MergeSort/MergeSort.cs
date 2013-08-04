using System;
using System.Collections.Generic;
using System.Text;

class MergeSort
{
    // Write a program that sorts an array of integers using the merge sort algorithm (find it in Wikipedia).

    static public void DoMerge(int[] numbers, int left, int mid, int right)
    {
        int[] temp = new int[numbers.Length];
        int left_end = mid - 1;
        int num_elements = right - left + 1;
        int tmp_pos = left;
      
        while ((left <= left_end) && (mid <= right))
        {
            if (numbers[left] <= numbers[mid])
            {
                temp[tmp_pos++] = numbers[left++];
            }
            else
            {
                temp[tmp_pos++] = numbers[mid++];
            }
        }

        while (left <= left_end)
        {
            temp[tmp_pos++] = numbers[left++];
        }

        while (mid <= right)
        {
            temp[tmp_pos++] = numbers[mid++];
        }

        for (int i = 0; i < num_elements; i++)
        {
            numbers[right] = temp[right];
            right--;
        }
    }

    static public void MergeSortRecursive(int[] numbers, int left, int right)
    {
        int mid;

        if (right > left)
        {
            mid = (right + left) / 2;
            MergeSortRecursive(numbers, left, mid);
            MergeSortRecursive(numbers, (mid + 1), right);
            DoMerge(numbers, left, (mid + 1), right);
        }
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

        MergeSortRecursive(numbers, 0, n - 1); // You can read more about merge sorting here http://en.wikipedia.org/wiki/Merge_sort

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Element [{0}] = {1}", i, numbers[i]);
        }
        
        Console.WriteLine();
    }
}