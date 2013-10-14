using System;
using System.Collections.Generic;
using System.Text;

class AddTwoPolynoms
{
    // Write a method that adds two polynomials. Represent them as arrays of their coefficients as in the example below:
    //  	x^2 + 5 = 1.x^2 + 0.x + 5 -> |5|0|1|

    static void PrintPolynomCoef(int[] anyPol)
    {
        for (int i = 0; i < anyPol.Length; i++)
        {
            Console.Write(anyPol[i] + " ");
        }

        Console.WriteLine();
    }

    static void PolynomSum(int[] firstPol, int[] secondPol)
    {
        List<int> sumPol = new List<int>();

        if (firstPol.Length >= secondPol.Length)
        {
            for (int i = 0; i < firstPol.Length; i++)
            {
                sumPol.Add(firstPol[i] + secondPol[i]);
            }
        }
        else
        {
            for (int i = 0; i < secondPol.Length; i++)
            {
                sumPol.Add(firstPol[i] + secondPol[i]);
            }
        }

        StringBuilder stringSumPol = new StringBuilder();

        if (sumPol[0] != 0)
        {
            stringSumPol.AppendFormat("{0} ", sumPol[0]);
        }

        for (int i = 1; i < sumPol.Count; i++)
        {
            if (sumPol[i] != 0 && sumPol[i] > 0)
            {
                stringSumPol.AppendFormat("+ {0}x^{1} ", sumPol[i], i);
            }
            if (sumPol[i] < 0)
            {
                stringSumPol.AppendFormat("{0}x^{1} ", sumPol[i], i);
            }
        }

        Console.WriteLine(stringSumPol.ToString());
    }

    static void Main()
    {
        // test polynoms
        int[] firstPol = { 5, 0, 1 };
        int[] secPol = { 3, 3, 2 };

        Console.WriteLine("First polynom coefficients");
        PrintPolynomCoef(firstPol);

        Console.WriteLine("Second polynom coefficients");
        PrintPolynomCoef(secPol);

        Console.WriteLine("Sum:");
        PolynomSum(firstPol, secPol);

        Console.WriteLine();
    }   
}