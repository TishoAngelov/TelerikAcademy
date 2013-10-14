using System;

class ExistingNumbers
{
    // Write a program that reads two positive integer numbers and prints how many numbers
    // p exist between them such that the reminder of the division by 5 is 0 (inclusive).
    // Example: p(17,25) = 2.

    static void Main()
    {
        Console.WriteLine("Condition: first number < second number");
        Console.Write("Enter first positive number: ");
        uint firstNum = uint.Parse(Console.ReadLine());
        Console.Write("Enter second positive number:");
        uint secondNum = uint.Parse(Console.ReadLine());

        uint existingNumbers = (secondNum / 5) - (firstNum / 5);

        Console.WriteLine("p({0}, {1}) = {2}",firstNum, secondNum, existingNumbers);
        Console.WriteLine();
    }
}