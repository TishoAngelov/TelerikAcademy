using System;
using System.Collections.Generic;
using System.Text;

class SubtractionMultiplicationOfPolynomials
{
    // Extend the program to support also subtraction and multiplication of polynomials.

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

        StringBuilder strSumPol = new StringBuilder();

        if (sumPol[0] != 0)
        {
            strSumPol.AppendFormat("{0} ", sumPol[0]);
        }

        for (int i = 1; i < sumPol.Count; i++)
        {
            if (sumPol[i] != 0 && sumPol[i] > 0)
            {
                strSumPol.AppendFormat("+ {0}x^{1} ", sumPol[i], i);
            }

            if (sumPol[i] < 0)
            {
                strSumPol.AppendFormat("{0}x^{1} ", sumPol[i], i);
            }
        }

        Console.WriteLine(strSumPol.ToString());
    }

    static void PolynomSubstraction(int[] firstPol, int[] secondPol)
    {
        List<int> sumPol = new List<int>();

        if (firstPol.Length >= secondPol.Length)
        {
            for (int i = 0; i < firstPol.Length; i++)
            {
                sumPol.Add(firstPol[i] - secondPol[i]);
            }
        }
        else
        {
            for (int i = 0; i < secondPol.Length; i++)
            {
                sumPol.Add(firstPol[i] - secondPol[i]);
            }
        }

        StringBuilder strSumPol = new StringBuilder();

        if (sumPol[0] != 0)
        {
            strSumPol.AppendFormat("{0} ", sumPol[0]);
        }

        for (int i = 1; i < sumPol.Count; i++)
        {
            if (sumPol[i] != 0 && sumPol[i] > 0)
            {
                strSumPol.AppendFormat("+ {0}x^{1} ", sumPol[i], i);
            }

            if (sumPol[i] < 0)
            {
                strSumPol.AppendFormat("{0}x^{1} ", sumPol[i], i);
            }
        }

        Console.WriteLine(strSumPol.ToString());
    }

    static void PolynomMultiplication(int[] firstPol, int[] secondPol)
    {
        int[] multiPol = new int[firstPol.Length + secondPol.Length];
        int startPoint = 0;

        for (int i = 0; i < firstPol.Length; i++)
        {
            startPoint = i;

            for (int j = 0; j < secondPol.Length; j++)
            {
                multiPol[startPoint] = multiPol[startPoint] + (secondPol[j] * firstPol[i]);
                startPoint++;
            }
        }

        StringBuilder strMultiPol = new StringBuilder();

        if (multiPol[0] != 0)
        {
            strMultiPol.AppendFormat("{0} ", multiPol[0]);
        }

        for (int i = 1; i < multiPol.Length; i++)
        {
            if (multiPol[i] != 0 && multiPol[i] > 0)
            {
                strMultiPol.AppendFormat("+ {0}x^{1} ", multiPol[i], i);
            }

            if (multiPol[i] < 0)
            {
                strMultiPol.AppendFormat("{0}x^{1} ", multiPol[i], i);
            }
        }

        Console.WriteLine(strMultiPol.ToString());
    }

    static void Main()
    {
        int[] firstPol = { 7, 2, 3 };
        int[] secondPol = { 3, 1, 8 };

        Console.WriteLine("First polynom coefficients");
        PrintPolynomCoef(firstPol);

        Console.WriteLine("Second polynom coefficients");
        PrintPolynomCoef(secondPol);

        Console.WriteLine("\nSum:");
        PolynomSum(firstPol, secondPol);

        Console.WriteLine("\nSubstract:");
        PolynomSubstraction(firstPol, secondPol);

        Console.WriteLine("\nProduct:");
        PolynomMultiplication(firstPol, secondPol);

        Console.WriteLine();
    }
}