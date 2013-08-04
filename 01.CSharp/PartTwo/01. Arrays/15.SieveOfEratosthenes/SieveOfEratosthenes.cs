using System;
using System.Threading;

class SieveOfEratosthenes
{
    // Write a program that finds all prime numbers in the range [1...10 000 000]. 
    // Use the sieve of Eratosthenes algorithm (find it in Wikipedia).

    static void Main()
    {
        bool[] isNotPrime = new bool[10000001];

        Console.WriteLine("Printing the prime numbers in the range [1:10 000 000]:");

        Console.WriteLine("\n===> The numbers below 500 will be printed slowly, after that you won't be able to see the numbers{0}",
            ", because they will be printing too fast!!!");
        
        Console.WriteLine("\n===> The whole printing will be completed in about 2 minutes.\n");
        Thread.Sleep(10000);
        
        Console.Write("{0}, ", 1);
        
        for (int index = 2; index <= 10000000; index++)
        {
            if (!isNotPrime[index])
            {
                Console.Write("{0}, ", index);
                if (index < 500)
                {
                    Thread.Sleep(500); 
                }
                
                int makeTrueIndex = index;

                do
                {
                    isNotPrime[makeTrueIndex] = true;
                    makeTrueIndex += index;
                } while (makeTrueIndex <= 10000000);
            }
        }

        Console.WriteLine();    
    }
}