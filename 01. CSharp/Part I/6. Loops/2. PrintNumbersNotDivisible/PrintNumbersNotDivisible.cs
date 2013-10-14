using System;

class PrintNumbersNotDivisible
{
    // Write a program that prints all the numbers from 
    // 1 to N,that are not divisible by 3 and 7 at the same time.

    static void Main()
    {
        Console.Write("Enter 1 integer number: ");
        int intNum = int.Parse(Console.ReadLine());

        Console.WriteLine("All numbers to {0} (not divisible by 3 and 7) are:", intNum);
        for (int i = 1; i <= intNum; i++)
        {
            if (!(i % 21 == 0))
            {
                Console.WriteLine(i);
            }            
        }

        Console.WriteLine();
    }
}
