using System;

class GreatestCommonDivisor
{
    // Write a program that calculates the greatest common divisor (GCD) of 
    // given two numbers. Use the Euclidean algorithm (find it in Internet).

    public static int GCD(int num1, int num2)
    {       
        if (num2 == 0)
	    {
		    return num1;
	    }
        else
	    {
            return GCD(num2, num1 % num2);
	    }     
    }

    static void Main()
    {
        Console.Write("Enter 1 integer number: ");
        int firstNum = int.Parse(Console.ReadLine());
        Console.Write("Enter 1 integer number: ");
        int secondNum = int.Parse(Console.ReadLine());

        Console.WriteLine("Their greatest common divisor is: {0}", GCD(firstNum, secondNum));

        Console.WriteLine();
    }
}