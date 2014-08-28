using System;

class GreaterNumber
{
    // Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

    static void Main()
    {
        Console.Write("Enter first number: ");
        int firstNum = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int secondNum = int.Parse(Console.ReadLine());

        int greaterNumber = firstNum > secondNum ? firstNum : secondNum;

        Console.WriteLine("The greater number is: {0}", greaterNumber);
        Console.WriteLine();
    }
}

