using System;

class ReadNumbers
{
    // Write a program that reads 3 integer numbers from the console and prints their sum.

    static void Main()
    {
        Console.Write("Enter first number: ");
        int firstNum = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int secondNum = int.Parse(Console.ReadLine());
        Console.Write("Enter third number: ");
        int thirdNum = int.Parse(Console.ReadLine());

        int sumOfNumbers = firstNum + secondNum + thirdNum;

        Console.WriteLine("{0} + {1} + {2} = {3}", firstNum, secondNum, thirdNum, sumOfNumbers);
        Console.WriteLine();
    }
}

