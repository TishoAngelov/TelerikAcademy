using System;

class FibonacciSequence
{
    // Write a program to print the first 100 members of the sequence of Fibonacci:
    // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

    static void Main()
    {        
        decimal prevNum = 0M;
        decimal currNum = 1M;
        decimal nextNum = 0M;
        string sequence = "1.  0, 1, ";
        int lines = 1;

        for (int i = 3; i <= 100; i++)
        {
            nextNum = currNum + prevNum;
            prevNum = currNum;
            currNum = nextNum;

            if (i != 100)
            {                
                sequence += nextNum + ", ";
            }
            else
            {
                sequence += nextNum + ".";
            }        
   
            if (i % 3 == 0)
            {
                lines++;
                sequence += Environment.NewLine + lines.ToString() + ".  ";                
            }
        }
        Console.WriteLine("First 100 member of the Fibonacci sequence:");
        Console.WriteLine(sequence);
        Console.WriteLine();
    }
}