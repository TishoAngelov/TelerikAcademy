using System;

class SumNNumber
{
    // Write a program that gets a number n and after that gets more n numbers and calculates and prints their sum. 

    static void Main()
    {
        Console.Write("Enter how much numbers you want to sum: ");
        int numberCount = int.Parse(Console.ReadLine());

        int [] number = new int[numberCount];
        int sumOfNumbers = 0;

        for (int i = 0; i < numberCount; i++)
        {
            Console.Write("Enter a number: ");
            number[i] = int.Parse(Console.ReadLine());

            sumOfNumbers += number[i];
        }
        Console.WriteLine("The sum of the numbers is: {0}", sumOfNumbers);
        Console.WriteLine();
    }
}