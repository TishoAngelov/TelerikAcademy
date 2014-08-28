using System;

class SumWithAccuracy
{
    // Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

    static void Main()
    {
        Console.WriteLine("Write a program to calculate the sum (with accuracy of 0.001): {0}" +
                "1 + 1/2 - 1/3 + 1/4 - 1/5 + ...", Environment.NewLine);

        int accuracy = 1000;
        double sumOfNumbers = 1;        
       
        for (int i = 2; i <= accuracy; i++)
        {
            if (i % 2 == 0)
            {
                sumOfNumbers += (double)1 / i;                
            }
            else
            {
                sumOfNumbers += (double)1 / (-i);
            }
        }
        Console.WriteLine("{0}Result: {1}", Environment.NewLine, sumOfNumbers);
        Console.WriteLine();
    }
}