using System;

class CompareTwoCharArrays
{
    // Write a program that compares two char arrays lexicographically (letter by letter).

    static void Main()
    {
        char[] firstArray = new char[5];
        char[] secondArray = new char[5];

        for (int i = 0; i < firstArray.Length; i++)
        {
            Console.Write("First array[{0}] = ", i);
            firstArray[i] = char.Parse(Console.ReadLine());

            Console.Write("Second array[{0}] = ", i);
            secondArray[i] = char.Parse(Console.ReadLine());

            Console.WriteLine("First array[{0}] == Second array[{0}] - {1}", i, firstArray[i] == secondArray[i]);
            Console.WriteLine();
        }

        Console.WriteLine();
    }
}
