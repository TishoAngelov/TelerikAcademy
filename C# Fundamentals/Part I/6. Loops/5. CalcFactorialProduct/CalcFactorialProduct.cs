using System;

class CalcFactorialProduct
{
    // Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

    static void Main()
    {
        Console.Write("Enter 1 integer number (N): ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Enter 1 integer number (K): ");
        int K = int.Parse(Console.ReadLine());

        if ((1 < N) && (N < K))
        {
            decimal NFactorial = 1M;
            for (int i = 1; i <= N; i++)
            {
                NFactorial *= i;
            }

            decimal KFactorial = 1M;
            for (int i = 1; i <= K; i++)
            {
                KFactorial *= i;
            }

            decimal KMinusNFactorial = 1M;
            for (int i = 1; i <= K - N; i++)
            {
                KMinusNFactorial *= i;
            }

            Console.WriteLine("{0}!*{1}! / ({1} - {0})! = {2}", N, K, NFactorial * KFactorial / KMinusNFactorial);
        }
        else
        {
            Console.WriteLine("The numbers N and K must meet the condition: 1 < N < K");
        }

        Console.WriteLine();
    }
}

