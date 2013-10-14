using System;

class BiggestNumber
{
    // Write a program that finds the biggest of three integers using nested if statements.

    static void Main()
    {
        Console.Write("Enter first number: ");
        int firstNum = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int secondNum = int.Parse(Console.ReadLine());
        Console.Write("Enter third number: ");
        int thirdNum = int.Parse(Console.ReadLine());

        int biggestNumber = 0;
        if (firstNum > secondNum)
        {
            if (firstNum > thirdNum)
            {
                biggestNumber = firstNum;
            }
            else
            {
                biggestNumber = thirdNum;
            }            
        }
        else
        {
            if (secondNum > thirdNum)
            {
                biggestNumber = secondNum;
            }
            else
            {
                biggestNumber = thirdNum;
            }
        }
        Console.WriteLine("The biggest number is: {0}", biggestNumber);
        Console.WriteLine();
    }
}