using System;

class AnotherFibonacciSequence
{
    // Write a program that reads a number N and calculates 
    // the sum of the first N members of the sequence of Fibonacci: 
    // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, ...
    // Each member of the Fibonacci sequence (except the first two)
    // is a sum of the previous two members.

    static void Main()
    {
        Console.Write("How much member of the Fibonacci {0}sequence you would like to calculate? - ", Environment.NewLine);
        int membersN = int.Parse(Console.ReadLine());

        decimal previousMember = 0M;
        decimal currentMember = 1M;
        decimal nextMember = 0M;
        decimal sumOfMembers = 1M;      

        for (int i = 3; i <= membersN; i++)
        {
            nextMember = previousMember + currentMember;
            sumOfMembers += nextMember;
            previousMember = currentMember;
            currentMember = nextMember;
        }

        Console.WriteLine("The sum of the first {0} members of the Fibonacci sequence:", membersN);
        Console.WriteLine(sumOfMembers);
    }
}
