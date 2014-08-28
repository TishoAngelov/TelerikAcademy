using System;

class Compare2Numbers
{
    /*
    Write a program that safely compares floating-point numbers 
    with precision of 0.000001. Examples:(5.3 ; 6.01) -> false;
    (5.00000001 ; 5.00000003) -> true
    */

    static void Main()
    {
        double firstNum, secondNum;

        Console.WriteLine("Please enter 2 numbers with floatin-point:\n");
        Console.Write("Enter the first number: ");
        firstNum = double.Parse(Console.ReadLine());
        Console.Write("Enter the second number: ");
        secondNum = double.Parse(Console.ReadLine());
        if (Math.Abs(firstNum - secondNum) > 0.000001)
        {
            Console.WriteLine("({0} ; {1}) -> false", firstNum, secondNum);
        }
        else
        {
            Console.WriteLine("({0} ; {1}) -> true\n\n", firstNum, secondNum);
        }
    }
}