using System;

class SumOfIntegers
{
    // Write a program that, for a given two integer numbers 
    // N and X, calculates the sumS = 1 + 1!/X + 2!/X² + ... + N!/Xᶰ

    static void Main()
    {
        Console.Write("N = ");
        int intN = int.Parse(Console.ReadLine());
        Console.Write("X = ");
        int intX = int.Parse(Console.ReadLine());

        decimal sumS = 1;
        decimal numerator = 1;
        decimal denominator = 1;

        for (int i = 1; i <= intN; i++)
        {
            numerator *= i;
            denominator *= intX;
            sumS += numerator / denominator;
        }

        Console.WriteLine("S = 1 + 1!/X + 2!/X^2 + ... + N!/X^N");
        Console.WriteLine("S = {0}", sumS);

        Console.WriteLine();
    }
}