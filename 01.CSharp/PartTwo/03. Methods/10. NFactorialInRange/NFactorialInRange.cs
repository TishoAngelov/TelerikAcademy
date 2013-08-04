using System;
using System.Numerics;

class NFactorialInRange
{
    // Write a program to calculate n! for each n in the range [1..100].
    // Hint: Implement first a method that multiplies a number 
    // represented as array of digits by given integer number. 

    static void CalcFactOfN(int[] anyArray)
    {
        for (int i = 0; i < anyArray.Length; i++)
        {
            BigInteger factorial = Factorial(i);
            Console.WriteLine(factorial);
        }
    }

    static BigInteger Factorial(int i)
    {
        BigInteger fact = i;

        while (i > 0)
        {
            fact *= i;
            i--;
        }

        return fact;
    }

    static void Main()
    {
        int[] intArr = new int[100];

        for (int i = 0; i < intArr.Length; i++)
        {
            intArr[i] = i + 1;
        }

        CalcFactOfN(intArr);

        Console.WriteLine();
    }   
}
