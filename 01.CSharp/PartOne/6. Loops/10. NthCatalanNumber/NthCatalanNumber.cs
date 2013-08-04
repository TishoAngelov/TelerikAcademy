using System;

class NthCatalanNumber
{
    // Write a program to calculate the Nth Catalan number by given N.

    public static decimal CalcCatalanNumber(int N)
    {
        decimal catalanNumber = 1M;

        for (int i = 2 * N; i >= 1; i--)
        {
            if (i > N + 1)
            {
                catalanNumber *= i;
            }

            if (i <= N)
            {
                catalanNumber /= i;
            }
        }

        return catalanNumber;
    }

    static void Main()
    {
        Console.Write("Enter which member from the Catalan numbers you would like to calculate: ");
        int memberN = int.Parse(Console.ReadLine());

        if (memberN >= 0)
        {
            Console.WriteLine("Formula: C{0} = ___(2_*_{0})!___{1}" +
                              "               ({0} + 1)! * {0}!", memberN, Environment.NewLine);
            Console.WriteLine("C{0} = {1}", memberN, CalcCatalanNumber(memberN));
        }
        else
        {
            Console.WriteLine("The member must be equal or greater than 0!");
        }

        Console.WriteLine();
    }
}