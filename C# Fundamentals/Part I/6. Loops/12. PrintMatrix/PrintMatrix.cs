using System;

class PrintMatrix
{
    // Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix like the following:
    // N = 3			N = 4
    // 1 2 3            1 2 3 4
    // 2 3 4            2 3 4 5
    // 3 4 5            3 4 5 6
    //                  4 5 6 7

    static void Main()
    {
        Console.Write("Enter 1 number (0 < N < 20): ");
        int numberN = int.Parse(Console.ReadLine());

        Console.WriteLine("N = {0}", numberN);

        for (int i = 1; i <= numberN; i++)
        {
            Console.WriteLine();

            for (int j = i; j <= i + numberN - 1; j++)
            {
                Console.Write(j + " ");
            }           
        }
        
        Console.WriteLine();
        Console.WriteLine();
    }
}