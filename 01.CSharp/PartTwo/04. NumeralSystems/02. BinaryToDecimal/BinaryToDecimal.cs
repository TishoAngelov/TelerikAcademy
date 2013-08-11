using System;
using System.Collections.Generic;
using System.Numerics;

class BinaryToDecimal
{
    // Write a program to convert binary numbers to their decimal representation.

    static void Main()
    {
        Console.Write("Enter one binary number (digits of 1 or 0): ");
        string binNum = Console.ReadLine();

        BigInteger decNum = 0;

        for (int i = binNum.Length - 1; i >= 0 ; i--)
        {
            int currDigit = Convert.ToInt32(binNum[binNum.Length - i - 1]) - 48;

            if (currDigit != 0 && currDigit != 1)
            {
                Console.WriteLine("Your number contains incorrect digits! Only 1 and 0 are allowed!\n");

                return;
            }

            decNum += currDigit * (BigInteger)Math.Pow(2, i);
        }

        Console.WriteLine("To decimal: {0}", decNum);
        Console.WriteLine();
    }
}