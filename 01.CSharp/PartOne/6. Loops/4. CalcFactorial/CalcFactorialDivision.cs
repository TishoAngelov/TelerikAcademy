using System;

class CalcFactorialDivision
{
    // Write a program that calculates N!/K! for given N and K (1<K<N).

    static void Main()
    {
        Console.Write("Enter 1 integer number (N): ");
        int N = int.Parse(Console.ReadLine());
        Console.Write("Enter 1 integer number (K): ");
        int K = int.Parse(Console.ReadLine());

        if ((1 < K) && (K < N))
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

            Console.WriteLine("{0}!/{1}! = {2}", N, K, NFactorial / KFactorial);
        }
        else
        {
            Console.WriteLine("The numbers N and K must meet the condition: 1 < K < N");
        }
        
        Console.WriteLine();
    }
}